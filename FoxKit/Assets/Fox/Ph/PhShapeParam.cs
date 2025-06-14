﻿using System;
using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhShapeParam : Fox.Core.Entity
    {
        internal UnityEngine.Vector3 GetOffset() => offset;
        internal void SetOffset(UnityEngine.Vector3 value) => offset = value;

        internal UnityEngine.Quaternion GetRotation() => rotation;
        internal void SetRotation(UnityEngine.Quaternion value) => rotation = value.normalized;

        internal UnityEngine.Vector3 GetSize() => size;
        internal void SetSize(UnityEngine.Vector3 value) => size = value;

        public void OnValidate()
        {
            rotation = rotation.normalized;
        }

        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            offset = Fox.Math.FoxToUnityVector3(offset);
            rotation = Fox.Math.FoxToUnityQuaternion(rotation);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(offset), Fox.Math.UnityToFoxVector3(offset));
            context.OverrideProperty(nameof(rotation), Fox.Math.UnityToFoxQuaternion(rotation));
        }

        internal virtual void DrawGizmos()
        {
        }
    }
}