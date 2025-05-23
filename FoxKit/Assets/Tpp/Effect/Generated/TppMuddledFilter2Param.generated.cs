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
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("TppEffect/TppMuddledFilter2Param")]
	public partial class TppMuddledFilter2Param 
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public float widthMin { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float widthMax { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float lifeMin { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float lifeMax { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float deltaAngleMin { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float deltaAngleMax { get; set; }
		
		// ClassInfos
		public static  bool ClassInfoInitialized = false;
		private static Fox.Core.EntityInfo classInfo;
		public static  Fox.Core.EntityInfo ClassInfo
		{
			get
			{
				return classInfo;
			}
		}
		public virtual Fox.Core.EntityInfo GetClassEntityInfo()
		{
			return classInfo;
		}
		static TppMuddledFilter2Param()
		{
			classInfo = new Fox.Core.EntityInfo("TppMuddledFilter2Param", typeof(TppMuddledFilter2Param), null, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("widthMin", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("widthMax", Fox.Core.PropertyInfo.PropertyType.Float, 4, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lifeMin", Fox.Core.PropertyInfo.PropertyType.Float, 8, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lifeMax", Fox.Core.PropertyInfo.PropertyType.Float, 12, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("deltaAngleMin", Fox.Core.PropertyInfo.PropertyType.Float, 16, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("deltaAngleMax", Fox.Core.PropertyInfo.PropertyType.Float, 20, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public virtual Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "widthMin":
					return new Fox.Core.Value(widthMin);
				case "widthMax":
					return new Fox.Core.Value(widthMax);
				case "lifeMin":
					return new Fox.Core.Value(lifeMin);
				case "lifeMax":
					return new Fox.Core.Value(lifeMax);
				case "deltaAngleMin":
					return new Fox.Core.Value(deltaAngleMin);
				case "deltaAngleMax":
					return new Fox.Core.Value(deltaAngleMax);
				default:
					throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
			}
		}

		public virtual Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				default:
					throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
			}
		}

		public virtual Fox.Core.Value GetPropertyElement(string propertyName, string key)
		{
			switch (propertyName)
			{
				default:
					throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
			}
		}

		public virtual void SetProperty(string propertyName, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				case "widthMin":
					this.widthMin = value.GetValueAsFloat();
					return;
				case "widthMax":
					this.widthMax = value.GetValueAsFloat();
					return;
				case "lifeMin":
					this.lifeMin = value.GetValueAsFloat();
					return;
				case "lifeMax":
					this.lifeMax = value.GetValueAsFloat();
					return;
				case "deltaAngleMin":
					this.deltaAngleMin = value.GetValueAsFloat();
					return;
				case "deltaAngleMax":
					this.deltaAngleMax = value.GetValueAsFloat();
					return;
				default:
					throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
			}
		}

		public virtual void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				default:
					throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
			}
		}

		public virtual void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				default:
					throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
			}
		}
	}
}