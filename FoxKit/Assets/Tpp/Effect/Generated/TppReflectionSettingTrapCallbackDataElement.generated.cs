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

namespace Tpp.Effect
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("TppEffect/TppReflectionSettingTrapCallbackDataElement")]
	public partial class TppReflectionSettingTrapCallbackDataElement : Fox.Geo.GeoTrapModuleCallbackDataElement
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Path reflectionTexturePath { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Path reflectionTexturePathForGoOut { get; set; }
		
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
		static TppReflectionSettingTrapCallbackDataElement()
		{
			if (Fox.Geo.GeoTrapModuleCallbackDataElement.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppReflectionSettingTrapCallbackDataElement", typeof(TppReflectionSettingTrapCallbackDataElement), Fox.Geo.GeoTrapModuleCallbackDataElement.ClassInfo, 48, null, 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("reflectionTexturePath", Fox.Core.PropertyInfo.PropertyType.Path, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("reflectionTexturePathForGoOut", Fox.Core.PropertyInfo.PropertyType.Path, 72, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "reflectionTexturePath":
					return new Fox.Core.Value(reflectionTexturePath);
				case "reflectionTexturePathForGoOut":
					return new Fox.Core.Value(reflectionTexturePathForGoOut);
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
				case "reflectionTexturePath":
					this.reflectionTexturePath = value.GetValueAsPath();
					return;
				case "reflectionTexturePathForGoOut":
					this.reflectionTexturePathForGoOut = value.GetValueAsPath();
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