using UnityEngine;

namespace Fox.Core
{
    public partial class TransformEntity : Fox.Core.DataElement
    {
        public static TransformEntity GetDefault()
        {
            TransformEntity transform = new GameObject().AddComponent<TransformEntity>();
            transform.translation = Vector3.zero;
            transform.rotQuat = Quaternion.identity;
            transform.scale = Vector3.one;
            transform.name = transform.GetType().Name;

            return transform;
        }

        private partial UnityEngine.Vector3 Get_scale() => transform_scale;
        private partial void Set_scale(UnityEngine.Vector3 value) => transform_scale = value;

        private partial UnityEngine.Quaternion Get_rotQuat() => transform_rotation_quat;
        private partial void Set_rotQuat(UnityEngine.Quaternion value) => transform_rotation_quat = value;

        private partial UnityEngine.Vector3 Get_translation() => transform_translation;
        private partial void Set_translation(UnityEngine.Vector3 value) => transform_translation = value;

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            if (this.transform.parent.GetComponent<TransformData>() is not {} owner)
            {
                // TODO What do we do about orphaned transforms?
                return;
            }

            UnityEngine.Transform ownerTransform = owner.transform;

            Vector3 exportPosition = owner.inheritTransform ? ownerTransform.localPosition : ownerTransform.position;
            Quaternion exportRotation = owner.inheritTransform ? ownerTransform.localRotation : ownerTransform.rotation;
            Vector3 exportScale = owner.inheritTransform ? ownerTransform.localScale : ownerTransform.lossyScale;

            context.OverrideProperty(nameof(transform_translation), Fox.Math.UnityToFoxVector3(exportPosition));
            context.OverrideProperty(nameof(transform_rotation_quat), Fox.Math.UnityToFoxQuaternion(exportRotation));
            context.OverrideProperty(nameof(transform_scale), exportScale);
        }
    }
}