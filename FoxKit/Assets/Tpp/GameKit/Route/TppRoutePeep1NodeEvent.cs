using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRoutePeep1NodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("Peep1");
		public override StrCode32 GetId() => Id;

		public static TppRoutePeep1NodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRoutePeep1NodeEvent component = gameObject.AddComponent<TppRoutePeep1NodeEvent>(); component.binaryData = binaryData; return component; }
	}
}
