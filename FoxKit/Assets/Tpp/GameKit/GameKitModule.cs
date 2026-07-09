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
            GameServiceModule.RegisterRouteNodeEventTypeOverride(new StrCode32("SendMessage"), typeof(TppRouteNodeEventSendMessage));
            GameServiceModule.RegisterRouteNodeEventTypeOverride(new StrCode32("SwitchRoute"), typeof(TppRouteNodeEventSwitchRoute));
            GameServiceModule.RegisterRouteNodeEventTypeOverride(new StrCode32("SyncRoute"), typeof(TppRouteNodeEventSyncRoute));
            GameServiceModule.RegisterRouteNodeEventTypeOverride(new StrCode32("RelaxedIdleAct"), typeof(TppRouteNodeEventRelaxedIdleAct));
            GameServiceModule.RegisterRouteNodeEventTypeOverride(new StrCode32("CautionIdleAct"), typeof(TppRouteNodeEventCautionIdleAct));
            GameServiceModule.RegisterRouteNodeEventTypeOverride(new StrCode32("ConversationIdle"), typeof(TppRouteNodeEventConversationIdle));
            GameServiceModule.RegisterRouteNodeEventTypeOverride(new StrCode32("PutHostageInVehicle"), typeof(TppRouteNodeEventPutHostageInVehicle));
            GameServiceModule.RegisterRouteNodeEventTypeOverride(new StrCode32("TakeHostageOutOfVehicle"), typeof(TppRouteNodeEventTakeHostageOutOfVehicle));

            GameServiceModule.RegisterRouteEdgeEventTypeOverride(new StrCode32("Move"), typeof(TppRouteEdgeEventMove));
            GameServiceModule.RegisterRouteEdgeEventTypeOverride(new StrCode32("VehicleMoveSlow"), typeof(TppRouteEdgeEventVehicleMoveSlow));
            GameServiceModule.RegisterRouteEdgeEventTypeOverride(new StrCode32("VehicleMoveNormal"), typeof(TppRouteEdgeEventVehicleMoveNormal));
            GameServiceModule.RegisterRouteEdgeEventTypeOverride(new StrCode32("VehicleMoveFast"), typeof(TppRouteEdgeEventVehicleMoveFast));
            GameServiceModule.RegisterRouteEdgeEventTypeOverride(new StrCode32("VehicleBackSlow"), typeof(TppRouteEdgeEventVehicleBackSlow));
            GameServiceModule.RegisterRouteEdgeEventTypeOverride(new StrCode32("VehicleBackNormal"), typeof(TppRouteEdgeEventVehicleBackNormal));
            GameServiceModule.RegisterRouteEdgeEventTypeOverride(new StrCode32("VehicleBackFast"), typeof(TppRouteEdgeEventVehicleBackFast));
            GameServiceModule.RegisterRouteEdgeEventTypeOverride(new StrCode32("VehicleKmPerHour"), typeof(TppRouteEdgeEventVehicleKmPerHour));
        }
    }
}
