using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteJumpOnlyEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("JumpOnly");
		public override StrCode32 GetId() => Id;

		public static TppRouteJumpOnlyEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteJumpOnlyEdgeEvent component = gameObject.AddComponent<TppRouteJumpOnlyEdgeEvent>(); component.binaryData = binaryData; return component; }
	}
}
