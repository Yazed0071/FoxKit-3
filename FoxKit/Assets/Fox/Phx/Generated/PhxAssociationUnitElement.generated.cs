//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using CsSystem = System;
using Fox;

namespace Fox.Phx
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("Phx/PhxAssociationUnitElement")]
	public partial class PhxAssociationUnitElement : Fox.Core.DataElement
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink body { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink constraint { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Vector3 bodyOffsetPos { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Vector3 constraintOffsetPos { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Quaternion offsetRot { get; set; }
		
		// ClassInfos
		public static new bool ClassInfoInitialized = false;
		private static Fox.Core.EntityInfo classInfo;
		public static new Fox.Core.EntityInfo ClassInfo
		{
			get
			{
				return classInfo;
			}
		}
		public override Fox.Core.EntityInfo GetClassEntityInfo()
		{
			return classInfo;
		}
		static PhxAssociationUnitElement()
		{
			if (Fox.Core.DataElement.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("PhxAssociationUnitElement", typeof(PhxAssociationUnitElement), Fox.Core.DataElement.ClassInfo, 144, "Phx", 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("body", Fox.Core.PropertyInfo.PropertyType.EntityLink, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("constraint", Fox.Core.PropertyInfo.PropertyType.EntityLink, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("bodyOffsetPos", Fox.Core.PropertyInfo.PropertyType.Vector3, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("constraintOffsetPos", Fox.Core.PropertyInfo.PropertyType.Vector3, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("offsetRot", Fox.Core.PropertyInfo.PropertyType.Quat, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "body":
					return new Fox.Core.Value(body);
				case "constraint":
					return new Fox.Core.Value(constraint);
				case "bodyOffsetPos":
					return new Fox.Core.Value(bodyOffsetPos);
				case "constraintOffsetPos":
					return new Fox.Core.Value(constraintOffsetPos);
				case "offsetRot":
					return new Fox.Core.Value(offsetRot);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				default:
					return base.GetPropertyElement(propertyName, index);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, string key)
		{
			switch (propertyName)
			{
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(string propertyName, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				case "body":
					this.body = value.GetValueAsEntityLink();
					return;
				case "constraint":
					this.constraint = value.GetValueAsEntityLink();
					return;
				case "bodyOffsetPos":
					this.bodyOffsetPos = value.GetValueAsVector3();
					return;
				case "constraintOffsetPos":
					this.constraintOffsetPos = value.GetValueAsVector3();
					return;
				case "offsetRot":
					this.offsetRot = value.GetValueAsQuat();
					return;
				default:
					base.SetProperty(propertyName, value);
					return;
			}
		}

		public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				default:
					base.SetPropertyElement(propertyName, index, value);
					return;
			}
		}

		public override void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}