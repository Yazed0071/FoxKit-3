using Fox;
using Fox.Fs;
using Fox.GameService;

namespace FoxKit
{
    public class FoxKitModule : Module
    {
        public static FoxKitModule Instance { get; private set; }

        public FoxKitModule() : base("FoxKit")
        {
            Instance = this;
            AddDependencyModule("Fox.Fs");
            AddDependencyModule("Fox.GameService");
        }

        public override void Init()
        {
            FsModule.UnityBasePath = SettingsManager.UnityBasePath;
            FsModule.ExternalBasePath = SettingsManager.ExternalBasePath;
            FsModule.LooseBasePath = SettingsManager.LooseBasePath;

            RegisterDictionaries();
        }

        private static void RegisterDictionaries()
        {
            GameServiceModule.RegisterIdMaps("/Assets/tpp/toolbox/Config/route_ids", "/Assets/tpp/toolbox/Config/event_ids");
            
            GameServiceModule.RegisterEventInfo("/Assets/tpp/toolbox/Config/EventInfo.csv", "tpp");
        }
    }
}
