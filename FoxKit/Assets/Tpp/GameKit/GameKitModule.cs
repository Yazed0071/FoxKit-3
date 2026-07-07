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
            GameServiceModule.RegisterRouteNodeEventType(new StrCode32("SendMessage"), typeof(TppRouteNodeEventSendMessage));
            GameServiceModule.RegisterRouteNodeEventType(new StrCode32("SwitchRoute"), typeof(TppRouteNodeEventSwitchRoute));
            GameServiceModule.RegisterRouteNodeEventType(new StrCode32("SyncRoute"), typeof(TppRouteNodeEventSyncRoute));
            GameServiceModule.RegisterRouteNodeEventType(new StrCode32("RelaxedIdleAct"), typeof(TppRouteNodeEventRelaxedIdleAct));
            GameServiceModule.RegisterRouteNodeEventType(new StrCode32("CautionIdleAct"), typeof(TppRouteNodeEventCautionIdleAct));
            GameServiceModule.RegisterRouteNodeEventType(new StrCode32("ConversationIdle"), typeof(TppRouteNodeEventConversationIdle));
            GameServiceModule.RegisterRouteNodeEventType(new StrCode32("PutHostageInVehicle"), typeof(TppRouteNodeEventPutHostageInVehicle));
            GameServiceModule.RegisterRouteNodeEventType(new StrCode32("TakeHostageOutOfVehicle"), typeof(TppRouteNodeEventTakeHostageOutOfVehicle));

            GameServiceModule.RegisterRouteEdgeEventType(new StrCode32("Move"), typeof(TppRouteEdgeEventMove));
            GameServiceModule.RegisterRouteEdgeEventType(new StrCode32("VehicleMoveSlow"), typeof(TppRouteEdgeEventVehicleMoveSlow));
            GameServiceModule.RegisterRouteEdgeEventType(new StrCode32("VehicleMoveNormal"), typeof(TppRouteEdgeEventVehicleMoveNormal));
            GameServiceModule.RegisterRouteEdgeEventType(new StrCode32("VehicleMoveFast"), typeof(TppRouteEdgeEventVehicleMoveFast));
            GameServiceModule.RegisterRouteEdgeEventType(new StrCode32("VehicleBackSlow"), typeof(TppRouteEdgeEventVehicleBackSlow));
            GameServiceModule.RegisterRouteEdgeEventType(new StrCode32("VehicleBackNormal"), typeof(TppRouteEdgeEventVehicleBackNormal));
            GameServiceModule.RegisterRouteEdgeEventType(new StrCode32("VehicleBackFast"), typeof(TppRouteEdgeEventVehicleBackFast));
            GameServiceModule.RegisterRouteEdgeEventType(new StrCode32("VehicleKmPerHour"), typeof(TppRouteEdgeEventVehicleKmPerHour));
        }
    }
}
