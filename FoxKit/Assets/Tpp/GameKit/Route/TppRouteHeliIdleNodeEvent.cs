using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteHeliIdleNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("HeliIdle");
		public override StrCode32 GetId() => Id;

		public static TppRouteHeliIdleNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteHeliIdleNodeEvent component = gameObject.AddComponent<TppRouteHeliIdleNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}
