using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteMoveVeryFastEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("MoveVeryFast");
		public override StrCode32 GetId() => Id;

		public static TppRouteMoveVeryFastEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteMoveVeryFastEdgeEvent component = gameObject.AddComponent<TppRouteMoveVeryFastEdgeEvent>(); component.binaryData = binaryData; return component; }
	}
}
