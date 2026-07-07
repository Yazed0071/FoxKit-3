using Fox.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Graphx
{
    public partial class GraphxSpatialGraphData
    {
        public Matrix4x4 GetGraphWorldMatrix() => Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);

        public Vector3 GetGraphWorldPosition(Vector3 pos) => GetGraphWorldMatrix().MultiplyPoint(pos);

        public Bounds GetWorldBounds()
        {
            if (nodes.Count == 0)
                return new Bounds(transform.position, Vector3.zero);

            var matrix = GetGraphWorldMatrix();
            var bounds = new Bounds(matrix.MultiplyPoint(nodes[0].position), Vector3.zero);
            for (int i = 1; i < nodes.Count; i++)
                bounds.Encapsulate(matrix.MultiplyPoint(nodes[i].position));

            return bounds;
        }

        public bool IsVisibleInFrustum(Camera camera)
        {
            if (camera == null || nodes.Count == 0)
                return true;

            var planes = GeometryUtility.CalculateFrustumPlanes(camera);
            return GeometryUtility.TestPlanesAABB(planes, GetWorldBounds());
        }

        private static readonly Vector3 NodeGizmoScale = Vector3.one * 0.25f;

        private Vector3[] GizmoVertexCache = null;

        private void DrawGizmos(bool isSelected)
        {
            if (nodes.Count == 0 || !IsVisibleInFrustum(Camera.current))
                return;

            Gizmos.matrix = Matrix4x4.identity;
            Gizmos.color = isSelected ? EditorColors.GenericSelectedColor : EditorColors.GenericUnselectedColor;

            if (GizmoVertexCache == null || GizmoVertexCache.Length < nodes.Count)
                GizmoVertexCache = new Vector3[nodes.Count];
            
            var matrix = GetGraphWorldMatrix();
            for (int i = 0; i < nodes.Count; i++)
            {
                Vector3 vertex = matrix.MultiplyPoint(nodes[i].position);
                GizmoVertexCache[i] = vertex;
                Gizmos.DrawWireCube(vertex, NodeGizmoScale);
            }

            Gizmos.DrawLineStrip(GizmoVertexCache, IsLoop());
        }

        public void OnDrawGizmos() => DrawGizmos(false);

        public void OnDrawGizmosSelected() => DrawGizmos(true);

        public virtual Type GetNodeType() => typeof(GraphxSpatialGraphDataNode);
        public virtual Type GetEdgeType() => typeof(GraphxSpatialGraphDataEdge);
        public virtual bool IsLoop() => true;

        public virtual Type GetEdgeEventType() => null;
        public virtual Type GetNodeEventType() => null;

        public virtual void AddNodeEvent(GraphxSpatialGraphDataNode node) { }

        public virtual bool ResolveNodeEvents(GraphxSpatialGraphDataNode node, int fromIndex) => false;

        public virtual void SetNodeEventType(GraphxSpatialGraphDataNode node, int index, string id) { }

        public virtual void SyncEventTemplates() { }
        public virtual UnityEngine.Object GetNodeEventTemplate() => null;
        public virtual UnityEngine.Object GetEdgeEventTemplate() => null;

        public int IndexOf(GraphxSpatialGraphDataNode node)
        {
            return this.nodes.IndexOf(node);
        }

        public GraphxSpatialGraphDataNode GetGraphNode(int index)
        {
            return this.nodes[index];
        }

        public Fox.Graphx.GraphxSpatialGraphDataNode AddNodeAfter(Fox.Graphx.GraphxSpatialGraphDataNode node)
        {
            Undo.RegisterCompleteObjectUndo(this, "Add Node After");

            int index = IndexOf(node);
            if (index < 0)
                throw new System.ArgumentException("Node not found in graph.");

            var newNode = CreateNode();
            var newEdge = CreateEdge();

            ConnectEdge(node, newNode, newEdge);

            HandleSplice(node, newNode, newEdge);

            nodes.Insert(index + 1, newNode);
            edges.Add(newEdge);

            CreateLoopEdge();

            EditorUtility.SetDirty(this);
            return newNode;
        }

        public GraphxSpatialGraphDataNode AddNode()
        {
            if (nodes.Count == 0)
            {
                Undo.RegisterCompleteObjectUndo(this, "Add First Node");

                var first = CreateNode();
                nodes.Add(first);

                EditorUtility.SetDirty(this);
                return first;
            }

            return AddNodeAfter(nodes[nodes.Count - 1]);
        }

        public void RemoveNode(GraphxSpatialGraphDataNode node)
        {
            int index = IndexOf(node);
            if (index < 0)
                return;

            Undo.RegisterCompleteObjectUndo(this, "Remove Node");

            var incoming = edges.FirstOrDefault(e => e.nextNode == node);   // pred -> node
            var outgoing = edges.FirstOrDefault(e => e.prevNode == node);   // node -> succ
            var pred = incoming?.prevNode as GraphxSpatialGraphDataNode;
            var succ = outgoing?.nextNode as GraphxSpatialGraphDataNode;

            if (pred != null && succ != null && pred != succ)
            {
                incoming.nextNode = succ;
                succ.outlinks.Remove(outgoing);
                succ.outlinks.Add(incoming);
                RemoveEdge(outgoing);
            }
            else
            {
                foreach (var edge in edges.Where(e => e.prevNode == node || e.nextNode == node).ToList())
                {
                    (edge.prevNode as GraphxSpatialGraphDataNode)?.outlinks.Remove(edge);
                    (edge.nextNode as GraphxSpatialGraphDataNode)?.outlinks.Remove(edge);
                    RemoveEdge(edge);
                }
            }

            nodes.RemoveAt(index);
            Undo.DestroyObjectImmediate(node.gameObject);

            EditorUtility.SetDirty(this);
        }

        private void RemoveEdge(GraphxSpatialGraphDataEdge edge)
        {
            edges.Remove(edge);
            Undo.DestroyObjectImmediate(edge.gameObject);
        }

        protected virtual void ConnectEdge(
            Fox.Graphx.GraphxSpatialGraphDataNode prev,
            Fox.Graphx.GraphxSpatialGraphDataNode next,
            Fox.Graphx.GraphxSpatialGraphDataEdge edge)
        {
            edge.prevNode = prev;
            edge.nextNode = next;

            prev.outlinks.Add(edge);

            next.outlinks.Add(edge);

            edge.transform.SetParent(next.transform);
        }

        protected virtual void HandleSplice(
            Fox.Graphx.GraphxSpatialGraphDataNode prev,
            Fox.Graphx.GraphxSpatialGraphDataNode inserted,
            Fox.Graphx.GraphxSpatialGraphDataEdge newEdge)
        {
            var existingEdge = edges.FirstOrDefault(e => e.prevNode == prev && e.nextNode != null && e != newEdge);
            if (existingEdge == null)
                return;

            var oldNext = existingEdge.nextNode as Fox.Graphx.GraphxSpatialGraphDataNode;
            existingEdge.prevNode = inserted;

            prev.outlinks.Remove(existingEdge);
            inserted.outlinks.Add(existingEdge);

            if (oldNext != null)
            {
                oldNext.outlinks.Remove(existingEdge);
                oldNext.outlinks.Add(existingEdge);
            }
        }
        protected void CreateLoopEdge()
        {
            var firstNode = nodes.First();
            var lastNode = nodes.Last();

            if (IsLoop() && firstNode.outlinks.Count < 2 && lastNode.outlinks.Count < 2)
            {
                var loopEdge = CreateEdge();

                loopEdge.prevNode = lastNode;
                loopEdge.nextNode = firstNode;
                loopEdge.transform.SetParent(firstNode.transform);

                lastNode.outlinks.Add(loopEdge);
                firstNode.outlinks.Add(loopEdge);

                edges.Add(loopEdge);
            }
        }

        protected Fox.Graphx.GraphxSpatialGraphDataNode CreateNode()
        {
            var newNodeGo = new GameObject();
            Undo.SetTransformParent(newNodeGo.transform, transform, "Set new graph node's parent");
            Undo.RegisterCreatedObjectUndo(newNodeGo, "Added graph node");

            var nodeType = this.GetNodeType();
            var newNode = Undo.AddComponent(newNodeGo, nodeType) as Fox.Graphx.GraphxSpatialGraphDataNode;

            var usedNames = UnityEngine.Object.FindObjectsByType(nodeType, FindObjectsInactive.Include, FindObjectsSortMode.None)
                .Select(ent => ent.name).ToHashSet();
            newNodeGo.name = newNode.GenerateUniqueName(nodeType, usedNames);

            OnNodeCreated(newNode);
            return newNode;
        }

        protected Fox.Graphx.GraphxSpatialGraphDataEdge CreateEdge()
        {
            var newEdgeGo = new GameObject();
            Undo.SetTransformParent(newEdgeGo.transform, transform, "Set new graph edge's parent");
            Undo.RegisterCreatedObjectUndo(newEdgeGo, "Added graph edge");

            var edgeType = GetEdgeType();
            var edge = Undo.AddComponent(newEdgeGo, GetEdgeType()) as Fox.Graphx.GraphxSpatialGraphDataEdge;

            var usedNames = UnityEngine.Object.FindObjectsByType(edgeType, FindObjectsInactive.Include, FindObjectsSortMode.None)
                .Select(ent => ent.name).ToHashSet();
            edge.name = edge.GenerateUniqueName(edgeType, usedNames);

            OnEdgeCreated(edge);
            return edge;
        }

        protected virtual void OnNodeCreated(GraphxSpatialGraphDataNode node) { }
        protected virtual void OnEdgeCreated(GraphxSpatialGraphDataEdge edge) { }
    }
}