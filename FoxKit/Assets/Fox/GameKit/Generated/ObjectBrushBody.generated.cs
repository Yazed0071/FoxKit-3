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

namespace Fox.GameKit
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("FoxGameKit/ObjectBrushBody")]
	public partial class ObjectBrushBody : Fox.Core.TransformDataBody
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<Fox.Core.Entity> pluginBodyHandle { get; private set; } = new CsSystem.Collections.Generic.List<Fox.Core.Entity>();
		
		[field: UnityEngine.SerializeField]
		public uint numPlugins { get; set; }
		
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
		static ObjectBrushBody()
		{
			if (Fox.Core.TransformDataBody.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("ObjectBrushBody", typeof(ObjectBrushBody), Fox.Core.TransformDataBody.ClassInfo, 0, "ObjectBrush", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("pluginBodyHandle", Fox.Core.PropertyInfo.PropertyType.EntityHandle, 144, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("numPlugins", Fox.Core.PropertyInfo.PropertyType.UInt32, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "pluginBodyHandle":
					return new Fox.Core.Value(pluginBodyHandle);
				case "numPlugins":
					return new Fox.Core.Value(numPlugins);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "pluginBodyHandle":
					return new Fox.Core.Value(this.pluginBodyHandle[index]);
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
				case "numPlugins":
					this.numPlugins = value.GetValueAsUInt32();
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
				case "pluginBodyHandle":
					while(this.pluginBodyHandle.Count <= index) { this.pluginBodyHandle.Add(default(Fox.Core.Entity)); }
					this.pluginBodyHandle[index] = value.GetValueAsEntityHandle();
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