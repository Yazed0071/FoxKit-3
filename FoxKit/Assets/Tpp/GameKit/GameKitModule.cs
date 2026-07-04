using System;
using System.IO;
using Fox;
using Fox.GameService;
using UnityEditor;

namespace Tpp.GameKit
{
    [InitializeOnLoad]
    public static class GameKitModule
    {
        static GameKitModule()
        {
            GameServiceModule.RegisterEventInfo("Assets/Tpp/GameKit/Route/EventInfo.csv", "tpp");
            
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
