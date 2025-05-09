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

namespace Fox.Ui
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("Ui/UiEdgeDataBody")]
	public partial class UiEdgeDataBody : Fox.Core.DataBody
	{
		// Properties
		[field: UnityEngine.SerializeField]
		protected Fox.Core.Entity sourcePort { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected int sourcePortType { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected int sourcePortIndex { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected Fox.Core.Entity targetPort { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected int targetPortType { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected int targetPortIndex { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected bool isConnect { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected bool isVirtual { get; set; }
		
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
		static UiEdgeDataBody()
		{
			if (Fox.Core.DataBody.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("UiEdgeDataBody", typeof(UiEdgeDataBody), Fox.Core.DataBody.ClassInfo, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("sourcePort", Fox.Core.PropertyInfo.PropertyType.EntityHandle, 88, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("sourcePortType", Fox.Core.PropertyInfo.PropertyType.Int32, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("sourcePortIndex", Fox.Core.PropertyInfo.PropertyType.Int32, 100, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("targetPort", Fox.Core.PropertyInfo.PropertyType.EntityHandle, 104, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("targetPortType", Fox.Core.PropertyInfo.PropertyType.Int32, 112, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("targetPortIndex", Fox.Core.PropertyInfo.PropertyType.Int32, 116, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isConnect", Fox.Core.PropertyInfo.PropertyType.Bool, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isVirtual", Fox.Core.PropertyInfo.PropertyType.Bool, 121, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "sourcePort":
					return new Fox.Core.Value(sourcePort);
				case "sourcePortType":
					return new Fox.Core.Value(sourcePortType);
				case "sourcePortIndex":
					return new Fox.Core.Value(sourcePortIndex);
				case "targetPort":
					return new Fox.Core.Value(targetPort);
				case "targetPortType":
					return new Fox.Core.Value(targetPortType);
				case "targetPortIndex":
					return new Fox.Core.Value(targetPortIndex);
				case "isConnect":
					return new Fox.Core.Value(isConnect);
				case "isVirtual":
					return new Fox.Core.Value(isVirtual);
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
				case "sourcePort":
					this.sourcePort = value.GetValueAsEntityHandle();
					return;
				case "sourcePortType":
					this.sourcePortType = value.GetValueAsInt32();
					return;
				case "sourcePortIndex":
					this.sourcePortIndex = value.GetValueAsInt32();
					return;
				case "targetPort":
					this.targetPort = value.GetValueAsEntityHandle();
					return;
				case "targetPortType":
					this.targetPortType = value.GetValueAsInt32();
					return;
				case "targetPortIndex":
					this.targetPortIndex = value.GetValueAsInt32();
					return;
				case "isConnect":
					this.isConnect = value.GetValueAsBool();
					return;
				case "isVirtual":
					this.isVirtual = value.GetValueAsBool();
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