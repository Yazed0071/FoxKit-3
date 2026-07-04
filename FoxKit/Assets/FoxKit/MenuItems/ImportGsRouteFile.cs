using Fox.GameService;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FoxKit.MenuItems
{
    public class ImportGsRouteFile
    {
        [MenuItem("FoxKit/Import/GsRouteFile")]
        private static void OnImportAsset()
        {
            string assetPath = Fox.Fs.FileUtils.OpenFilePanel("Import GsRouteFile", "frt");
            if (string.IsNullOrEmpty(assetPath))
                return;

            var frtReader = new RouteFileReader();
            UnityEngine.SceneManagement.Scene? scene = frtReader.Read(System.IO.File.ReadAllBytes(assetPath));
            if (scene is Scene realScene)
                realScene.name = System.IO.Path.GetFileNameWithoutExtension(assetPath);
            else
                Debug.LogError("FRT import failed.");
        }
    }
}
