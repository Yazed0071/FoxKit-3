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

namespace Fox.Sdx
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("Sdx/SoundAreaGroup")]
	public partial class SoundAreaGroup : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public uint priority { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Sdx.SoundAreaParameter parameter { get; set; }
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<Fox.Core.EntityLink> members { get; private set; } = new CsSystem.Collections.Generic.List<Fox.Core.EntityLink>();
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<Fox.Core.EntityLink> edges { get; private set; } = new CsSystem.Collections.Generic.List<Fox.Core.EntityLink>();
		
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
		static SoundAreaGroup()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("SoundAreaGroup", typeof(SoundAreaGroup), Fox.Core.Data.ClassInfo, 112, "Sound", 3);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("priority", Fox.Core.PropertyInfo.PropertyType.UInt32, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("parameter", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Sdx.SoundAreaParameter), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("members", Fox.Core.PropertyInfo.PropertyType.EntityLink, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("edges", Fox.Core.PropertyInfo.PropertyType.EntityLink, 152, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "priority":
					return new Fox.Core.Value(priority);
				case "parameter":
					return new Fox.Core.Value(parameter);
				case "members":
					return new Fox.Core.Value(members);
				case "edges":
					return new Fox.Core.Value(edges);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "members":
					return new Fox.Core.Value(this.members[index]);
				case "edges":
					return new Fox.Core.Value(this.edges[index]);
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
				case "priority":
					this.priority = value.GetValueAsUInt32();
					return;
				case "parameter":
					this.parameter = value.GetValueAsEntityPtr<Fox.Sdx.SoundAreaParameter>();
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
				case "members":
					while(this.members.Count <= index) { this.members.Add(default(Fox.Core.EntityLink)); }
					this.members[index] = value.GetValueAsEntityLink();
					return;
				case "edges":
					while(this.edges.Count <= index) { this.edges.Add(default(Fox.Core.EntityLink)); }
					this.edges[index] = value.GetValueAsEntityLink();
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