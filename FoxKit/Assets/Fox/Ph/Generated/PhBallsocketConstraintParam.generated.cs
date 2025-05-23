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

namespace Fox.Ph
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("Ph/PhBallsocketConstraintParam")]
	public partial class PhBallsocketConstraintParam : Fox.Ph.PhConstraintParam
	{
		// Properties
		[field: UnityEngine.SerializeField]
		protected bool limitedFlag { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected UnityEngine.Vector3 refA { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected UnityEngine.Vector3 refB { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected float limit { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected bool springFlag { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected bool springRefCustomFlag { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected UnityEngine.Vector3 springRef { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected float springConstant { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected float flexibility { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected bool stopTwistFlag { get; set; }
		
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
		static PhBallsocketConstraintParam()
		{
			if (Fox.Ph.PhConstraintParam.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("PhBallsocketConstraintParam", typeof(PhBallsocketConstraintParam), Fox.Ph.PhConstraintParam.ClassInfo, 112, "Ph", 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("limitedFlag", Fox.Core.PropertyInfo.PropertyType.Bool, 124, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("refA", Fox.Core.PropertyInfo.PropertyType.Vector3, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("refB", Fox.Core.PropertyInfo.PropertyType.Vector3, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("limit", Fox.Core.PropertyInfo.PropertyType.Float, 112, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("springFlag", Fox.Core.PropertyInfo.PropertyType.Bool, 125, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("springRefCustomFlag", Fox.Core.PropertyInfo.PropertyType.Bool, 126, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("springRef", Fox.Core.PropertyInfo.PropertyType.Vector3, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("springConstant", Fox.Core.PropertyInfo.PropertyType.Float, 116, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("flexibility", Fox.Core.PropertyInfo.PropertyType.Float, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("stopTwistFlag", Fox.Core.PropertyInfo.PropertyType.Bool, 127, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "limitedFlag":
					return new Fox.Core.Value(limitedFlag);
				case "refA":
					return new Fox.Core.Value(refA);
				case "refB":
					return new Fox.Core.Value(refB);
				case "limit":
					return new Fox.Core.Value(limit);
				case "springFlag":
					return new Fox.Core.Value(springFlag);
				case "springRefCustomFlag":
					return new Fox.Core.Value(springRefCustomFlag);
				case "springRef":
					return new Fox.Core.Value(springRef);
				case "springConstant":
					return new Fox.Core.Value(springConstant);
				case "flexibility":
					return new Fox.Core.Value(flexibility);
				case "stopTwistFlag":
					return new Fox.Core.Value(stopTwistFlag);
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
				case "limitedFlag":
					this.limitedFlag = value.GetValueAsBool();
					return;
				case "refA":
					this.refA = value.GetValueAsVector3();
					return;
				case "refB":
					this.refB = value.GetValueAsVector3();
					return;
				case "limit":
					this.limit = value.GetValueAsFloat();
					return;
				case "springFlag":
					this.springFlag = value.GetValueAsBool();
					return;
				case "springRefCustomFlag":
					this.springRefCustomFlag = value.GetValueAsBool();
					return;
				case "springRef":
					this.springRef = value.GetValueAsVector3();
					return;
				case "springConstant":
					this.springConstant = value.GetValueAsFloat();
					return;
				case "flexibility":
					this.flexibility = value.GetValueAsFloat();
					return;
				case "stopTwistFlag":
					this.stopTwistFlag = value.GetValueAsBool();
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