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
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("Sdx/SoundDataFileInfo")]
	public partial class SoundDataFileInfo : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<string> loadBanks { get; private set; } = new CsSystem.Collections.Generic.List<string>();
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<string> prepareBanks { get; private set; } = new CsSystem.Collections.Generic.List<string>();
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<string> prepareEvents { get; private set; } = new CsSystem.Collections.Generic.List<string>();
		
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
		static SoundDataFileInfo()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("SoundDataFileInfo", typeof(SoundDataFileInfo), Fox.Core.Data.ClassInfo, 112, "Sound", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("loadBanks", Fox.Core.PropertyInfo.PropertyType.String, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("prepareBanks", Fox.Core.PropertyInfo.PropertyType.String, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("prepareEvents", Fox.Core.PropertyInfo.PropertyType.String, 152, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "loadBanks":
					return new Fox.Core.Value(loadBanks);
				case "prepareBanks":
					return new Fox.Core.Value(prepareBanks);
				case "prepareEvents":
					return new Fox.Core.Value(prepareEvents);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "loadBanks":
					return new Fox.Core.Value(this.loadBanks[index]);
				case "prepareBanks":
					return new Fox.Core.Value(this.prepareBanks[index]);
				case "prepareEvents":
					return new Fox.Core.Value(this.prepareEvents[index]);
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
				default:
					base.SetProperty(propertyName, value);
					return;
			}
		}

		public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				case "loadBanks":
					while(this.loadBanks.Count <= index) { this.loadBanks.Add(default(string)); }
					this.loadBanks[index] = value.GetValueAsString();
					return;
				case "prepareBanks":
					while(this.prepareBanks.Count <= index) { this.prepareBanks.Add(default(string)); }
					this.prepareBanks[index] = value.GetValueAsString();
					return;
				case "prepareEvents":
					while(this.prepareEvents.Count <= index) { this.prepareEvents.Add(default(string)); }
					this.prepareEvents[index] = value.GetValueAsString();
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