﻿using Fox.Animx;
using UnityEditor;
using Fox.EdCore;
using System.Net.Http.Headers;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using EnumField = Fox.EdCore.EnumField;
using FloatField = Fox.EdCore.FloatField;
using Vector3Field = Fox.EdCore.Vector3Field;

namespace Fox.EdAnimx
{
    [CustomEditor(typeof(RigDriver))]
    public class EntityEditor : UnityEditor.Editor
    {
        private static ObjectField CreateTransformField(string name) => new (name) { objectType = typeof(Transform), allowSceneObjects = true };

        public override VisualElement CreateInspectorGUI()
        {
            var driver = target as RigDriver;

            var root = new VisualElement();

            var typeField = new EnumField("Type"); typeField.bindingPath = "m_Data.Type"; root.Add(typeField);

            var driverContainer = new BindableElement(); driverContainer.bindingPath = "m_Data"; root.Add(driverContainer);
            typeField.RegisterValueChangedCallback(evt =>
            {
                if (evt.previousValue is not null && evt.newValue is not null && !evt.previousValue.Equals(evt.newValue))
                {
                    driverContainer.Clear();
                    DrawDriverFields(driverContainer, target as RigDriver);
                    root.Bind(serializedObject);
                }
            });

            DrawDriverFields(driverContainer, driver);

            root.Bind(serializedObject);

            return root;
        }

        private static void DrawDriverFields(VisualElement root, RigDriver driver)
        {
            switch (driver.data.Type)
            {
                case DriverUnitAction.RotATrn:
                {
                    ObjectField targetField = CreateTransformField("Target"); targetField.bindingPath = targetField.label; root.Add(targetField);
                    ObjectField sourceField = CreateTransformField("Source"); sourceField.bindingPath = sourceField.label; root.Add(sourceField);
                    ObjectField targetParentField = CreateTransformField("TargetParent"); targetParentField.bindingPath = targetParentField.label; root.Add(targetParentField);
                    ObjectField sourceParentField = CreateTransformField("SourceParent"); sourceParentField.bindingPath = sourceParentField.label; root.Add(sourceParentField);

                    var weightField = new FloatField("Weight"); weightField.bindingPath = weightField.label; root.Add(weightField);
                    var limitMinField = new FloatField("LimitMin"); limitMinField.bindingPath = limitMinField.label; root.Add(limitMinField);
                    var limitMaxField = new FloatField("LimitMax"); limitMaxField.bindingPath = limitMaxField.label; root.Add(limitMaxField);

                    var axisField = new EnumField("Axis"); axisField.bindingPath = axisField.label; root.Add(axisField);
                    break;
                }
                case DriverUnitAction.Rot:
                {
                    ObjectField targetField = CreateTransformField("Target"); targetField.bindingPath = targetField.label; root.Add(targetField);
                    ObjectField sourceField = CreateTransformField("Source"); sourceField.bindingPath = sourceField.label; root.Add(sourceField);
                    ObjectField targetParentField = CreateTransformField("TargetParent"); targetParentField.bindingPath = targetParentField.label; root.Add(targetParentField);
                    ObjectField sourceParentField = CreateTransformField("SourceParent"); sourceParentField.bindingPath = sourceParentField.label; root.Add(sourceParentField);

                    var weightField = new FloatField("Weight"); weightField.bindingPath = weightField.label; root.Add(weightField);
                    break;
                }
                case DriverUnitAction.RotATurnRot:
                {
                    ObjectField targetField = CreateTransformField("Target"); targetField.bindingPath = targetField.label; root.Add(targetField);
                    ObjectField sourceField = CreateTransformField("Source"); sourceField.bindingPath = sourceField.label; root.Add(sourceField);
                    ObjectField targetParentField = CreateTransformField("TargetParent"); targetParentField.bindingPath = targetParentField.label; root.Add(targetParentField);
                    ObjectField sourceParentField = CreateTransformField("SourceParent"); sourceParentField.bindingPath = sourceParentField.label; root.Add(sourceParentField);

                    var weightField = new FloatField("Weight"); weightField.bindingPath = weightField.label; root.Add(weightField);
                    var offsetField = new FloatField("Offset"); offsetField.bindingPath = offsetField.label; root.Add(offsetField);
                    var limitMinField = new FloatField("LimitMin"); limitMinField.bindingPath = limitMinField.label; root.Add(limitMinField);
                    var limitMaxField = new FloatField("LimitMax"); limitMaxField.bindingPath = limitMaxField.label; root.Add(limitMaxField);

                    var axisField = new EnumField("Axis"); axisField.bindingPath = axisField.label; root.Add(axisField);
                    var weightBField = new FloatField("WeightB"); weightBField.bindingPath = weightBField.label; root.Add(weightBField);
                    break;
                }
                case DriverUnitAction.BendATrn:
                {
                    ObjectField targetField = CreateTransformField("Target"); targetField.bindingPath = targetField.label; root.Add(targetField);
                    ObjectField sourceField = CreateTransformField("Source"); sourceField.bindingPath = sourceField.label; root.Add(sourceField);
                    ObjectField targetParentField = CreateTransformField("TargetParent"); targetParentField.bindingPath = targetParentField.label; root.Add(targetParentField);
                    ObjectField sourceParentField = CreateTransformField("SourceParent"); sourceParentField.bindingPath = sourceParentField.label; root.Add(sourceParentField);

                    var weightField = new FloatField("Weight"); weightField.bindingPath = weightField.label; root.Add(weightField);
                    var limitMinField = new FloatField("LimitMin"); limitMinField.bindingPath = limitMinField.label; root.Add(limitMinField);
                    var limitMaxField = new FloatField("LimitMax"); limitMaxField.bindingPath = limitMaxField.label; root.Add(limitMaxField);

                    var axisField = new EnumField("Axis"); axisField.bindingPath = axisField.label; root.Add(axisField);
                    break;
                }
                case DriverUnitAction.Bend:
                {
                    ObjectField targetField = CreateTransformField("Target"); targetField.bindingPath = targetField.label; root.Add(targetField);
                    ObjectField sourceField = CreateTransformField("Source"); sourceField.bindingPath = sourceField.label; root.Add(sourceField);
                    ObjectField targetParentField = CreateTransformField("TargetParent"); targetParentField.bindingPath = targetParentField.label; root.Add(targetParentField);
                    ObjectField sourceParentField = CreateTransformField("SourceParent"); sourceParentField.bindingPath = sourceParentField.label; root.Add(sourceParentField);

                    var weightField = new FloatField("Weight"); weightField.bindingPath = weightField.label; root.Add(weightField);

                    var vecAField = new Vector3Field("VectorA"); vecAField.bindingPath = vecAField.label; root.Add(vecAField);
                    break;
                }
                case DriverUnitAction.BendATrnBend:
                {
                    ObjectField targetField = CreateTransformField("Target"); targetField.bindingPath = targetField.label; root.Add(targetField);
                    ObjectField sourceField = CreateTransformField("Source"); sourceField.bindingPath = sourceField.label; root.Add(sourceField);
                    ObjectField targetParentField = CreateTransformField("TargetParent"); targetParentField.bindingPath = targetParentField.label; root.Add(targetParentField);
                    ObjectField sourceParentField = CreateTransformField("SourceParent"); sourceParentField.bindingPath = sourceParentField.label; root.Add(sourceParentField);

                    var weightField = new FloatField("Weight"); weightField.bindingPath = weightField.label; root.Add(weightField);
                    var offsetField = new FloatField("Offset"); offsetField.bindingPath = offsetField.label; root.Add(offsetField);
                    var limitMinField = new FloatField("LimitMin"); limitMinField.bindingPath = limitMinField.label; root.Add(limitMinField);
                    var limitMaxField = new FloatField("LimitMax"); limitMaxField.bindingPath = limitMaxField.label; root.Add(limitMaxField);

                    var axisField = new EnumField("Axis"); axisField.bindingPath = axisField.label; root.Add(axisField);
                    var weightBField = new FloatField("WeightB"); weightBField.bindingPath = weightBField.label; root.Add(weightBField);

                    var vecAField = new Vector3Field("VectorA"); vecAField.bindingPath = vecAField.label; root.Add(vecAField);
                    break;
                }
                case DriverUnitAction.Roll:
                {
                    ObjectField targetField = CreateTransformField("Target"); targetField.bindingPath = targetField.label; root.Add(targetField);
                    ObjectField sourceField = CreateTransformField("Source"); sourceField.bindingPath = sourceField.label; root.Add(sourceField);
                    ObjectField targetParentField = CreateTransformField("TargetParent"); targetParentField.bindingPath = targetParentField.label; root.Add(targetParentField);
                    ObjectField sourceParentField = CreateTransformField("SourceParent"); sourceParentField.bindingPath = sourceParentField.label; root.Add(sourceParentField);

                    var weightField = new FloatField("Weight"); weightField.bindingPath = weightField.label; root.Add(weightField);

                    var vecAField = new Vector3Field("VectorA"); vecAField.bindingPath = vecAField.label; root.Add(vecAField);
                    break;
                }
                case DriverUnitAction.BendRoll:
                {
                    ObjectField targetField = CreateTransformField("Target"); targetField.bindingPath = targetField.label; root.Add(targetField);
                    ObjectField sourceField = CreateTransformField("Source"); sourceField.bindingPath = sourceField.label; root.Add(sourceField);
                    ObjectField targetParentField = CreateTransformField("TargetParent"); targetParentField.bindingPath = targetParentField.label; root.Add(targetParentField);
                    ObjectField sourceParentField = CreateTransformField("SourceParent"); sourceParentField.bindingPath = sourceParentField.label; root.Add(sourceParentField);

                    var weightField = new FloatField("Weight"); weightField.bindingPath = weightField.label; root.Add(weightField);

                    var weightBField = new FloatField("WeightB"); weightBField.bindingPath = weightBField.label; root.Add(weightBField);

                    var vecAField = new Vector3Field("VectorA"); vecAField.bindingPath = vecAField.label; root.Add(vecAField);
                    break;
                }
                case DriverUnitAction.RotRoll:
                {
                    ObjectField targetField = CreateTransformField("Target"); targetField.bindingPath = targetField.label; root.Add(targetField);
                    ObjectField sourceField = CreateTransformField("Source"); sourceField.bindingPath = sourceField.label; root.Add(sourceField);
                    ObjectField source2Field = CreateTransformField("Source2"); source2Field.bindingPath = source2Field.label; root.Add(source2Field);
                    ObjectField targetParentField = CreateTransformField("TargetParent"); targetParentField.bindingPath = targetParentField.label; root.Add(targetParentField);
                    ObjectField sourceParentField = CreateTransformField("SourceParent"); sourceParentField.bindingPath = sourceParentField.label; root.Add(sourceParentField);
                    ObjectField source2ParentField = CreateTransformField("Source2Parent"); source2ParentField.bindingPath = source2ParentField.label; root.Add(source2ParentField);

                    var weightField = new FloatField("Weight"); weightField.bindingPath = weightField.label; root.Add(weightField);

                    var weightBField = new FloatField("WeightB"); weightBField.bindingPath = weightBField.label; root.Add(weightBField);

                    var vecAField = new Vector3Field("VectorA"); vecAField.bindingPath = vecAField.label; root.Add(vecAField);
                    break;
                }
                case DriverUnitAction.PitchL:
                {
                    ObjectField targetField = CreateTransformField("Target"); targetField.bindingPath = targetField.label; root.Add(targetField);
                    ObjectField sourceField = CreateTransformField("Source"); sourceField.bindingPath = sourceField.label; root.Add(sourceField);
                    ObjectField targetParentField = CreateTransformField("TargetParent"); targetParentField.bindingPath = targetParentField.label; root.Add(targetParentField);
                    ObjectField sourceParentField = CreateTransformField("SourceParent"); sourceParentField.bindingPath = sourceParentField.label; root.Add(sourceParentField);

                    var weightField = new FloatField("Weight"); weightField.bindingPath = weightField.label; root.Add(weightField);
                    var limitMinField = new FloatField("LimitMin"); limitMinField.bindingPath = limitMinField.label; root.Add(limitMinField);
                    var limitMaxField = new FloatField("LimitMax"); limitMaxField.bindingPath = limitMaxField.label; root.Add(limitMaxField);

                    var axisField = new EnumField("Axis"); axisField.bindingPath = axisField.label; root.Add(axisField);

                    var vecAField = new Vector3Field("VectorA"); vecAField.bindingPath = vecAField.label; root.Add(vecAField);
                    var vecBField = new Vector3Field("VectorB"); vecBField.bindingPath = vecBField.label; root.Add(vecBField);
                    break;
                }
                case DriverUnitAction.PitchA:
                {
                    ObjectField targetField = CreateTransformField("Target"); targetField.bindingPath = targetField.label; root.Add(targetField);
                    ObjectField sourceField = CreateTransformField("Source"); sourceField.bindingPath = sourceField.label; root.Add(sourceField);
                    ObjectField targetParentField = CreateTransformField("TargetParent"); targetParentField.bindingPath = targetParentField.label; root.Add(targetParentField);
                    ObjectField sourceParentField = CreateTransformField("SourceParent"); sourceParentField.bindingPath = sourceParentField.label; root.Add(sourceParentField);

                    var weightField = new FloatField("Weight"); weightField.bindingPath = weightField.label; root.Add(weightField);
                    var limitMinField = new FloatField("LimitMin"); limitMinField.bindingPath = limitMinField.label; root.Add(limitMinField);
                    var limitMaxField = new FloatField("LimitMax"); limitMaxField.bindingPath = limitMaxField.label; root.Add(limitMaxField);

                    var axisField = new EnumField("Axis"); axisField.bindingPath = axisField.label; root.Add(axisField);

                    var vecAField = new Vector3Field("VectorA"); vecAField.bindingPath = vecAField.label; root.Add(vecAField);
                    var vecBField = new Vector3Field("VectorB"); vecBField.bindingPath = vecBField.label; root.Add(vecBField);
                    break;
                }
                case DriverUnitAction.RollPitchL:
                {
                    ObjectField targetField = CreateTransformField("Target"); targetField.bindingPath = targetField.label; root.Add(targetField);
                    ObjectField sourceField = CreateTransformField("Source"); sourceField.bindingPath = sourceField.label; root.Add(sourceField);
                    ObjectField targetParentField = CreateTransformField("TargetParent"); targetParentField.bindingPath = targetParentField.label; root.Add(targetParentField);
                    ObjectField sourceParentField = CreateTransformField("SourceParent"); sourceParentField.bindingPath = sourceParentField.label; root.Add(sourceParentField);

                    var weightField = new FloatField("Weight"); weightField.bindingPath = weightField.label; root.Add(weightField);

                    var weightBField = new FloatField("WeightB"); weightBField.bindingPath = weightBField.label; root.Add(weightBField);
                    var limitMinBField = new FloatField("LimitMinB"); limitMinBField.bindingPath = limitMinBField.label; root.Add(limitMinBField);
                    var limitMaxBField = new FloatField("LimitMaxB"); limitMaxBField.bindingPath = limitMaxBField.label; root.Add(limitMaxBField);
                    var axisBField = new EnumField("AxisB"); axisBField.bindingPath = axisBField.label; root.Add(axisBField);

                    var vecAField = new Vector3Field("VectorA"); vecAField.bindingPath = vecAField.label; root.Add(vecAField);
                    var vecBField = new Vector3Field("VectorB"); vecBField.bindingPath = vecBField.label; root.Add(vecBField);
                    break;
                }
                case DriverUnitAction.YawAPitchL:
                {
                    ObjectField targetField = CreateTransformField("Target"); targetField.bindingPath = targetField.label; root.Add(targetField);
                    ObjectField sourceField = CreateTransformField("Source"); sourceField.bindingPath = sourceField.label; root.Add(sourceField);
                    ObjectField targetParentField = CreateTransformField("TargetParent"); targetParentField.bindingPath = targetParentField.label; root.Add(targetParentField);
                    ObjectField sourceParentField = CreateTransformField("SourceParent"); sourceParentField.bindingPath = sourceParentField.label; root.Add(sourceParentField);

                    var weightField = new FloatField("Weight"); weightField.bindingPath = weightField.label; root.Add(weightField);
                    var limitMinField = new FloatField("LimitMin"); limitMinField.bindingPath = limitMinField.label; root.Add(limitMinField);
                    var limitMaxField = new FloatField("LimitMax"); limitMaxField.bindingPath = limitMaxField.label; root.Add(limitMaxField);

                    var axisField = new EnumField("Axis"); axisField.bindingPath = axisField.label; root.Add(axisField);
                    var weightBField = new FloatField("WeightB"); weightBField.bindingPath = weightBField.label; root.Add(weightBField);
                    var limitMinBField = new FloatField("LimitMinB"); limitMinBField.bindingPath = limitMinBField.label; root.Add(limitMinBField);
                    var limitMaxBField = new FloatField("LimitMaxB"); limitMaxBField.bindingPath = limitMaxBField.label; root.Add(limitMaxBField);
                    var axisBField = new EnumField("AxisB"); axisBField.bindingPath = axisBField.label; root.Add(axisBField);

                    var vecAField = new Vector3Field("VectorA"); vecAField.bindingPath = vecAField.label; root.Add(vecAField);
                    var vecBField = new Vector3Field("VectorB"); vecBField.bindingPath = vecBField.label; root.Add(vecBField);
                    break;
                }
                case DriverUnitAction.YawAPitchA:
                {
                    ObjectField targetField = CreateTransformField("Target"); targetField.bindingPath = targetField.label; root.Add(targetField);
                    ObjectField sourceField = CreateTransformField("Source"); sourceField.bindingPath = sourceField.label; root.Add(sourceField);
                    ObjectField targetParentField = CreateTransformField("TargetParent"); targetParentField.bindingPath = targetParentField.label; root.Add(targetParentField);
                    ObjectField sourceParentField = CreateTransformField("SourceParent"); sourceParentField.bindingPath = sourceParentField.label; root.Add(sourceParentField);

                    var weightField = new FloatField("Weight"); weightField.bindingPath = weightField.label; root.Add(weightField);
                    var limitMinField = new FloatField("LimitMin"); limitMinField.bindingPath = limitMinField.label; root.Add(limitMinField);
                    var limitMaxField = new FloatField("LimitMax"); limitMaxField.bindingPath = limitMaxField.label; root.Add(limitMaxField);

                    var axisField = new EnumField("Axis"); axisField.bindingPath = axisField.label; root.Add(axisField);
                    var weightBField = new FloatField("WeightB"); weightBField.bindingPath = weightBField.label; root.Add(weightBField);
                    var limitMinBField = new FloatField("LimitMinB"); limitMinBField.bindingPath = limitMinBField.label; root.Add(limitMinBField);
                    var limitMaxBField = new FloatField("LimitMaxB"); limitMaxBField.bindingPath = limitMaxBField.label; root.Add(limitMaxBField);
                    var axisBField = new EnumField("AxisB"); axisBField.bindingPath = axisBField.label; root.Add(axisBField);
                    var unknownBoolField = new BoolField("Type14Bool"); unknownBoolField.bindingPath = unknownBoolField.label; root.Add(unknownBoolField);
                    var unknownEnumField = new EnumField("Type14Enum"); unknownEnumField.bindingPath = unknownEnumField.label; root.Add(unknownEnumField);

                    var vecAField = new Vector3Field("VectorA"); vecAField.bindingPath = vecAField.label; root.Add(vecAField);
                    var vecBField = new Vector3Field("VectorB"); vecBField.bindingPath = vecBField.label; root.Add(vecBField);
                    break;
                }
                case DriverUnitAction.Dircns:
                {
                    ObjectField targetField = CreateTransformField("Target"); targetField.bindingPath = targetField.label; root.Add(targetField);
                    ObjectField sourceField = CreateTransformField("Source"); sourceField.bindingPath = sourceField.label; root.Add(sourceField);
                    ObjectField source2Field = CreateTransformField("Source2"); source2Field.bindingPath = source2Field.label; root.Add(source2Field);
                    ObjectField targetParentField = CreateTransformField("TargetParent"); targetParentField.bindingPath = targetParentField.label; root.Add(targetParentField);

                    var vecAField = new Vector3Field("VectorA"); vecAField.bindingPath = vecAField.label; root.Add(vecAField);
                    var vecBField = new Vector3Field("VectorB"); vecBField.bindingPath = vecBField.label; root.Add(vecBField);
                    var vecCField = new Vector3Field("VectorC"); vecCField.bindingPath = vecCField.label; root.Add(vecCField);
                    var vecDField = new Vector3Field("VectorD"); vecDField.bindingPath = vecDField.label; root.Add(vecDField);
                    break;
                }
                case DriverUnitAction.Swell:
                {
                    ObjectField targetField = CreateTransformField("Target"); targetField.bindingPath = targetField.label; root.Add(targetField);
                    ObjectField sourceField = CreateTransformField("Source"); sourceField.bindingPath = sourceField.label; root.Add(sourceField);
                    ObjectField targetParentField = CreateTransformField("TargetParent"); targetParentField.bindingPath = targetParentField.label; root.Add(targetParentField);
                    ObjectField sourceParentField = CreateTransformField("SourceParent"); sourceParentField.bindingPath = sourceParentField.label; root.Add(sourceParentField);

                    var vecAField = new Vector3Field("VectorA"); vecAField.bindingPath = vecAField.label; root.Add(vecAField);
                    var vecBField = new Vector3Field("VectorB"); vecBField.bindingPath = vecBField.label; root.Add(vecBField);

                    break;
                }
                case DriverUnitAction.SwellRot:
                {
                    ObjectField targetField = CreateTransformField("Target"); targetField.bindingPath = targetField.label; root.Add(targetField);
                    ObjectField sourceField = CreateTransformField("Source"); sourceField.bindingPath = sourceField.label; root.Add(sourceField);
                    ObjectField targetParentField = CreateTransformField("TargetParent"); targetParentField.bindingPath = targetParentField.label; root.Add(targetParentField);
                    ObjectField sourceParentField = CreateTransformField("SourceParent"); sourceParentField.bindingPath = sourceParentField.label; root.Add(sourceParentField);

                    var weightField = new FloatField("Weight"); weightField.bindingPath = weightField.label; root.Add(weightField);

                    var vecAField = new Vector3Field("VectorA"); vecAField.bindingPath = vecAField.label; root.Add(vecAField);
                    var vecBField = new Vector3Field("VectorB"); vecBField.bindingPath = vecBField.label; root.Add(vecBField);
                    break;
                }
                case DriverUnitAction.SwellRot_Copy:
                {
                    ObjectField targetField = CreateTransformField("Target"); targetField.bindingPath = targetField.label; root.Add(targetField);
                    ObjectField sourceField = CreateTransformField("Source"); sourceField.bindingPath = sourceField.label; root.Add(sourceField);
                    ObjectField targetParentField = CreateTransformField("TargetParent"); targetParentField.bindingPath = targetParentField.label; root.Add(targetParentField);
                    ObjectField sourceParentField = CreateTransformField("SourceParent"); sourceParentField.bindingPath = sourceParentField.label; root.Add(sourceParentField);

                    var weightField = new FloatField("Weight"); weightField.bindingPath = weightField.label; root.Add(weightField);

                    var vecAField = new Vector3Field("VectorA"); vecAField.bindingPath = vecAField.label; root.Add(vecAField);
                    var vecBField = new Vector3Field("VectorB"); vecBField.bindingPath = vecBField.label; root.Add(vecBField);
                    break;
                }
                case DriverUnitAction.PitchASwitchLinear:
                {
                    ObjectField sourceField = CreateTransformField("Source"); sourceField.bindingPath = sourceField.label; root.Add(sourceField);
                    ObjectField sourceParentField = CreateTransformField("SourceParent"); sourceParentField.bindingPath = sourceParentField.label; root.Add(sourceParentField);

                    var weightField = new FloatField("Weight"); weightField.bindingPath = weightField.label; root.Add(weightField);
                    var limitMinField = new FloatField("LimitMin"); limitMinField.bindingPath = limitMinField.label; root.Add(limitMinField);
                    var limitMaxField = new FloatField("LimitMax"); limitMaxField.bindingPath = limitMaxField.label; root.Add(limitMaxField);

                    var materialNameAField = new StringField("MaterialNameA"); materialNameAField.bindingPath = materialNameAField.label; root.Add(materialNameAField);
                    var materialParamAField = new StringField("MaterialParameterA"); materialParamAField.bindingPath = materialParamAField.label; root.Add(materialParamAField);
                    var materialNameBField = new StringField("MaterialNameB"); materialNameBField.bindingPath = materialNameBField.label; root.Add(materialNameBField);
                    var materialParamBField = new StringField("MaterialParameterB"); materialParamBField.bindingPath = materialParamBField.label; root.Add(materialParamBField);

                    var vecAField = new Vector3Field("VectorA"); vecAField.bindingPath = vecAField.label; root.Add(vecAField);
                    var vecBField = new Vector3Field("VectorB"); vecBField.bindingPath = vecBField.label; root.Add(vecBField);
                    var vecCField = new Vector3Field("VectorC"); vecCField.bindingPath = vecCField.label; root.Add(vecCField);
                    var vecDField = new Vector3Field("VectorD"); vecDField.bindingPath = vecDField.label; root.Add(vecDField);
                    break;
                }
                case DriverUnitAction.ParamSwitchAbs:
                {
                    var weightField = new FloatField("Weight"); weightField.bindingPath = weightField.label; root.Add(weightField);
                    var limitMinField = new FloatField("LimitMin"); limitMinField.bindingPath = limitMinField.label; root.Add(limitMinField);
                    var limitMaxField = new FloatField("LimitMax"); limitMaxField.bindingPath = limitMaxField.label; root.Add(limitMaxField);

                    var materialNameAField = new StringField("MaterialNameA"); materialNameAField.bindingPath = materialNameAField.label; root.Add(materialNameAField);
                    var materialParamAField = new StringField("MaterialParameterA"); materialParamAField.bindingPath = materialParamAField.label; root.Add(materialParamAField);
                    var materialNameBField = new StringField("MaterialNameB"); materialNameBField.bindingPath = materialNameBField.label; root.Add(materialNameBField);
                    var materialParamBField = new StringField("MaterialParameterB"); materialParamBField.bindingPath = materialParamBField.label; root.Add(materialParamBField);
                    var materialNameCField = new StringField("MaterialNameC"); materialNameCField.bindingPath = materialNameCField.label; root.Add(materialNameCField);
                    var materialParamCField = new StringField("MaterialParameterC"); materialParamCField.bindingPath = materialParamCField.label; root.Add(materialParamCField);
                    break;
                }
                case DriverUnitAction.PitchACycle:
                {
                    ObjectField sourceField = CreateTransformField("Source"); sourceField.bindingPath = sourceField.label; root.Add(sourceField);
                    ObjectField sourceParentField = CreateTransformField("SourceParent"); sourceParentField.bindingPath = sourceParentField.label; root.Add(sourceParentField);

                    var limitMinField = new FloatField("LimitMin"); limitMinField.bindingPath = limitMinField.label; root.Add(limitMinField);
                    var limitMaxField = new FloatField("LimitMax"); limitMaxField.bindingPath = limitMaxField.label; root.Add(limitMaxField);

                    var materialNameAField = new StringField("MaterialNameA"); materialNameAField.bindingPath = materialNameAField.label; root.Add(materialNameAField);
                    var materialParamAField = new StringField("MaterialParameterA"); materialParamAField.bindingPath = materialParamAField.label; root.Add(materialParamAField);

                    var vecAField = new Vector3Field("VectorA"); vecAField.bindingPath = vecAField.label; root.Add(vecAField);
                    var vecBField = new Vector3Field("VectorB"); vecBField.bindingPath = vecBField.label; root.Add(vecBField);
                    break;
                }
                case DriverUnitAction.Mirror:
                {
                    ObjectField targetField = CreateTransformField("Target"); targetField.bindingPath = targetField.label; root.Add(targetField);
                    ObjectField sourceField = CreateTransformField("Source"); sourceField.bindingPath = sourceField.label; root.Add(sourceField);
                    ObjectField targetParentField = CreateTransformField("TargetParent"); targetParentField.bindingPath = targetParentField.label; root.Add(targetParentField);
                    ObjectField sourceParentField = CreateTransformField("SourceParent"); sourceParentField.bindingPath = sourceParentField.label; root.Add(sourceParentField);

                    break;
                }
                case DriverUnitAction.PitchALinearParam:
                {
                    ObjectField sourceField = CreateTransformField("Source"); sourceField.bindingPath = sourceField.label; root.Add(sourceField);
                    ObjectField sourceParentField = CreateTransformField("SourceParent"); sourceParentField.bindingPath = sourceParentField.label; root.Add(sourceParentField);

                    var weightField = new FloatField("Weight"); weightField.bindingPath = weightField.label; root.Add(weightField);
                    var offsetField = new FloatField("Offset"); offsetField.bindingPath = offsetField.label; root.Add(offsetField);
                    var limitMinField = new FloatField("LimitMin"); limitMinField.bindingPath = limitMinField.label; root.Add(limitMinField);
                    var limitMaxField = new FloatField("LimitMax"); limitMaxField.bindingPath = limitMaxField.label; root.Add(limitMaxField);

                    var vecAField = new Vector3Field("VectorA"); vecAField.bindingPath = vecAField.label; root.Add(vecAField);
                    var vecBField = new Vector3Field("VectorB"); vecBField.bindingPath = vecBField.label; root.Add(vecBField);
                    break;
                }
            }
        }
    }
}