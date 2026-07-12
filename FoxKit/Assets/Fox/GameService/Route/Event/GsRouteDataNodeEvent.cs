using Fox.Core.Utils;

namespace Fox.GameService
{
	public partial class GsRouteDataNodeEvent
	{
		public override void OnDeserializeEntity(TaskLogger logger)
		{
			base.OnDeserializeEntity(logger);

			dir = Fox.Math.FoxToUnityQuaternion(dir);
		}
	}
}