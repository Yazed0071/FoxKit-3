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

namespace Tpp.GameCore
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("TppGameCore/TppPlayer2BlockControllerConfiguration")]
	public partial class TppPlayer2BlockControllerConfiguration 
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public uint commonMotionBlockSize { get; set; }
		
		[field: UnityEngine.SerializeField]
		public uint commonMotionBlockSizePs3 { get; set; }
		
		[field: UnityEngine.SerializeField]
		public uint additiveMotionBlockCount { get; set; }
		
		[field: UnityEngine.SerializeField]
		public uint additiveMotionBlockSize { get; set; }
		
		[field: UnityEngine.SerializeField]
		public uint partsBlockCount { get; set; }
		
		[field: UnityEngine.SerializeField]
		public uint partsBlockSize { get; set; }
		
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
		static TppPlayer2BlockControllerConfiguration()
		{
			classInfo = new Fox.Core.EntityInfo("TppPlayer2BlockControllerConfiguration", typeof(TppPlayer2BlockControllerConfiguration), null, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("commonMotionBlockSize", Fox.Core.PropertyInfo.PropertyType.UInt32, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("commonMotionBlockSizePs3", Fox.Core.PropertyInfo.PropertyType.UInt32, 4, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("additiveMotionBlockCount", Fox.Core.PropertyInfo.PropertyType.UInt32, 8, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("additiveMotionBlockSize", Fox.Core.PropertyInfo.PropertyType.UInt32, 12, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("partsBlockCount", Fox.Core.PropertyInfo.PropertyType.UInt32, 16, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("partsBlockSize", Fox.Core.PropertyInfo.PropertyType.UInt32, 20, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public virtual Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "commonMotionBlockSize":
					return new Fox.Core.Value(commonMotionBlockSize);
				case "commonMotionBlockSizePs3":
					return new Fox.Core.Value(commonMotionBlockSizePs3);
				case "additiveMotionBlockCount":
					return new Fox.Core.Value(additiveMotionBlockCount);
				case "additiveMotionBlockSize":
					return new Fox.Core.Value(additiveMotionBlockSize);
				case "partsBlockCount":
					return new Fox.Core.Value(partsBlockCount);
				case "partsBlockSize":
					return new Fox.Core.Value(partsBlockSize);
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
				case "commonMotionBlockSize":
					this.commonMotionBlockSize = value.GetValueAsUInt32();
					return;
				case "commonMotionBlockSizePs3":
					this.commonMotionBlockSizePs3 = value.GetValueAsUInt32();
					return;
				case "additiveMotionBlockCount":
					this.additiveMotionBlockCount = value.GetValueAsUInt32();
					return;
				case "additiveMotionBlockSize":
					this.additiveMotionBlockSize = value.GetValueAsUInt32();
					return;
				case "partsBlockCount":
					this.partsBlockCount = value.GetValueAsUInt32();
					return;
				case "partsBlockSize":
					this.partsBlockSize = value.GetValueAsUInt32();
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