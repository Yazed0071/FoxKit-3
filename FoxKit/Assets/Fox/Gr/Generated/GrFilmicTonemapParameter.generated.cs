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

namespace Fox.Gr
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("Gr/GrFilmicTonemapParameter")]
	public partial class GrFilmicTonemapParameter : Fox.Gr.GrViewportParameter
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public bool enable { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Vector4[] parameters { get; private set; } = new UnityEngine.Vector4[2];
		
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
		static GrFilmicTonemapParameter()
		{
			if (Fox.Gr.GrViewportParameter.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("GrFilmicTonemapParameter", typeof(GrFilmicTonemapParameter), Fox.Gr.GrViewportParameter.ClassInfo, 0, null, 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("enable", Fox.Core.PropertyInfo.PropertyType.Bool, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("parameters", Fox.Core.PropertyInfo.PropertyType.Vector4, 48, 2, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "enable":
					return new Fox.Core.Value(enable);
				case "parameters":
					return new Fox.Core.Value(parameters);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "parameters":
					return new Fox.Core.Value(this.parameters[index]);
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
				default:
					base.SetProperty(propertyName, value);
					return;
			}
		}

		public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				case "parameters":
					
					this.parameters[index] = value.GetValueAsVector4();
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