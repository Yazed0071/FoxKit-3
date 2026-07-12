using Fox;
using Fox.Core.Utils;
using UnityEngine;

namespace Tpp.GameKit
{
	public partial class TppRouteNodeEventTakeHostageOutOfVehicle
	{
		public override void OnDeserializeEntity(TaskLogger logger)
		{
			base.OnDeserializeEntity(logger);

			unknown = extensions[0];

			message = HashingBitConverter.ToStrCode32(extensions[1]).ToString();
			
			Debug.Assert(extensions[2] == 0 && extensions[3] == 0);
		}
	}
}