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
            RegisterDictionaries();
        }

        private static void RegisterDictionaries()
        {
            GameServiceModule.RouteIdMap.RegisterDictionary("/Assets/tpp/toolbox/Config/route_ids");
        }
    }
}
