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

namespace Tpp.GameKit
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("TppGameKit/TppObjectBrushPluginBush")]
	public partial class TppObjectBrushPluginBush : Fox.GameKit.ObjectBrushPluginClone
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public uint reservedCount { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float upgradeLodRateForHighEnd { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Tpp.GameKit.ObjectBrushPluginBushDataElement gimmickParameter { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink externalGimmickParameter { get; set; }
		
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
		static TppObjectBrushPluginBush()
		{
			if (Fox.GameKit.ObjectBrushPluginClone.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppObjectBrushPluginBush", typeof(TppObjectBrushPluginBush), Fox.GameKit.ObjectBrushPluginClone.ClassInfo, 168, null, 3);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("reservedCount", Fox.Core.PropertyInfo.PropertyType.UInt32, 184, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("upgradeLodRateForHighEnd", Fox.Core.PropertyInfo.PropertyType.Float, 188, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("gimmickParameter", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Tpp.GameKit.ObjectBrushPluginBushDataElement), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("externalGimmickParameter", Fox.Core.PropertyInfo.PropertyType.EntityLink, 200, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "reservedCount":
					return new Fox.Core.Value(reservedCount);
				case "upgradeLodRateForHighEnd":
					return new Fox.Core.Value(upgradeLodRateForHighEnd);
				case "gimmickParameter":
					return new Fox.Core.Value(gimmickParameter);
				case "externalGimmickParameter":
					return new Fox.Core.Value(externalGimmickParameter);
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
				case "reservedCount":
					this.reservedCount = value.GetValueAsUInt32();
					return;
				case "upgradeLodRateForHighEnd":
					this.upgradeLodRateForHighEnd = value.GetValueAsFloat();
					return;
				case "gimmickParameter":
					this.gimmickParameter = value.GetValueAsEntityPtr<Tpp.GameKit.ObjectBrushPluginBushDataElement>();
					return;
				case "externalGimmickParameter":
					this.externalGimmickParameter = value.GetValueAsEntityLink();
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