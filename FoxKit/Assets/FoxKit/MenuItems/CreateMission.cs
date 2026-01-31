using Fox.EdCore;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

// Needed for reading Fox.EdCore.Vector3Field internals safely (no Linq)
using DoubleField = Fox.EdCore.DoubleField;
using FloatField = Fox.EdCore.FloatField;

namespace FoxKit.MenuItems
{
    public class CreateMission : EditorWindow
    {
        [MenuItem("FoxKit/Create/Mission")]
        public static void ShowWindow()
        {
            var w = GetWindow<CreateMission>();
            w.titleContent = new GUIContent("Mission Creator");
            w.minSize = new Vector2(450f, 400f);
        }

        private const ushort MIN_MISSION_CODE = 13000;
        private const ushort MAX_MISSION_CODE = 14999;
        private const int MAX_TASK_INDEX = 7;

        private const int FONT_BODY = 14;
        private const int FONT_SECTION = 18;
        private const int FONT_SUB = 14;

        private const string CUSTOM_OPTION = "Custom...";

        private ScrollView scroll;

        // Mission settings
        private UInt16Field missionCode;
        private PopupField<string> location;
        private TextField customLocationField;
        private List<string> runtimeLocations;

        private Toggle hideMission;
        private UInt32Field missionGuaranteeGMP;
        private Toggle noAddVolunteers;

        private readonly Toggle[] taskToggles = new Toggle[MAX_TASK_INDEX + 1];

        private Toggle noArmorForMission;
        private PopupField<string> missionArmorType;
        private VisualElement armorContainer;

        // OrderBox
        private Toggle isNoOrderBoxMission;
        private VisualElement orderBoxContainer;
        private VisualElement orderBoxBlockpathsContainer;
        private VisualElement orderBoxLocatorListContainer;
        private Button orderBoxLocatorAddBtn;
        private int orderBoxBlockIndex;
        private int orderBoxLocatorIndex;

        // missionMapParams
        private Toggle enableOOB;
        private VisualElement oobContainer;

        private Foldout missionArea2;
        private VisualElement missionArea2ZonesContainer;
        private int missionArea2ZoneIndex;

        private Foldout safetyArea2;
        private VisualElement safetyArea2ZonesContainer;
        private int safetyArea2ZoneIndex;

        private Foldout missionStartPoint;
        private VisualElement missionStartPointContainer;
        private int missionStartPointIndex;

        private Foldout heliLandPoint;
        private VisualElement heliLandPointContainer;
        private int heliLandPointIndex;

        private Toggle flagSkipMissionPrep;
        private Toggle flagNoBuddyMenu;
        private Toggle flagNoVehicleMenu;
        private Toggle flagDisableSortieTime;

        private Foldout missionPacks;
        private readonly Dictionary<string, Toggle> packToggles = new Dictionary<string, Toggle>();
        private readonly Dictionary<string, string> packPathByKey = new Dictionary<string, string>();

        private int customPackIndex;
        private VisualElement customPacksItemsContainer;
        private readonly Dictionary<string, TextField> customPackPaths = new Dictionary<string, TextField>();

        private static readonly List<string> locationList = new List<string> { "AFGH", "MAFR", "MTBS" };
        private static readonly List<string> missionArmorTypeList = new List<string>
        {
            "TppEnemyBodyId.sva0_v00_a",
            "TppDefine.AFR_ARMOR.TYPE_CFA",
            "TppDefine.AFR_ARMOR.TYPE_ZRS",
            "TppDefine.AFR_ARMOR.TYPE_RC"
        };

        // Data-driven pack categories (shorter than repeating CreatePackCategory calls)
        private struct PackDef { public string key; public string path; public PackDef(string k, string p) { key = k; path = p; } }
        private struct PackCategoryDef { public string name; public PackDef[] packs; public PackCategoryDef(string n, PackDef[] p) { name = n; packs = p; } }

        private static readonly PackCategoryDef[] PACK_CATEGORIES = new PackCategoryDef[]
        {
            new PackCategoryDef("LOCATION_SCRIPTS", new PackDef[]
            {
                new PackDef("AFGH_SCRIPT","TppDefine.MISSION_COMMON_PACK.AFGH_SCRIPT"),
                new PackDef("MAFR_SCRIPT","TppDefine.MISSION_COMMON_PACK.MAFR_SCRIPT"),
                new PackDef("CYPR_SCRIPT","TppDefine.MISSION_COMMON_PACK.CYPR_SCRIPT"),
                new PackDef("MTBS_SCRIPT","TppDefine.MISSION_COMMON_PACK.MTBS_SCRIPT"),
            }),
            new PackCategoryDef("MISSION_AREA", new PackDef[]
            {
                new PackDef("AFGH_MISSION_AREA","TppDefine.MISSION_COMMON_PACK.AFGH_MISSION_AREA"),
                new PackDef("MAFR_MISSION_AREA","TppDefine.MISSION_COMMON_PACK.MAFR_MISSION_AREA"),
                new PackDef("MTBS_MISSION_AREA","TppDefine.MISSION_COMMON_PACK.MTBS_MISSION_AREA"),
            }),
            new PackCategoryDef("HOSTAGE", new PackDef[]
            {
                new PackDef("AFGH_HOSTAGE","TppDefine.MISSION_COMMON_PACK.AFGH_HOSTAGE"),
                new PackDef("MAFR_HOSTAGE","TppDefine.MISSION_COMMON_PACK.MAFR_HOSTAGE"),
                new PackDef("MAFR_HOSTAGE_WOMAN","TppDefine.MISSION_COMMON_PACK.MAFR_HOSTAGE_WOMAN"),
                new PackDef("FOB_HOSTAGE","TppDefine.MISSION_COMMON_PACK.FOB_HOSTAGE"),
            }),
            new PackCategoryDef("HELICOPTER", new PackDef[]
            {
                new PackDef("HELICOPTER","TppDefine.MISSION_COMMON_PACK.HELICOPTER"),
                new PackDef("ENEMY_HELI","TppDefine.MISSION_COMMON_PACK.ENEMY_HELI"),
            }),
            new PackCategoryDef("ORDER_BOX", new PackDef[]
            {
                new PackDef("ORDER_BOX","TppDefine.MISSION_COMMON_PACK.ORDER_BOX"),
            }),
            new PackCategoryDef("CHARACTERS", new PackDef[]
            {
                new PackDef("CODETALKER", "TppDefine.MISSION_COMMON_PACK.CODETALKER"),
                new PackDef("HUEY", "TppDefine.MISSION_COMMON_PACK.HUEY"),
                new PackDef("LIQUID", "TppDefine.MISSION_COMMON_PACK.LIQUID"),
                new PackDef("MANTIS", "TppDefine.MISSION_COMMON_PACK.MANTIS"),
                new PackDef("MILLER", "TppDefine.MISSION_COMMON_PACK.MILLER"),
                new PackDef("OCELOT", "TppDefine.MISSION_COMMON_PACK.OCELOT"),
                new PackDef("QUIET", "TppDefine.MISSION_COMMON_PACK.QUIET"),
                new PackDef("SAHELAN", "TppDefine.MISSION_COMMON_PACK.SAHELAN"),
                new PackDef("SKULLFACE", "TppDefine.MISSION_COMMON_PACK.SKULLFACE"),
                new PackDef("PF_SOLIDER", "TppDefine.MISSION_COMMON_PACK.PF_SOLIDER"),
                new PackDef("SOVIET_SOLIDER", "TppDefine.MISSION_COMMON_PACK.SOVIET_SOLIDER"),
                new PackDef("DD_SOLDIER_WAIT", "TppDefine.MISSION_COMMON_PACK.DD_SOLDIER_WAIT"),
                new PackDef("VOLGIN", "TppDefine.MISSION_COMMON_PACK.VOLGIN"),
                new PackDef("WALKERGEAR", "TppDefine.MISSION_COMMON_PACK.WALKERGEAR"),
                new PackDef("CHILD_SOLDIER", "TppDefine.MISSION_COMMON_PACK.CHILD_SOLDIER"),
                new PackDef("XOF_SOLDIER", "TppDefine.MISSION_COMMON_PACK.XOF_SOLDIER"),
                new PackDef("DD_SOLDIER_ATTACKER", "TppDefine.MISSION_COMMON_PACK.DD_SOLDIER_ATTACKER"),
                new PackDef("DD_SOLDIER_SNEAKING", "TppDefine.MISSION_COMMON_PACK.DD_SOLDIER_SNEAKING"),
                new PackDef("DD_SOLDIER_BTRDRS", "TppDefine.MISSION_COMMON_PACK.DD_SOLDIER_BTRDRS"),
                new PackDef("DD_SOLDIER_ARMOR", "TppDefine.MISSION_COMMON_PACK.DD_SOLDIER_ARMOR"),
                new PackDef("DD_SOLDIER_SWIM_SUIT", "TppDefine.MISSION_COMMON_PACK.DD_SOLDIER_SWIM_SUIT"),
                new PackDef("DD_SOLDIER_SWIM_SUIT2", "TppDefine.MISSION_COMMON_PACK.DD_SOLDIER_SWIM_SUIT2"),
                new PackDef("DD_SOLDIER_SWIM_SUIT3", "TppDefine.MISSION_COMMON_PACK.DD_SOLDIER_SWIM_SUIT3"),
            }),
            new PackCategoryDef("DECOYS", new PackDef[]
            {
                new PackDef("AFGH_DECOY","TppDefine.MISSION_COMMON_PACK.AFGH_DECOY"),
                new PackDef("MAFR_DECOY","TppDefine.MISSION_COMMON_PACK.MAFR_DECOY"),
                new PackDef("MTBS_DECOY","TppDefine.MISSION_COMMON_PACK.MTBS_DECOY"),
            }),
            new PackCategoryDef("ANIMALS", new PackDef[]
            {
                new PackDef("BEAR","TppDefine.MISSION_COMMON_PACK.BEAR"),
                new PackDef("RAVEN","TppDefine.MISSION_COMMON_PACK.RAVEN"),
                new PackDef("RAT","TppDefine.MISSION_COMMON_PACK.RAT"),
                new PackDef("LYCAON","TppDefine.MISSION_COMMON_PACK.LYCAON"),
                new PackDef("JACKAL","TppDefine.MISSION_COMMON_PACK.JACKAL"),
            }),
            new PackCategoryDef("VEHICLE", new PackDef[]
            {
                new PackDef("EAST_LV", "TppDefine.MISSION_COMMON_PACK.EAST_LV"),
                new PackDef("EAST_TANK", "TppDefine.MISSION_COMMON_PACK.EAST_TANK"),
                new PackDef("EAST_TRUCK", "TppDefine.MISSION_COMMON_PACK.EAST_TRUCK"),
                new PackDef("EAST_TRUCK_AMMUNITION", "TppDefine.MISSION_COMMON_PACK.EAST_TRUCK_AMMUNITION"),
                new PackDef("EAST_TRUCK_DRUM", "TppDefine.MISSION_COMMON_PACK.EAST_TRUCK_DRUM"),
                new PackDef("EAST_TRUCK_GENERATOR", "TppDefine.MISSION_COMMON_PACK.EAST_TRUCK_GENERATOR"),
                new PackDef("EAST_TRUCK_MATERIAL", "TppDefine.MISSION_COMMON_PACK.EAST_TRUCK_MATERIAL"),
                new PackDef("EAST_WAV", "TppDefine.MISSION_COMMON_PACK.EAST_WAV"),
                new PackDef("EAST_WAV_ROCKET", "TppDefine.MISSION_COMMON_PACK.EAST_WAV_ROCKET"),
                new PackDef("WEST_LV", "TppDefine.MISSION_COMMON_PACK.WEST_LV"),
                new PackDef("WEST_TANK", "TppDefine.MISSION_COMMON_PACK.WEST_TANK"),
                new PackDef("WEST_TRUCK", "TppDefine.MISSION_COMMON_PACK.WEST_TRUCK"),
                new PackDef("WEST_TRUCK_CISTERN", "TppDefine.MISSION_COMMON_PACK.WEST_TRUCK_CISTERN"),
                new PackDef("WEST_TRUCK_CONTAINER", "TppDefine.MISSION_COMMON_PACK.WEST_TRUCK_CONTAINER"),
                new PackDef("WEST_TRUCK_ITEMBOX", "TppDefine.MISSION_COMMON_PACK.WEST_TRUCK_ITEMBOX"),
                new PackDef("WEST_TRUCK_HOOD", "TppDefine.MISSION_COMMON_PACK.WEST_TRUCK_HOOD"),
                new PackDef("WEST_WAV", "TppDefine.MISSION_COMMON_PACK.WEST_WAV"),
                new PackDef("WEST_WAV_CANNON", "TppDefine.MISSION_COMMON_PACK.WEST_WAV_CANNON"),
                new PackDef("WEST_WAV_MACHINE_GUN", "TppDefine.MISSION_COMMON_PACK.WEST_WAV_MACHINE_GUN"),
                new PackDef("AMBULANCE", "TppDefine.MISSION_COMMON_PACK.AMBULANCE")
            }),
            new PackCategoryDef("AVATAR", new PackDef[]
            {
                new PackDef("AVATAR_EDIT","TppDefine.MISSION_COMMON_PACK.AVATAR_EDIT"),
                new PackDef("AVATAR_ASSET_LIST","TppDefine.MISSION_COMMON_PACK.AVATAR_ASSET_LIST"),
            }),
        };

        public void CreateGUI()
        {
            rootVisualElement.Clear();

            scroll = new ScrollView(ScrollViewMode.Vertical);
            scroll.style.flexGrow = 1;
            scroll.style.fontSize = FONT_BODY;
            rootVisualElement.Add(scroll);

            scroll.Add(new Button(ExportLuaToFile)
            {
                text = "Export .lua",
                tooltip = "Export current mission settings to a .lua file."
            });

            BuildMissionSettingsUI();
            BuildMissionMapParamsUI();
            BuildMissionPacksUI();

            location.RegisterValueChangedCallback(e =>
            {
                if (e.newValue != CUSTOM_OPTION)
                    ApplyLocationDefaults(e.newValue);
            });

            ApplyLocationDefaults(location.value);
        }

        private void BuildMissionSettingsUI()
        {
            var missionFoldout = NewFoldout("Mission Settings", FONT_SECTION, FontStyle.Bold);
            scroll.Add(missionFoldout);

            missionCode = new UInt16Field("missionCode") { tooltip = "Mission code is UInt16. Hard missions are typically +1000." };
            missionCode.SetValueWithoutNotify(MIN_MISSION_CODE);
            missionFoldout.Add(missionCode);

            missionCode.RegisterCallback<FocusOutEvent>(_ =>
            {
                ushort v = missionCode.value;
                if (v < MIN_MISSION_CODE) missionCode.SetValueWithoutNotify(MIN_MISSION_CODE);
                else if (v > MAX_MISSION_CODE) missionCode.SetValueWithoutNotify(MAX_MISSION_CODE);
            });

            runtimeLocations = new List<string>(locationList);
            if (!runtimeLocations.Contains(CUSTOM_OPTION)) runtimeLocations.Add(CUSTOM_OPTION);

            location = new PopupField<string>("location", runtimeLocations, 0);
            missionFoldout.Add(location);

            customLocationField = new TextField("Custom location")
            {
                tooltip = "Enter a location code (e.g., AFGH). Press Enter or click away to apply."
            };
            customLocationField.style.display = DisplayStyle.None;
            missionFoldout.Add(customLocationField);

            location.RegisterValueChangedCallback(e =>
            {
                bool isCustom = e.newValue == CUSTOM_OPTION;
                customLocationField.style.display = isCustom ? DisplayStyle.Flex : DisplayStyle.None;
                if (isCustom) customLocationField.Focus();
            });

            customLocationField.RegisterCallback<FocusOutEvent>(_ => TryApplyCustomLocation());
            customLocationField.RegisterCallback<KeyDownEvent>(e =>
            {
                if (e.keyCode == KeyCode.Return || e.keyCode == KeyCode.KeypadEnter)
                    TryApplyCustomLocation();
            });

            hideMission = new Toggle("hideMission");
            missionFoldout.Add(hideMission);

            missionGuaranteeGMP = new UInt32Field("missionGuaranteeGMP") { tooltip = "Base GMP for mission on mission clear." };
            missionFoldout.Add(missionGuaranteeGMP);

            noAddVolunteers = new Toggle("noAddVolunteers") { tooltip = "If true, volunteers will not be added on mission clear." };
            missionFoldout.Add(noAddVolunteers);

            var tasksFoldout = NewFoldout("Mission Tasks", FONT_SUB, FontStyle.Normal);
            missionFoldout.Add(tasksFoldout);

            for (int i = 0; i <= MAX_TASK_INDEX; i++)
            {
                var t = new Toggle("Task " + i) { value = true };
                taskToggles[i] = t;
                tasksFoldout.Add(t);
            }

            noArmorForMission = new Toggle("noArmorForMission") { tooltip = "If true, enemies won't have full armor." };
            missionFoldout.Add(noArmorForMission);

            armorContainer = new VisualElement();
            missionFoldout.Add(armorContainer);

            missionArmorType = new PopupField<string>("missionArmorType", missionArmorTypeList, 0);
            armorContainer.Add(missionArmorType);

            armorContainer.style.display = noArmorForMission.value ? DisplayStyle.None : DisplayStyle.Flex;
            noArmorForMission.RegisterValueChangedCallback(evt =>
            {
                armorContainer.style.display = evt.newValue ? DisplayStyle.None : DisplayStyle.Flex;
            });

            // OrderBox
            var orderBoxFoldout = NewFoldout("OrderBox", FONT_SUB, FontStyle.Normal);
            missionFoldout.Add(orderBoxFoldout);

            isNoOrderBoxMission = new Toggle("isNoOrderBoxMission") { tooltip = "If true, the mission will start without an orderBox." };
            orderBoxFoldout.Add(isNoOrderBoxMission);

            orderBoxContainer = new VisualElement();
            orderBoxFoldout.Add(orderBoxContainer);

            orderBoxBlockpathsContainer = new VisualElement { name = "orderBoxBlockpathsContainer" };
            orderBoxLocatorListContainer = new VisualElement { name = "orderBoxLocatorListContainer" };

            orderBoxContainer.Add(new Button(() =>
            {
                var tf = new TextField("OrderBoxBlock_" + orderBoxBlockIndex) { tooltip = "Order box block path (e.g. /Assets/.../something.fpk)" };
                orderBoxBlockIndex++;
                orderBoxBlockpathsContainer.Add(tf);
                RefreshOrderBoxUI();
            })
            { text = "Add Order Box Block Path" });

            orderBoxLocatorAddBtn = new Button(() =>
            {
                var tf = new TextField("OrderBoxLocator_" + orderBoxLocatorIndex) { tooltip = "Locator name (e.g: box_s13000_00)." };
                orderBoxLocatorIndex++;
                orderBoxLocatorListContainer.Add(tf);
            })
            { text = "Add Order Box Locator name" };

            orderBoxContainer.Add(orderBoxLocatorAddBtn);
            orderBoxContainer.Add(orderBoxBlockpathsContainer);
            orderBoxContainer.Add(orderBoxLocatorListContainer);

            RefreshOrderBoxUI();
            orderBoxContainer.style.display = isNoOrderBoxMission.value ? DisplayStyle.None : DisplayStyle.Flex;

            isNoOrderBoxMission.RegisterValueChangedCallback(evt =>
            {
                if (evt.newValue)
                {
                    orderBoxContainer.style.display = DisplayStyle.None;
                    orderBoxBlockpathsContainer.Clear();
                    orderBoxLocatorListContainer.Clear();
                    orderBoxBlockIndex = 0;
                    orderBoxLocatorIndex = 0;
                    RefreshOrderBoxUI();
                }
                else
                {
                    orderBoxContainer.style.display = DisplayStyle.Flex;
                    RefreshOrderBoxUI();
                }
            });
        }

        private void BuildMissionMapParamsUI()
        {
            var missionMapParams = NewFoldout("missionMapParams", FONT_SECTION, FontStyle.Bold, "Normal mission area zones as they appear on the iDroid.");
            scroll.Add(missionMapParams);

            enableOOB = new Toggle("enableOOB") { tooltip = "Enable out of bounds system (missionArea2 + safetyArea2).", value = true };
            missionMapParams.Add(enableOOB);

            oobContainer = new VisualElement();
            missionMapParams.Add(oobContainer);

            oobContainer.style.display = enableOOB.value ? DisplayStyle.Flex : DisplayStyle.None;
            enableOOB.RegisterValueChangedCallback(evt =>
            {
                oobContainer.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
            });

            missionArea2 = NewFoldout("missionArea2", FONT_SUB, FontStyle.Normal, "Leaving the innerZone will only warn the player that they're leaving.");
            oobContainer.Add(missionArea2);

            missionArea2ZonesContainer = new VisualElement { name = "missionArea2ZonesContainer" };
            missionArea2.Add(missionArea2ZonesContainer);
            missionArea2.Insert(0, new Button(() => AddZoneUI(missionArea2ZonesContainer, "Mission Area Zone", ref missionArea2ZoneIndex)) { text = "Add Mission Area Zone" });

            safetyArea2 = NewFoldout("safetyArea2", FONT_SUB, FontStyle.Normal, "Hot zone as it appears on the iDroid.");
            oobContainer.Add(safetyArea2);

            safetyArea2ZonesContainer = new VisualElement { name = "safetyArea2ZonesContainer" };
            safetyArea2.Add(safetyArea2ZonesContainer);
            safetyArea2.Insert(0, new Button(() => AddZoneUI(safetyArea2ZonesContainer, "Safety Area Zone", ref safetyArea2ZoneIndex)) { text = "Add Safety Area Zone" });

            missionStartPoint = NewFoldout("missionStartPoint", FONT_SUB, FontStyle.Normal, "iDroid points where the mission starts (ground).");
            missionMapParams.Add(missionStartPoint);

            missionStartPointContainer = new VisualElement { name = "missionStartPointContainer" };
            missionStartPoint.Add(missionStartPointContainer);
            missionStartPoint.Insert(0, new Button(() => AddStartPoint(missionStartPointContainer)) { text = "Add Mission Start Point" });

            heliLandPoint = NewFoldout("heliLandPoint", FONT_SUB, FontStyle.Normal, "Mission start LZs.");
            missionMapParams.Add(heliLandPoint);

            heliLandPointContainer = new VisualElement { name = "heliLandPointContainer" };
            heliLandPoint.Add(heliLandPointContainer);

            heliLandPoint.Insert(0, new Button(() =>
            {
                var f = NewFoldout("Heli Land Point " + heliLandPointIndex, FONT_SUB, FontStyle.Normal);
                heliLandPointIndex++;

                f.Add(new Button(() => f.RemoveFromHierarchy()) { text = "Remove Heli Land Point" });

                var point = new Fox.EdCore.Vector3Field("point") { name = "point" };
                point.tooltip = "\"point\" is the UI point on the map";
                f.Add(point);

                var startPoint = new Fox.EdCore.Vector3Field("startPoint") { name = "startPoint" };
                startPoint.tooltip = "Player start position used with route";
                f.Add(startPoint);

                var routeId = new TextField("routeId") { name = "routeId" };
                routeId.tooltip = "Route name, must exist in heli route list";
                f.Add(routeId);

                heliLandPointContainer.Add(f);
            })
            { text = "Add Heli Land Point" });

            // heliSpaceFlags (keep references)
            var heliSpaceFlags = NewFoldout("heliSpaceFlags", FONT_SUB, FontStyle.Normal, "Sortie prep feature flags.");
            missionMapParams.Add(heliSpaceFlags);

            flagSkipMissionPrep = new Toggle { text = "SkipMissionPreparetion", tooltip = "No sortie prep, like vanilla Mother Base." };
            flagNoBuddyMenu = new Toggle { text = "NoBuddyMenuFromMissionPreparetion", tooltip = "No buddy select in the sortie." };
            flagNoVehicleMenu = new Toggle { text = "NoVehicleMenuFromMissionPreparetion", tooltip = "No vehicle select in the sortie." };
            flagDisableSortieTime = new Toggle { text = "DisableSelectSortieTimeFromMissionPreparetion", tooltip = "Only ASAP deployment option." };

            heliSpaceFlags.Add(flagSkipMissionPrep);
            heliSpaceFlags.Add(flagNoBuddyMenu);
            heliSpaceFlags.Add(flagNoVehicleMenu);
            heliSpaceFlags.Add(flagDisableSortieTime);
        }

        private void BuildMissionPacksUI()
        {
            missionPacks = NewFoldout("missionPacks", FONT_SECTION, FontStyle.Bold, "packs entry, can be table of fpk names or function of packlist adding calls.");
            scroll.Add(missionPacks);

            packToggles.Clear();
            packPathByKey.Clear();

            CreateCustomPackCategory(missionPacks);

            for (int i = 0; i < PACK_CATEGORIES.Length; i++)
                CreatePackCategory(missionPacks, PACK_CATEGORIES[i]);
        }

        private void CreatePackCategory(Foldout parent, PackCategoryDef def)
        {
            var cat = NewFoldout(def.name, FONT_SUB, FontStyle.Normal, "Category");
            parent.Add(cat);

            var enabled = new Toggle("Enable Category") { value = true };
            cat.Add(enabled);

            var items = new VisualElement();
            cat.Add(items);

            for (int i = 0; i < def.packs.Length; i++)
                AddPackRow(items, def.packs[i].key, def.packs[i].path);

            items.SetEnabled(enabled.value);
            enabled.RegisterValueChangedCallback(e => items.SetEnabled(e.newValue));
        }

        private void AddPackRow(VisualElement parent, string key, string path)
        {
            var row = new VisualElement { style = { flexDirection = FlexDirection.Row, marginBottom = 4 } };

            var t = new Toggle(key) { value = false };
            t.style.minWidth = 220;

            var label = new Label(path);
            label.style.flexGrow = 1;
            label.style.unityTextAlign = TextAnchor.MiddleLeft;

            row.Add(t);
            row.Add(label);
            parent.Add(row);

            if (!packToggles.ContainsKey(key)) packToggles.Add(key, t);
            if (!packPathByKey.ContainsKey(key)) packPathByKey.Add(key, path);
        }

        private void CreateCustomPackCategory(Foldout parent)
        {
            var cat = NewFoldout("CUSTOM_PACKS", FONT_SUB, FontStyle.Normal, "User-defined pack paths.");
            parent.Add(cat);

            var enabled = new Toggle("Enable Category") { value = true };
            cat.Add(enabled);

            cat.Add(new Button(AddCustomPackRow) { text = "Add Custom Pack Path" });

            customPacksItemsContainer = new VisualElement { name = "customPacksItemsContainer" };
            cat.Add(customPacksItemsContainer);

            customPacksItemsContainer.SetEnabled(enabled.value);
            enabled.RegisterValueChangedCallback(e => customPacksItemsContainer.SetEnabled(e.newValue));
        }

        private void AddCustomPackRow()
        {
            string key = "CUSTOM_" + customPackIndex;
            customPackIndex++;

            var row = new VisualElement { style = { flexDirection = FlexDirection.Row, marginBottom = 4 } };

            var t = new Toggle(key) { value = true };
            t.style.minWidth = 220;

            var pathField = new TextField { value = "/Assets/tpp/pack/.../your_pack.fpk", tooltip = "Enter a full .fpk path.", name = "path" };
            pathField.style.flexGrow = 1;

            var removeBtn = new Button(() =>
            {
                row.RemoveFromHierarchy();
                if (packToggles.ContainsKey(key)) packToggles.Remove(key);
                if (customPackPaths.ContainsKey(key)) customPackPaths.Remove(key);
            })
            { text = "X", tooltip = "Remove this custom pack row." };

            row.Add(t);
            row.Add(pathField);
            row.Add(removeBtn);
            customPacksItemsContainer.Add(row);

            if (!packToggles.ContainsKey(key)) packToggles.Add(key, t);
            if (!customPackPaths.ContainsKey(key)) customPackPaths.Add(key, pathField);
        }

        private void ApplyLocationDefaults(string loc)
        {
            SetPackToggle("AFGH_SCRIPT", false);
            SetPackToggle("MAFR_SCRIPT", false);
            SetPackToggle("CYPR_SCRIPT", false);
            SetPackToggle("MTBS_SCRIPT", false);

            SetPackToggle("AFGH_MISSION_AREA", false);
            SetPackToggle("MAFR_MISSION_AREA", false);
            SetPackToggle("MTBS_MISSION_AREA", false);

            SetPackToggle("AFGH_DECOY", false);
            SetPackToggle("MAFR_DECOY", false);
            SetPackToggle("MTBS_DECOY", false);

            if (loc == "AFGH")
            {
                SetPackToggle("AFGH_SCRIPT", true);
                SetPackToggle("AFGH_MISSION_AREA", true);
                SetPackToggle("AFGH_DECOY", true);
            }
            else if (loc == "MAFR")
            {
                SetPackToggle("MAFR_SCRIPT", true);
                SetPackToggle("MAFR_MISSION_AREA", true);
                SetPackToggle("MAFR_DECOY", true);
            }
            else if (loc == "MTBS")
            {
                SetPackToggle("MTBS_SCRIPT", true);
                SetPackToggle("MTBS_MISSION_AREA", true);
                SetPackToggle("MTBS_DECOY", true);
            }
        }

        private void SetPackToggle(string key, bool value)
        {
            if (packToggles.TryGetValue(key, out var t) && t != null)
                t.SetValueWithoutNotify(value);
        }

        private void TryApplyCustomLocation()
        {
            string raw = customLocationField.value;
            if (raw == null) return;

            raw = raw.Trim();
            if (raw.Length == 0) return;

            if (!runtimeLocations.Contains(raw))
            {
                int insertIndex = runtimeLocations.IndexOf(CUSTOM_OPTION);
                if (insertIndex < 0) insertIndex = runtimeLocations.Count;
                runtimeLocations.Insert(insertIndex, raw);
                location.choices = runtimeLocations;
            }

            location.SetValueWithoutNotify(raw);
            customLocationField.SetValueWithoutNotify(string.Empty);
            customLocationField.style.display = DisplayStyle.None;
        }

        private void RefreshOrderBoxUI()
        {
            orderBoxLocatorAddBtn.SetEnabled(orderBoxBlockpathsContainer.childCount > 0);
        }

        private void AddZoneUI(VisualElement zonesContainer, string titlePrefix, ref int zoneIndex)
        {
            var zone = NewFoldout(titlePrefix + " " + zoneIndex, FONT_SUB, FontStyle.Normal);
            zoneIndex++;

            zone.Add(new Button(() => zone.RemoveFromHierarchy()) { text = "Remove Zone" });

            zone.Add(new TextField("name") { name = "name" });

            var verticesFoldout = NewFoldout("vertices", FONT_SUB, FontStyle.Normal);
            zone.Add(verticesFoldout);

            var verticesContainer = new VisualElement { name = "verticesContainer" };
            verticesFoldout.Add(verticesContainer);

            verticesFoldout.Insert(0, new Button(() => AddVertexRow(verticesContainer)) { text = "Add Vertex" });

            zonesContainer.Add(zone);
        }

        private void AddStartPoint(VisualElement container)
        {
            var f = NewFoldout("Start Point " + missionStartPointIndex, FONT_SUB, FontStyle.Normal);
            missionStartPointIndex++;

            f.Add(new Button(() => f.RemoveFromHierarchy()) { text = "Remove Start Point" });

            var pos = new Fox.EdCore.Vector3Field("position") { name = "position" };
            f.Add(pos);

            container.Add(f);
        }

        private void AddVertexRow(VisualElement verticesContainer)
        {
            var row = new VisualElement { style = { flexDirection = FlexDirection.Row, marginBottom = 4 } };

            var v3 = new Fox.EdCore.Vector3Field("Vertex") { name = "vertex" };
            v3.style.flexGrow = 1;

            row.Add(v3);
            row.Add(new Button(() => row.RemoveFromHierarchy()) { text = "X", tooltip = "Remove this vertex" });

            verticesContainer.Add(row);
        }

        private void ExportLuaToFile()
        {
            CommitPendingEdits();

            string lua = BuildLuaString();
            string defaultName = "s" + (missionCode != null ? missionCode.value : MIN_MISSION_CODE) + "_mission.lua";

            string path = EditorUtility.SaveFilePanel("Export Mission Lua", Application.dataPath, defaultName, "lua");
            if (string.IsNullOrEmpty(path)) return;

            System.IO.File.WriteAllText(path, lua);
            Debug.Log("Exported mission lua: " + path);
        }

        private void CommitPendingEdits()
        {
            var panel = rootVisualElement != null ? rootVisualElement.panel : null;
            var focused = panel != null ? panel.focusController.focusedElement as VisualElement : null;
            if (focused != null) focused.Blur();
            rootVisualElement.Focus();
        }

        private string BuildLuaString()
        {
            var sb = new System.Text.StringBuilder(4096);

            ushort mc = missionCode != null ? missionCode.value : MIN_MISSION_CODE;
            string loc = location != null ? location.value : "AFGH";

            sb.AppendLine("-- Auto-generated by FoxKit Mission Creator");
            sb.AppendLine("-- Edit at your own risk :)");
            sb.AppendLine();
            sb.AppendLine("local this={}");

            sb.AppendLine("this.missionCode = " + mc);
            sb.AppendLine("this.location = " + LuaString(loc));
            sb.AppendLine("this.hideMission = " + LuaBool(hideMission != null && hideMission.value));
            sb.AppendLine("this.missionGuaranteeGMP = " + (missionGuaranteeGMP != null ? missionGuaranteeGMP.value : 0));
            sb.AppendLine("this.noAddVolunteers = " + LuaBool(noAddVolunteers != null && noAddVolunteers.value));

            sb.AppendLine("this.missionTasks = {");
            for (int i = 0; i <= MAX_TASK_INDEX; i++)
            {
                var t = taskToggles[i];
                bool on = (t == null) ? true : t.value;
                if (on) sb.AppendLine("\t" + i + ",");
            }
            sb.AppendLine("}");

            sb.AppendLine("this.noArmorForMission = " + LuaBool(noArmorForMission != null && noArmorForMission.value));
            sb.AppendLine("this.missionArmorType = " + (missionArmorType != null ? missionArmorType.value : "TppEnemyBodyId.sva0_v00_a"));

            sb.AppendLine("this.isNoOrderBoxMission = " + LuaBool(isNoOrderBoxMission != null && isNoOrderBoxMission.value));

            sb.AppendLine("this.orderBoxBlockList = {");
            AppendTextFieldList(sb, orderBoxBlockpathsContainer);
            sb.AppendLine("}");

            sb.AppendLine("this.orderBoxList = {");
            AppendTextFieldList(sb, orderBoxLocatorListContainer);
            sb.AppendLine("}");

            sb.AppendLine("this.enableOOB = " + LuaBool(enableOOB == null ? true : enableOOB.value));

            sb.AppendLine("this.missionMapParams = {");

            sb.AppendLine("\tmissionArea2 = {");
            AppendZonesLua(sb, missionArea2ZonesContainer);
            sb.AppendLine("\t},");

            sb.AppendLine("\tsafetyArea2 = {");
            AppendZonesLua(sb, safetyArea2ZonesContainer);
            sb.AppendLine("\t},");

            sb.AppendLine("\tmissionStartPoint = {");
            AppendStartPointsLua(sb, missionStartPointContainer);
            sb.AppendLine("\t},");

            sb.AppendLine("\theliLandPoint = {");
            AppendHeliLandPointsLua(sb, heliLandPointContainer);
            sb.AppendLine("\t},");

            sb.AppendLine("\theliSpaceFlags = {");
            sb.AppendLine("\t\tSkipMissionPreparetion = " + LuaBool(flagSkipMissionPrep != null && flagSkipMissionPrep.value) + ",");
            sb.AppendLine("\t\tNoBuddyMenuFromMissionPreparetion = " + LuaBool(flagNoBuddyMenu != null && flagNoBuddyMenu.value) + ",");
            sb.AppendLine("\t\tNoVehicleMenuFromMissionPreparetion = " + LuaBool(flagNoVehicleMenu != null && flagNoVehicleMenu.value) + ",");
            sb.AppendLine("\t\tDisableSelectSortieTimeFromMissionPreparetion = " + LuaBool(flagDisableSortieTime != null && flagDisableSortieTime.value) + ",");
            sb.AppendLine("\t},");
            sb.AppendLine("}");

            sb.AppendLine("this.packs = function(missionCode)");
            foreach (var p in GetEnabledPackPaths())
                sb.AppendLine("\tTppPackList.AddMissionPack(\"" + p + "\")");
            sb.AppendLine($"\tTppPackList.AddMissionPack(\"/Assets/tpp/pack/mission2/custom_story/s{mc}/area_s{mc}.fpk\")");
            sb.AppendLine("end");
            sb.AppendLine();
            sb.AppendLine("return this");

            return sb.ToString();
        }

        private void AppendTextFieldList(System.Text.StringBuilder sb, VisualElement root)
        {
            if (root == null) return;

            foreach (var child in root.Children())
            {
                if (child is TextField tf)
                {
                    var v = tf.value;
                    if (!string.IsNullOrWhiteSpace(v))
                        sb.AppendLine("\t" + LuaString(v.Trim()) + ",");
                }
            }
        }

        private IEnumerable<string> GetEnabledPackPaths()
        {
            foreach (var kv in packToggles)
            {
                var key = kv.Key;
                var t = kv.Value;
                if (t == null || !t.value) continue;

                if (key.StartsWith("CUSTOM_"))
                {
                    if (customPackPaths.TryGetValue(key, out var tf) && tf != null)
                    {
                        var v = tf.value;
                        if (!string.IsNullOrWhiteSpace(v)) yield return v.Trim();
                    }
                    continue;
                }

                if (packPathByKey.TryGetValue(key, out var path) && !string.IsNullOrWhiteSpace(path))
                    yield return path;
            }
        }

        private void AppendZonesLua(System.Text.StringBuilder sb, VisualElement zonesContainer)
        {
            if (zonesContainer == null) return;

            foreach (var child in zonesContainer.Children())
            {
                if (!(child is Foldout zf)) continue;

                string zoneName = "";
                var nameTf = zf.Q<TextField>("name");
                if (nameTf != null && !string.IsNullOrWhiteSpace(nameTf.value))
                    zoneName = nameTf.value.Trim();

                var verticesContainer = zf.Q<VisualElement>("verticesContainer");

                sb.AppendLine("\t\t{");
                sb.AppendLine("\t\t\tname = " + LuaString(zoneName) + ",");
                sb.AppendLine("\t\t\tvertices = {");

                if (verticesContainer != null)
                {
                    foreach (var vChild in verticesContainer.Children())
                    {
                        var v3 = vChild.Q<Fox.EdCore.Vector3Field>("vertex");
                        if (v3 != null)
                            sb.AppendLine("\t\t\t\t" + LuaVector3(v3) + ",");
                    }
                }

                sb.AppendLine("\t\t\t},");
                sb.AppendLine("\t\t},");
            }
        }

        private void AppendStartPointsLua(System.Text.StringBuilder sb, VisualElement container)
        {
            if (container == null) return;

            foreach (var child in container.Children())
            {
                if (!(child is Foldout f)) continue;

                var v3 = f.Q<Fox.EdCore.Vector3Field>("position");
                if (v3 != null)
                    sb.AppendLine("\t\t" + LuaVector3(v3) + ",");
            }
        }

        private void AppendHeliLandPointsLua(System.Text.StringBuilder sb, VisualElement container)
        {
            if (container == null) return;

            foreach (var child in container.Children())
            {
                if (!(child is Foldout f)) continue;

                var point = f.Q<Fox.EdCore.Vector3Field>("point");
                var startPoint = f.Q<Fox.EdCore.Vector3Field>("startPoint");
                var routeId = f.Q<TextField>("routeId");

                if (point == null || startPoint == null) continue;

                string rid = routeId != null ? routeId.value : "";
                if (rid == null) rid = "";

                sb.AppendLine("\t\t{");
                sb.AppendLine("\t\t\tpoint = " + LuaVector3(point) + ",");
                sb.AppendLine("\t\t\tstartPoint = " + LuaVector3(startPoint) + ",");
                sb.AppendLine("\t\t\trouteId = " + LuaString(rid.Trim()) + ",");
                sb.AppendLine("\t\t},");
            }
        }

        private static Foldout NewFoldout(string text, int headerFontSize, FontStyle headerStyle, string toolTip = null)
        {
            var f = new Foldout { text = text, value = false };
            if (toolTip != null) f.tooltip = toolTip;

            f.style.marginTop = 6;
            f.style.marginBottom = 6;

            ApplyFoldoutHeaderStyle(f, headerFontSize, headerStyle);
            return f;
        }

        private static void ApplyFoldoutHeaderStyle(Foldout foldout, int fontSize, FontStyle style)
        {
            var headerLabel = foldout.Q<Label>(className: "unity-toggle__label");
            if (headerLabel == null) headerLabel = foldout.Q<Label>();
            if (headerLabel == null) return;

            if (fontSize > 0) headerLabel.style.fontSize = fontSize;
            headerLabel.style.unityFontStyleAndWeight = style;
        }

        private static string LuaBool(bool v) => v ? "true" : "false";

        private static string LuaString(string s)
        {
            if (string.IsNullOrEmpty(s)) return "\"\"";
            s = s.Replace("\\", "\\\\").Replace("\"", "\\\"");
            return "\"" + s + "\"";
        }

        private static string LuaVector3(Fox.EdCore.Vector3Field v3)
        {
            Vector3 v = ReadVector3FromUI(v3);
            return "Vector3(" + F(v.x) + "," + F(v.y) + "," + F(v.z) + ")";
        }

        private static string F(float x)
        {
            return x.ToString("0.###", System.Globalization.CultureInfo.InvariantCulture);
        }

        private static Vector3 ReadVector3FromUI(VisualElement ve)
        {
            if (ve == null) return Vector3.zero;

            var floats = new List<FloatField>(3);
            ve.Query<FloatField>().ForEach(ff => { if (floats.Count < 3) floats.Add(ff); });
            if (floats.Count >= 3)
                return new Vector3(floats[0].value, floats[1].value, floats[2].value);

            var doubles = new List<DoubleField>(3);
            ve.Query<DoubleField>().ForEach(df => { if (doubles.Count < 3) doubles.Add(df); });
            if (doubles.Count >= 3)
                return new Vector3((float)doubles[0].value, (float)doubles[1].value, (float)doubles[2].value);

            var texts = new List<TextField>(3);
            ve.Query<TextField>().ForEach(tf => { if (texts.Count < 3) texts.Add(tf); });
            if (texts.Count >= 3)
                return new Vector3(ParseFloat(texts[0].value), ParseFloat(texts[1].value), ParseFloat(texts[2].value));

            return Vector3.zero;
        }

        private static float ParseFloat(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0f;
            s = s.Trim();

            if (float.TryParse(s, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var v))
                return v;

            s = s.Replace(",", ".");
            if (float.TryParse(s, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out v))
                return v;

            return 0f;
        }
    }
}