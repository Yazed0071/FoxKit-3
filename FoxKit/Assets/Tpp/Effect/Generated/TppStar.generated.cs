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
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("TppEffect/TppStar")]
	public partial class TppStar : Fox.Core.TransformData
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public bool enable { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Color color { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float intensity { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float direction { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string bgModelName { get; set; }
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<string> modelNameArray { get; private set; } = new CsSystem.Collections.Generic.List<string>();
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<string> nameArray { get; private set; } = new CsSystem.Collections.Generic.List<string>();
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<float> latitudeArray { get; private set; } = new CsSystem.Collections.Generic.List<float>();
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<float> longitudeArray { get; private set; } = new CsSystem.Collections.Generic.List<float>();
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<float> scaleArray { get; private set; } = new CsSystem.Collections.Generic.List<float>();
		
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
		static TppStar()
		{
			if (Fox.Core.TransformData.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppStar", typeof(TppStar), Fox.Core.TransformData.ClassInfo, 384, "TppEffect", 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("enable", Fox.Core.PropertyInfo.PropertyType.Bool, 424, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("color", Fox.Core.PropertyInfo.PropertyType.Color, 400, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("intensity", Fox.Core.PropertyInfo.PropertyType.Float, 416, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("direction", Fox.Core.PropertyInfo.PropertyType.Float, 420, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("bgModelName", Fox.Core.PropertyInfo.PropertyType.String, 384, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("modelNameArray", Fox.Core.PropertyInfo.PropertyType.String, 320, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("nameArray", Fox.Core.PropertyInfo.PropertyType.String, 304, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("latitudeArray", Fox.Core.PropertyInfo.PropertyType.Float, 336, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("longitudeArray", Fox.Core.PropertyInfo.PropertyType.Float, 352, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("scaleArray", Fox.Core.PropertyInfo.PropertyType.Float, 368, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "enable":
					return new Fox.Core.Value(enable);
				case "color":
					return new Fox.Core.Value(color);
				case "intensity":
					return new Fox.Core.Value(intensity);
				case "direction":
					return new Fox.Core.Value(direction);
				case "bgModelName":
					return new Fox.Core.Value(bgModelName);
				case "modelNameArray":
					return new Fox.Core.Value(modelNameArray);
				case "nameArray":
					return new Fox.Core.Value(nameArray);
				case "latitudeArray":
					return new Fox.Core.Value(latitudeArray);
				case "longitudeArray":
					return new Fox.Core.Value(longitudeArray);
				case "scaleArray":
					return new Fox.Core.Value(scaleArray);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "modelNameArray":
					return new Fox.Core.Value(this.modelNameArray[index]);
				case "nameArray":
					return new Fox.Core.Value(this.nameArray[index]);
				case "latitudeArray":
					return new Fox.Core.Value(this.latitudeArray[index]);
				case "longitudeArray":
					return new Fox.Core.Value(this.longitudeArray[index]);
				case "scaleArray":
					return new Fox.Core.Value(this.scaleArray[index]);
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
				case "enable":
					this.enable = value.GetValueAsBool();
					return;
				case "color":
					this.color = value.GetValueAsColor();
					return;
				case "intensity":
					this.intensity = value.GetValueAsFloat();
					return;
				case "direction":
					this.direction = value.GetValueAsFloat();
					return;
				case "bgModelName":
					this.bgModelName = value.GetValueAsString();
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
				case "modelNameArray":
					while(this.modelNameArray.Count <= index) { this.modelNameArray.Add(default(string)); }
					this.modelNameArray[index] = value.GetValueAsString();
					return;
				case "nameArray":
					while(this.nameArray.Count <= index) { this.nameArray.Add(default(string)); }
					this.nameArray[index] = value.GetValueAsString();
					return;
				case "latitudeArray":
					while(this.latitudeArray.Count <= index) { this.latitudeArray.Add(default(float)); }
					this.latitudeArray[index] = value.GetValueAsFloat();
					return;
				case "longitudeArray":
					while(this.longitudeArray.Count <= index) { this.longitudeArray.Add(default(float)); }
					this.longitudeArray[index] = value.GetValueAsFloat();
					return;
				case "scaleArray":
					while(this.scaleArray.Count <= index) { this.scaleArray.Add(default(float)); }
					this.scaleArray[index] = value.GetValueAsFloat();
					return;
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