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

namespace Fox.EdDemo
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("EdDemo/ChildrenIdConvertParameter")]
	public partial class ChildrenIdConvertParameter : Fox.Demo.DemoParameter
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public string injuryId { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string yellowHoodId { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string afloId { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string shortAfloId { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string blackCoatId { get; set; }
		
		[field: UnityEngine.SerializeField]
		public byte injuryPriority { get; set; }
		
		[field: UnityEngine.SerializeField]
		public byte yellowHoodPriority { get; set; }
		
		[field: UnityEngine.SerializeField]
		public byte afloPriority { get; set; }
		
		[field: UnityEngine.SerializeField]
		public byte shortAfloPriority { get; set; }
		
		[field: UnityEngine.SerializeField]
		public byte blackCoatPriority { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool enableInjuredChildSpecialization { get; set; }
		
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
		static ChildrenIdConvertParameter()
		{
			if (Fox.Demo.DemoParameter.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("ChildrenIdConvertParameter", typeof(ChildrenIdConvertParameter), Fox.Demo.DemoParameter.ClassInfo, 60, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("injuryId", Fox.Core.PropertyInfo.PropertyType.String, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("yellowHoodId", Fox.Core.PropertyInfo.PropertyType.String, 72, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("afloId", Fox.Core.PropertyInfo.PropertyType.String, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("shortAfloId", Fox.Core.PropertyInfo.PropertyType.String, 88, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("blackCoatId", Fox.Core.PropertyInfo.PropertyType.String, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("injuryPriority", Fox.Core.PropertyInfo.PropertyType.UInt8, 104, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("yellowHoodPriority", Fox.Core.PropertyInfo.PropertyType.UInt8, 105, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("afloPriority", Fox.Core.PropertyInfo.PropertyType.UInt8, 106, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("shortAfloPriority", Fox.Core.PropertyInfo.PropertyType.UInt8, 107, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("blackCoatPriority", Fox.Core.PropertyInfo.PropertyType.UInt8, 108, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("enableInjuredChildSpecialization", Fox.Core.PropertyInfo.PropertyType.Bool, 109, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "injuryId":
					return new Fox.Core.Value(injuryId);
				case "yellowHoodId":
					return new Fox.Core.Value(yellowHoodId);
				case "afloId":
					return new Fox.Core.Value(afloId);
				case "shortAfloId":
					return new Fox.Core.Value(shortAfloId);
				case "blackCoatId":
					return new Fox.Core.Value(blackCoatId);
				case "injuryPriority":
					return new Fox.Core.Value(injuryPriority);
				case "yellowHoodPriority":
					return new Fox.Core.Value(yellowHoodPriority);
				case "afloPriority":
					return new Fox.Core.Value(afloPriority);
				case "shortAfloPriority":
					return new Fox.Core.Value(shortAfloPriority);
				case "blackCoatPriority":
					return new Fox.Core.Value(blackCoatPriority);
				case "enableInjuredChildSpecialization":
					return new Fox.Core.Value(enableInjuredChildSpecialization);
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
				case "injuryId":
					this.injuryId = value.GetValueAsString();
					return;
				case "yellowHoodId":
					this.yellowHoodId = value.GetValueAsString();
					return;
				case "afloId":
					this.afloId = value.GetValueAsString();
					return;
				case "shortAfloId":
					this.shortAfloId = value.GetValueAsString();
					return;
				case "blackCoatId":
					this.blackCoatId = value.GetValueAsString();
					return;
				case "injuryPriority":
					this.injuryPriority = value.GetValueAsUInt8();
					return;
				case "yellowHoodPriority":
					this.yellowHoodPriority = value.GetValueAsUInt8();
					return;
				case "afloPriority":
					this.afloPriority = value.GetValueAsUInt8();
					return;
				case "shortAfloPriority":
					this.shortAfloPriority = value.GetValueAsUInt8();
					return;
				case "blackCoatPriority":
					this.blackCoatPriority = value.GetValueAsUInt8();
					return;
				case "enableInjuredChildSpecialization":
					this.enableInjuredChildSpecialization = value.GetValueAsBool();
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