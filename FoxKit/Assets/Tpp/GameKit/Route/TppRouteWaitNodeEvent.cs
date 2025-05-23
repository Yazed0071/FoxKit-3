using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteWaitNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("Wait");
		public override StrCode32 GetId() => Id;

		public static TppRouteWaitNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteWaitNodeEvent component = gameObject.AddComponent<TppRouteWaitNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}
