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

namespace Tpp.System
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("TppSystem/TppLocationInformationData")]
	public partial class TppLocationInformationData : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public ushort locationId { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string locationPathString { get; set; }
		
		[field: UnityEngine.SerializeField]
		public byte locationType { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Path loadScriptPath { get; set; }
		
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
		static TppLocationInformationData()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppLocationInformationData", typeof(TppLocationInformationData), Fox.Core.Data.ClassInfo, 0, null, 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("locationId", Fox.Core.PropertyInfo.PropertyType.UInt16, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("locationPathString", Fox.Core.PropertyInfo.PropertyType.String, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("locationType", Fox.Core.PropertyInfo.PropertyType.UInt8, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("loadScriptPath", Fox.Core.PropertyInfo.PropertyType.Path, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "locationId":
					return new Fox.Core.Value(locationId);
				case "locationPathString":
					return new Fox.Core.Value(locationPathString);
				case "locationType":
					return new Fox.Core.Value(locationType);
				case "loadScriptPath":
					return new Fox.Core.Value(loadScriptPath);
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
				case "locationId":
					this.locationId = value.GetValueAsUInt16();
					return;
				case "locationPathString":
					this.locationPathString = value.GetValueAsString();
					return;
				case "locationType":
					this.locationType = value.GetValueAsUInt8();
					return;
				case "loadScriptPath":
					this.loadScriptPath = value.GetValueAsPath();
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