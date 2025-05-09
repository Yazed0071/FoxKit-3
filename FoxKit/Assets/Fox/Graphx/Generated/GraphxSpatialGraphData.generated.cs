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

namespace Fox.Graphx
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("Graphx/GraphxSpatialGraphData")]
	public partial class GraphxSpatialGraphData : Fox.Core.TransformData
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<Fox.Graphx.GraphxSpatialGraphDataNode> nodes { get; private set; } = new CsSystem.Collections.Generic.List<Fox.Graphx.GraphxSpatialGraphDataNode>();
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<Fox.Graphx.GraphxSpatialGraphDataEdge> edges { get; private set; } = new CsSystem.Collections.Generic.List<Fox.Graphx.GraphxSpatialGraphDataEdge>();
		
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
		static GraphxSpatialGraphData()
		{
			if (Fox.Core.TransformData.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("GraphxSpatialGraphData", typeof(GraphxSpatialGraphData), Fox.Core.TransformData.ClassInfo, 0, "Graphx", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("nodes", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 304, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, typeof(Fox.Graphx.GraphxSpatialGraphDataNode), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("edges", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 320, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, typeof(Fox.Graphx.GraphxSpatialGraphDataEdge), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "nodes":
					return new Fox.Core.Value(nodes);
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
				case "nodes":
					return new Fox.Core.Value(this.nodes[index]);
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
				default:
					base.SetProperty(propertyName, value);
					return;
			}
		}

		public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				case "nodes":
					while(this.nodes.Count <= index) { this.nodes.Add(default(Fox.Graphx.GraphxSpatialGraphDataNode)); }
					this.nodes[index] = value.GetValueAsEntityPtr<Fox.Graphx.GraphxSpatialGraphDataNode>();
					return;
				case "edges":
					while(this.edges.Count <= index) { this.edges.Add(default(Fox.Graphx.GraphxSpatialGraphDataEdge)); }
					this.edges[index] = value.GetValueAsEntityPtr<Fox.Graphx.GraphxSpatialGraphDataEdge>();
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