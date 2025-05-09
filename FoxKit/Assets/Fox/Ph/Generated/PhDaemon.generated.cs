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

namespace Fox.Ph
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("Ph/PhDaemon")]
	public partial class PhDaemon : Fox.Core.Entity
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Ph.PhMaterialManager materialManager { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float defaultFriction { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float defaultRestitution { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool isParallel { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool isUseSmallJob { get; set; }
		
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
		static PhDaemon()
		{
			if (Fox.Core.Entity.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("PhDaemon", typeof(PhDaemon), Fox.Core.Entity.ClassInfo, 0, "Ph", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("materialManager", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 240, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, typeof(Fox.Ph.PhMaterialManager), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("defaultFriction", Fox.Core.PropertyInfo.PropertyType.Float, 200, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("defaultRestitution", Fox.Core.PropertyInfo.PropertyType.Float, 204, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isParallel", Fox.Core.PropertyInfo.PropertyType.Bool, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isUseSmallJob", Fox.Core.PropertyInfo.PropertyType.Bool, 209, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "materialManager":
					return new Fox.Core.Value(materialManager);
				case "defaultFriction":
					return new Fox.Core.Value(defaultFriction);
				case "defaultRestitution":
					return new Fox.Core.Value(defaultRestitution);
				case "isParallel":
					return new Fox.Core.Value(isParallel);
				case "isUseSmallJob":
					return new Fox.Core.Value(isUseSmallJob);
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
				case "materialManager":
					this.materialManager = value.GetValueAsEntityPtr<Fox.Ph.PhMaterialManager>();
					return;
				case "defaultFriction":
					this.defaultFriction = value.GetValueAsFloat();
					return;
				case "defaultRestitution":
					this.defaultRestitution = value.GetValueAsFloat();
					return;
				case "isParallel":
					this.isParallel = value.GetValueAsBool();
					return;
				case "isUseSmallJob":
					this.isUseSmallJob = value.GetValueAsBool();
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