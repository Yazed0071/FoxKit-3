using Fox;
using Fox.GameService;

namespace Tpp.GameKit
{
    public class GameKitModule : Module
    {
        public static GameKitModule Instance { get; private set; }

        public GameKitModule() : base("Tpp.GameKit")
        {
            Instance = this;
            AddDependencyModule("Fox.GameService");
        }

        public override void Init()
        {
            GameServiceModule.RegisterRouteNodeEventType("SendMessage", typeof(TppRouteNodeEventSendMessage));
            GameServiceModule.RegisterRouteNodeEventType("SwitchRoute", typeof(TppRouteNodeEventSwitchRoute));
            GameServiceModule.RegisterRouteNodeEventType("SyncRoute", typeof(TppRouteNodeEventSyncRoute));
            GameServiceModule.RegisterRouteNodeEventType("RelaxedIdleAct", typeof(TppRouteNodeEventRelaxedIdleAct));
            GameServiceModule.RegisterRouteNodeEventType("CautionIdleAct", typeof(TppRouteNodeEventCautionIdleAct));
            GameServiceModule.RegisterRouteNodeEventType("ConversationIdle", typeof(TppRouteNodeEventConversationIdle));
            GameServiceModule.RegisterRouteNodeEventType("PutHostageInVehicle", typeof(TppRouteNodeEventPutHostageInVehicle));
            GameServiceModule.RegisterRouteNodeEventType("TakeHostageOutOfVehicle", typeof(TppRouteNodeEventTakeHostageOutOfVehicle));

            GameServiceModule.RegisterRouteEdgeEventType("Move", typeof(TppRouteEdgeEventMove));
            GameServiceModule.RegisterRouteEdgeEventType("VehicleMoveSlow", typeof(TppRouteEdgeEventVehicleMoveSlow));
            GameServiceModule.RegisterRouteEdgeEventType("VehicleMoveNormal", typeof(TppRouteEdgeEventVehicleMoveNormal));
            GameServiceModule.RegisterRouteEdgeEventType("VehicleMoveFast", typeof(TppRouteEdgeEventVehicleMoveFast));
            GameServiceModule.RegisterRouteEdgeEventType("VehicleBackSlow", typeof(TppRouteEdgeEventVehicleBackSlow));
            GameServiceModule.RegisterRouteEdgeEventType("VehicleBackNormal", typeof(TppRouteEdgeEventVehicleBackNormal));
            GameServiceModule.RegisterRouteEdgeEventType("VehicleBackFast", typeof(TppRouteEdgeEventVehicleBackFast));
            GameServiceModule.RegisterRouteEdgeEventType("VehicleKmPerHour", typeof(TppRouteEdgeEventVehicleKmPerHour));
        }
    }
}
