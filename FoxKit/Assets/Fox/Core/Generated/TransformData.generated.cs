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

namespace Fox.Core
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("FoxCore/TransformData")]
	public partial class TransformData : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		private Fox.Core.Entity parent { get; set; }
		
		[field: UnityEngine.SerializeField]
		private new Fox.Core.TransformEntity transform { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.ShearTransformEntity shearTransform { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.PivotTransformEntity pivotTransform { get; set; }
		
		[field: UnityEngine.SerializeField]
		private CsSystem.Collections.Generic.List<Fox.Core.Entity> children { get; set; } = new CsSystem.Collections.Generic.List<Fox.Core.Entity>();
		
		[field: UnityEngine.SerializeField]
		protected TransformData_Flags flags { get; set; }
		
		public bool inheritTransform { get => Get_inheritTransform(); set { Set_inheritTransform(value); } }
		private partial bool Get_inheritTransform();
		private partial void Set_inheritTransform(bool value);
		
		public bool visibility { get => Get_visibility(); set { Set_visibility(value); } }
		private partial bool Get_visibility();
		private partial void Set_visibility(bool value);
		
		public bool selection { get => Get_selection(); set { Set_selection(value); } }
		private partial bool Get_selection();
		private partial void Set_selection(bool value);
		
		public UnityEngine.Matrix4x4 worldMatrix { get => Get_worldMatrix(); }
		private partial UnityEngine.Matrix4x4 Get_worldMatrix();
		
		public UnityEngine.Matrix4x4 worldTransform { get => Get_worldTransform(); }
		private partial UnityEngine.Matrix4x4 Get_worldTransform();
		
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
		static TransformData()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TransformData", typeof(TransformData), Fox.Core.Data.ClassInfo, 0, null, 4);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("parent", Fox.Core.PropertyInfo.PropertyType.EntityHandle, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("transform", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Core.TransformEntity), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("shearTransform", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Core.ShearTransformEntity), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("pivotTransform", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Core.PivotTransformEntity), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("children", Fox.Core.PropertyInfo.PropertyType.EntityHandle, 152, 1, Fox.Core.PropertyInfo.ContainerType.List, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("flags", Fox.Core.PropertyInfo.PropertyType.UInt32, 184, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, typeof(TransformData_Flags), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("inheritTransform", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("visibility", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("selection", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("worldMatrix", Fox.Core.PropertyInfo.PropertyType.Matrix4, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("worldTransform", Fox.Core.PropertyInfo.PropertyType.Matrix4, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "parent":
					return new Fox.Core.Value(parent);
				case "transform":
					return new Fox.Core.Value(transform);
				case "shearTransform":
					return new Fox.Core.Value(shearTransform);
				case "pivotTransform":
					return new Fox.Core.Value(pivotTransform);
				case "children":
					return new Fox.Core.Value(children);
				case "flags":
					return new Fox.Core.Value(flags);
				case "inheritTransform":
					return new Fox.Core.Value(inheritTransform);
				case "visibility":
					return new Fox.Core.Value(visibility);
				case "selection":
					return new Fox.Core.Value(selection);
				case "worldMatrix":
					return new Fox.Core.Value(worldMatrix);
				case "worldTransform":
					return new Fox.Core.Value(worldTransform);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "children":
					return new Fox.Core.Value(this.children[index]);
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
				case "parent":
					this.parent = value.GetValueAsEntityHandle();
					return;
				case "transform":
					this.transform = value.GetValueAsEntityPtr<Fox.Core.TransformEntity>();
					return;
				case "shearTransform":
					this.shearTransform = value.GetValueAsEntityPtr<Fox.Core.ShearTransformEntity>();
					return;
				case "pivotTransform":
					this.pivotTransform = value.GetValueAsEntityPtr<Fox.Core.PivotTransformEntity>();
					return;
				case "flags":
					this.flags = (TransformData_Flags)value.GetValueAsUInt32();
					return;
				case "inheritTransform":
					this.inheritTransform = value.GetValueAsBool();
					return;
				case "visibility":
					this.visibility = value.GetValueAsBool();
					return;
				case "selection":
					this.selection = value.GetValueAsBool();
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
				case "children":
					while(this.children.Count <= index) { this.children.Add(default(Fox.Core.Entity)); }
					this.children[index] = value.GetValueAsEntityHandle();
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