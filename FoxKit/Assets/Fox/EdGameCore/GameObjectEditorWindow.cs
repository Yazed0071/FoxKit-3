﻿using Fox.Core;
using System.Collections.Generic;
using Fox.EdGameCore;
using Fox.EdCore;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Tpp.EdGameCore
{
    public class GameObjectEditorWindow : EditorWindow
    {
        private PopupField<string> gameObjectTypeDropdown;
        private PopupField<string> presetPopup;

        private string selectedType = null;
        private string selectedPreset = null;
        private UInt32Field groupIdField;
        private UInt32Field totalCountField;
        private UInt32Field realizedCountField;
        private Toggle createLocator;

        private static readonly List<string> DefaultPresetList = new();

        [MenuItem("Fox/GameObject Creator")]
        public static void ShowWindow()
        {
            var window = GetWindow<GameObjectEditorWindow>();
            window.titleContent = new GUIContent("GameObject Creator");
            window.minSize = new Vector2(350, 300);
        }

        public void CreateGUI()
        {
            List<string> typeList = Fox.EdGameCore.EdGameCoreModule.GameObjectTypeList;
            if (typeList == null || typeList.Count < 1)
            {
               return;
            }

            selectedType = typeList[0];

            gameObjectTypeDropdown = new PopupField<string>("GameObject Type", typeList, 0);
            presetPopup = new PopupField<string>("Preset", DefaultPresetList, 0);
            presetPopup.style.display = DisplayStyle.None;

            groupIdField = new UInt32Field(nameof(Fox.GameCore.GameObject.groupId))
            {
                tooltip =
                    "Group identifier, Unclear what it does.\nAlways 0 in any GameObject."
            };
            totalCountField = new UInt32Field(nameof(Fox.GameCore.GameObject.totalCount))
            {
                tooltip =
                    "Maximum number of instances of this GameObject that can exist"
            };
            realizedCountField = new UInt32Field(nameof(Fox.GameCore.GameObject.realizedCount))
            {
                tooltip =
                    "Maximum number of instances that can be rendered or active at the same time."
            };
            createLocator = new Toggle("Create Locator")
            {
                tooltip =
                    "If enabled, generates a GameObjectLocator for each GameObject.\nThe number of locators will match the Total Count."
            };
            createLocator.style.display = DisplayStyle.None;

            rootVisualElement.Add(gameObjectTypeDropdown);
            rootVisualElement.Add(presetPopup);

            rootVisualElement.Add(groupIdField);
            rootVisualElement.Add(totalCountField);
            rootVisualElement.Add(realizedCountField);
            rootVisualElement.Add(createLocator);

            SetGameObjectTypeFields();

            gameObjectTypeDropdown.RegisterValueChangedCallback(
                evt =>
                {
                    selectedType = evt.newValue;
                    SetGameObjectTypeFields();
                }
            );

            presetPopup.RegisterValueChangedCallback(
                evt =>
                {
                    selectedPreset = evt.newValue;
                }
            );

            realizedCountField.RegisterValueChangedCallback<uint>(
                evt =>
                {
                    if (evt.newValue > totalCountField.value)
                    {
                        realizedCountField.SetValueWithoutNotify(totalCountField.value);
                        Debug.LogWarning("Realized count cannot be greater than total count."); //Because why would it?
                    }
                }
            );

            var createGameObjectButton = new Button(OnCreateButtonClicked)
            {
                text = "Create GameObject"
            };

            rootVisualElement.Add(createGameObjectButton);
            var resetButton = new Button(SetGameObjectTypeFields) { text = "Reset" };

            rootVisualElement.Add(resetButton);
        }

        private void SetGameObjectTypeFields()
        {
            bool hasInfo = Fox.EdGameCore.EdGameCoreModule.TryGetEditorInfoForGameObjectType(
                selectedType,
                out GameObjectEditorInfo info
            );
            if (!hasInfo)
            {
                return;
            }

            groupIdField.value = info.groupId;
            totalCountField.value = info.totalCount;
            realizedCountField.value = info.realizedCount;

            List<string> presets = info.Presets;
            if (presets != null)
            {
                presetPopup.choices = presets;
                presetPopup.value = presets[0];
                presetPopup.style.display = DisplayStyle.Flex;
            }
            else
            {
                presetPopup.style.display = DisplayStyle.None;
            }

            if (!info.canCreateLocator)
            {
                createLocator.style.display = DisplayStyle.None;
            }
            else
            {
                createLocator.style.display = DisplayStyle.Flex;
            }
        }
        private void OnCreateButtonClicked()
        {
            var scene = SceneManager.GetActiveScene();

            if (!scene.IsValid() || !scene.isLoaded)
            {
                Debug.LogWarning("No active scene!");
                return;
            }

            bool hasInfo = Fox.EdGameCore.EdGameCoreModule.TryGetEditorInfoForGameObjectType(
                selectedType,
                out GameObjectEditorInfo info
            );
            if (!hasInfo)
                return;

            // Create/setup new Fox GameObject
            Fox.GameCore.GameObject[] existingGameObjects =
                FindObjectsOfType<Fox.GameCore.GameObject>(true);

            Fox.GameCore.GameObject gameObject = null;
            foreach (var existingObject in existingGameObjects)
                if (
                    existingObject.typeName == selectedType
                    && existingObject.gameObject.scene == scene
                )
                    gameObject = existingObject;

            if (gameObject == null)
            {
                gameObject = new UnityEngine.GameObject().AddComponent<Fox.GameCore.GameObject>();
                //SceneManager.MoveGameObjectToScene(obj, scene);
            }
            else
            {
                // Reset children
                while (gameObject.transform.childCount > 0)
                    DestroyImmediate(gameObject.transform.GetChild(0).gameObject);
            }

            // Initialize
            gameObject.name = $"{selectedType}GameObject";
            gameObject.typeName = selectedType;
            gameObject.groupId = groupIdField.value;
            gameObject.totalCount = totalCountField.value;
            gameObject.realizedCount = realizedCountField.value;

            DataElement parameterBase = info.CreateParameterFunc(selectedPreset);
            parameterBase.name = "Parameters";
            gameObject.parameters = parameterBase;
            parameterBase.SetOwner(gameObject);

            Selection.activeGameObject = gameObject.gameObject;

            // Create/setup new Fox GameObjectLocator
            if (createLocator.value)
            {
                Fox.GameCore.GameObjectLocator gameObjectLocator = null;
                var existingGameObjectLocators = FindObjectsOfType<Fox.GameCore.GameObjectLocator>(true);

                foreach (var existingLocator in existingGameObjectLocators)
                {
                    if (existingLocator.typeName == selectedType && existingLocator.gameObject.scene == scene)
                    {
                        gameObjectLocator = existingLocator;
                        break;
                    }
                }

                for (int i = 0; i < totalCountField.value; i++)
                {
                    gameObjectLocator = new UnityEngine.GameObject().AddComponent<Fox.GameCore.GameObjectLocator>();
                    gameObjectLocator.name = $"{selectedType}_GameObjectLocator_{i}";

                    TransformEntity transformBase = new UnityEngine.GameObject().AddComponent<Fox.Core.TransformEntity>();
                    transformBase.name = "TransformEntity";
                    transformBase.SetOwner(gameObjectLocator);

                    gameObjectLocator.SetProperty("transform", new Fox.Core.Value(transformBase));

                    gameObjectLocator.typeName = selectedType;
                    gameObjectLocator.groupId = groupIdField.value;
                    gameObjectLocator.parameters = info.CreateLocatorParameterFunc(selectedPreset);
                    gameObjectLocator.parameters.name = "Parameters";
                    gameObjectLocator.parameters.SetOwner(gameObjectLocator);
                }
            }
        }
    }
}