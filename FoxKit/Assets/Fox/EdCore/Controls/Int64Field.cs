﻿using Fox.Core;
using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class Int64Field : TextValueField<long>, IFoxField
    {
        private Int64Input integerInput => (Int64Input)textInputBase;

        protected override string ValueToString(long v) => v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);

        protected override long StringToValue(string str)
        {
            _ = ExpressionEvaluator.Evaluate(str, out System.Numerics.BigInteger v);
            return NumericPropertyFields.ClampToInt64(v);
        }

        public static new readonly string ussClassName = "fox-int64-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public Int64Field()
            : this(label: null)
        {
        }
        
        public Int64Field(bool hasDragger)
            : this(label: null, hasDragger)
        {
        }
        
        public Int64Field(PropertyInfo propertyInfo, bool hasDragger = true, int maxLength = -1)
            : this(propertyInfo.Name, hasDragger, maxLength)
        {
        }

        public Int64Field(string label, bool hasDragger = true, int maxLength = -1)
            : this(label, hasDragger, maxLength, new Int64Input())
        {
        }

        private Int64Field(string label, bool hasDragger, int maxLength, TextValueInput visInput)
            : base(label, maxLength, visInput)
        {
            visualInput = visInput;

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<long>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, long startValue) => integerInput.ApplyInputDeviceDelta(delta, speed, startValue);

        private class Int64Input : TextValueInput
        {
            private Int64Field parentIntegerField => (Int64Field)parent;

            internal Int64Input()
            {
                formatString = "#################0";
            }

            protected override string allowedCharacters => NumericPropertyFields.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, long startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                System.Numerics.BigInteger v = StringToValue(text);
                v += (System.Numerics.BigInteger)System.Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyFields.ClampToInt64(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyFields.ClampToInt64(v);
                }
            }

            protected override string ValueToString(long v) => v.ToString(formatString);

            protected override long StringToValue(string str)
            {
                _ = ExpressionEvaluator.Evaluate(str, out System.Numerics.BigInteger v);
                return NumericPropertyFields.ClampToInt64(v);
            }
        }
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }
}