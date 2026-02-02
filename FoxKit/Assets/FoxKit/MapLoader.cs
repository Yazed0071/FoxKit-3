using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;
using System.Reflection;
using Fox.Core.Utils;
using Fox.Fio;
using Fox.Fs;
using UnityEditor.SceneManagement;
using Fox.Core;
using System;

namespace FoxKit.Windows
{
    public class MapLoader : EditorWindow
    {
        private static readonly Dictionary<string, MapBounds> MapBoundsByLocation = new()
        {
            { "AFGH", new MapBounds(101, 101, 164, 164) },
            { "CYPR", new MapBounds(1,   1,   1,   9)   },
            { "MAFR", new MapBounds(101, 101, 164, 164) },
            { "MBQF", new MapBounds(101, 101, 102, 102) },
        };

        private static readonly List<string> LocationList = new() { "AFGH", "CYPR", "MAFR", "MBQF" };

        private const int CellW = 14;
        private const int CellH = 14;

        private Label selectedLabel;
        private Label hoverLabel;

        private VisualElement gridHost;

        [MenuItem("FoxKit/Import/Map Loader")]
        public static void Open()
        {
            var wnd = GetWindow<MapLoader>();
            wnd.titleContent = new GUIContent("Map Loader");
            wnd.minSize = new Vector2(700, 520);
        }

        public void CreateGUI()
        {
            var root = rootVisualElement;
            root.style.paddingLeft = 6;
            root.style.paddingRight = 6;
            root.style.paddingTop = 6;
            root.style.paddingBottom = 6;

            // --- Header row (Location dropdown + labels) ---
            var header = new VisualElement
            {
                style =
                {
                    flexDirection = FlexDirection.Row,
                    alignItems = Align.Center,
                    marginBottom = 6,
                }
            };

            header.Add(new Label("Location:"));

            var locationPopup = new PopupField<string>(LocationList, 0);
            locationPopup.style.minWidth = 120;
            header.Add(locationPopup);

            selectedLabel = new Label("Selected: none")
            {
                style =
                {
                    unityFontStyleAndWeight = FontStyle.Bold,
                    marginLeft = 12
                }
            };
            header.Add(selectedLabel);

            hoverLabel = new Label("Hover: none")
            {
                style =
                {
                    marginLeft = 14
                }
            };
            header.Add(hoverLabel);

            root.Add(header);

            // --- Scroll area ---
            var scroll = new ScrollView(ScrollViewMode.VerticalAndHorizontal);
            scroll.style.flexGrow = 1;
            root.Add(scroll);

            gridHost = new VisualElement();
            scroll.Add(gridHost);

            // Initial build + rebuild on map change
            RebuildGrid(locationPopup.value);
            locationPopup.RegisterValueChangedCallback(e => RebuildGrid(e.newValue));
        }

        private void RebuildGrid(string location)
        {
            if (!MapBoundsByLocation.TryGetValue(location, out var bounds))
                bounds = new MapBounds(101, 101, 164, 164);


            selectedLabel.text = "Selected: none";
            hoverLabel.text = "Hover: none";


            gridHost.Clear();


            var grid = new GridWithHover(bounds, CellW, CellH);


            grid.OnSelectionChanged += (mapX, mapY, index0) =>
            {
                selectedLabel.text = $"Selected: X={mapX}, Y={mapY} | Index0={index0} | Index1={index0 + 1}";
                ImportFox2ForTile(location, mapX, mapY);
            };


            grid.OnHoverChanged += (mapX, mapY, index0) =>
            {
                hoverLabel.text = (index0 < 0)
                ? "Hover: none"
                : $"Hover: X={mapX}, Y={mapY} | Index0={index0} | Index1={index0 + 1}";
            };


            gridHost.Add(grid);
        }

        private readonly struct MapBounds
        {
            public readonly int StartX, StartY, EndX, EndY;

            public MapBounds(int startX, int startY, int endX, int endY)
            {
                StartX = startX;
                StartY = startY;
                EndX = endX;
                EndY = endY;
            }

            public int Cols => (EndX - StartX) + 1;
            public int Rows => (EndY - StartY) + 1;
        }

        private sealed class GridWithHover : VisualElement
        {
            public event System.Action<int, int, int> OnSelectionChanged; // mapX,mapY,index0
            public event System.Action<int, int, int> OnHoverChanged;     // mapX,mapY,index0 (or -1)

            private readonly MapBounds bounds;
            private readonly int rows;
            private readonly int cols;
            private readonly int cellW;
            private readonly int cellH;

            private int selR = -1, selC = -1;
            private int hovR = -1, hovC = -1;

            private static readonly Color GridBg = new(0f, 0f, 0f, 0.08f);
            private static readonly Color Line = new(0f, 0f, 0f, 0.25f);

            private static readonly Color SelFill = new(0.25f, 0.6f, 1f, 0.45f);
            private static readonly Color SelBorder = new(0.25f, 0.6f, 1f, 0.95f);
            private static readonly Color HoverBorder = new(1f, 1f, 1f, 0.55f);

            public GridWithHover(MapBounds bounds, int cellW, int cellH)
            {
                this.bounds = bounds;
                this.rows = Mathf.Max(1, bounds.Rows);
                this.cols = Mathf.Max(1, bounds.Cols);
                this.cellW = Mathf.Max(2, cellW);
                this.cellH = Mathf.Max(2, cellH);

                // Total size for scroll content (NO headers)
                style.width = this.cols * this.cellW + 1;
                style.height = this.rows * this.cellH + 1;

                pickingMode = PickingMode.Position;

                generateVisualContent += OnDraw;

                RegisterCallback<MouseDownEvent>(OnMouseDown);
                RegisterCallback<MouseMoveEvent>(OnMouseMove);
                RegisterCallback<MouseLeaveEvent>(OnMouseLeave);
            }

            private void OnMouseLeave(MouseLeaveEvent e)
            {
                if (hovR != -1 || hovC != -1)
                {
                    hovR = -1; hovC = -1;
                    OnHoverChanged?.Invoke(0, 0, -1);
                    MarkDirtyRepaint();
                }
            }

            private void OnMouseMove(MouseMoveEvent e)
            {
                if (!TryPickCell(e.mousePosition, out int r, out int c))
                {
                    if (hovR != -1 || hovC != -1)
                    {
                        hovR = -1; hovC = -1;
                        OnHoverChanged?.Invoke(0, 0, -1);
                        MarkDirtyRepaint();
                    }
                    return;
                }

                if (hovR == r && hovC == c)
                    return;

                hovR = r;
                hovC = c;

                int mapX = bounds.StartX + c;
                int mapY = bounds.StartY + r;
                int index0 = (r * cols) + c;

                OnHoverChanged?.Invoke(mapX, mapY, index0);
                MarkDirtyRepaint();
            }

            private void OnMouseDown(MouseDownEvent e)
            {
                if (e.button != 0) return;

                if (!TryPickCell(e.mousePosition, out int r, out int c))
                    return;

                if (selR == r && selC == c)
                    return;

                selR = r;
                selC = c;

                int mapX = bounds.StartX + c;
                int mapY = bounds.StartY + r;
                int index0 = (r * cols) + c;

                OnSelectionChanged?.Invoke(mapX, mapY, index0);
                MarkDirtyRepaint();

                e.StopPropagation();
            }

            private bool TryPickCell(Vector2 mouseWorld, out int r, out int c)
            {
                r = -1; c = -1;

                // local = world mouse - element top-left (older UIElements-safe)
                Vector2 local = mouseWorld - new Vector2(worldBound.xMin, worldBound.yMin);

                c = Mathf.FloorToInt(local.x / cellW);
                r = Mathf.FloorToInt(local.y / cellH);

                if (r < 0 || r >= rows || c < 0 || c >= cols)
                    return false;

                return true;
            }

            private static void PathRect(Painter2D p, Rect r)
            {
                p.BeginPath();
                p.MoveTo(new Vector2(r.xMin, r.yMin));
                p.LineTo(new Vector2(r.xMax, r.yMin));
                p.LineTo(new Vector2(r.xMax, r.yMax));
                p.LineTo(new Vector2(r.xMin, r.yMax));
                p.LineTo(new Vector2(r.xMin, r.yMin));
            }

            private void OnDraw(MeshGenerationContext ctx)
            {
                var p = ctx.painter2D;

                float gridW = cols * cellW;
                float gridH = rows * cellH;

                // Grid background (starts at 0,0)
                p.fillColor = GridBg;
                PathRect(p, new Rect(0, 0, gridW, gridH));
                p.Fill();

                // Hover outline
                if (hovR >= 0 && hovC >= 0)
                {
                    float x = hovC * cellW;
                    float y = hovR * cellH;

                    p.strokeColor = HoverBorder;
                    p.lineWidth = 1f;
                    PathRect(p, new Rect(x, y, cellW, cellH));
                    p.Stroke();
                }

                // Selected highlight
                if (selR >= 0 && selC >= 0)
                {
                    float x = selC * cellW;
                    float y = selR * cellH;

                    p.fillColor = SelFill;
                    PathRect(p, new Rect(x, y, cellW, cellH));
                    p.Fill();

                    p.strokeColor = SelBorder;
                    p.lineWidth = 2f;
                    PathRect(p, new Rect(x, y, cellW, cellH));
                    p.Stroke();
                }

                // Grid lines
                p.strokeColor = Line;
                p.lineWidth = 1f;

                // Vertical lines
                p.BeginPath();
                for (int c = 0; c <= cols; c++)
                {
                    float x = c * cellW;
                    p.MoveTo(new Vector2(x, 0));
                    p.LineTo(new Vector2(x, gridH));
                }
                p.Stroke();

                // Horizontal lines
                p.BeginPath();
                for (int r = 0; r <= rows; r++)
                {
                    float y = r * cellH;
                    p.MoveTo(new Vector2(0, y));
                    p.LineTo(new Vector2(gridW, y));
                }
                p.Stroke();
            }
        }
        private void ImportFox2ForTile(string location, int mapX, int mapY)
        {
            // ExternalBasePath should be the folder that CONTAINS "Assets"
            string externalRoot = FoxKit.SettingsManager.ExternalBasePath;

            if (string.IsNullOrEmpty(externalRoot) || !Directory.Exists(externalRoot))
            {
                Debug.LogError("[MapLoader] ExternalBasePath is not set or invalid. Open FoxKit settings and set it.");
                FoxKit.SettingsManager.ShowSettingsWindow();
                return;
            }

            string locLower = location.ToLowerInvariant();
            string locationRoot = Path.Combine(externalRoot, "Assets", "tpp", "level", "location", locLower);

            if (!Directory.Exists(locationRoot))
            {
                Debug.LogWarning($"[MapLoader] Location folder not found: {locationRoot}");
                return;
            }

            // Find the tile folder(s) under both block dirs
            List<string> tileDirs = FindTileDirs(locationRoot, mapX, mapY);
            if (tileDirs.Count == 0)
            {
                Debug.LogWarning($"[MapLoader] Tile folder not found for {location} X={mapX} Y={mapY} in block_small/block_extraSmall.");
                return;
            }

            // Collect .fox2 files (dedupe) WITHOUT LINQ
            var fox2Set = new HashSet<string>(System.StringComparer.OrdinalIgnoreCase);
            for (int i = 0; i < tileDirs.Count; i++)
            {
                string dir = tileDirs[i];
                foreach (string f in Directory.EnumerateFiles(dir, "*.fox2", SearchOption.AllDirectories))
                    fox2Set.Add(f);
            }

            if (fox2Set.Count == 0)
            {
                Debug.LogWarning($"[MapLoader] No .fox2 files found for {location} X={mapX} Y={mapY}.");
                return;
            }

            // Convert set -> list and sort WITHOUT LINQ
            var fox2List = new List<string>(fox2Set);
            fox2List.Sort(System.StringComparer.OrdinalIgnoreCase);

            var logger = new TaskLogger($"Import Tile FOX2 [{location}] {mapX}_{mapY}");
            int success = 0, fail = 0;

            try
            {
                int total = fox2List.Count;

                for (int i = 0; i < total; i++)
                {
                    string externalFile = fox2List[i];

                    EditorUtility.DisplayProgressBar(
                        "Importing FOX2",
                        $"{location} {mapX}_{mapY} ({i + 1}/{total})\n{Path.GetFileName(externalFile)}",
                        total > 0 ? (float)(i + 1) / total : 1f
                    );

                    try
                    {
                        ImportOneFox2(externalFile, logger, keepScenesOpen: true);
                        success++;
                    }
                    catch (System.Exception ex)
                    {
                        fail++;
                        logger.AddError($"Failed importing: {externalFile}\n{ex}");
                    }
                }
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }

            logger.LogToUnityConsole();
            Debug.Log($"[MapLoader] Import complete for {location} {mapX}_{mapY}. Success={success}, Fail={fail}");
        }

        private static void ImportOneFox2(string externalFile, TaskLogger logger, bool keepScenesOpen)
        {
            string foxPath = Fox.Fs.FileSystem.GetFoxPathFromExternalPath(externalFile);
            foxPath = NormalizeFoxPath(foxPath);

            // IMPORTANT: Additive keeps previously loaded scenes open
            var loadMode = keepScenesOpen
                ? DataSetFile2.SceneLoadMode.Additive
                : DataSetFile2.SceneLoadMode.Auto;

            if (!string.IsNullOrEmpty(foxPath) && foxPath.StartsWith("/Assets/"))
            {
                ReadOnlySpan<byte> fileData = Fox.Fs.FileSystem.ReadExternalFile(foxPath);
                UnityEngine.SceneManagement.Scene scene = DataSetFile2.Read(fileData, loadMode, logger);

                // Imports/saves the scene asset for that foxPath
                Fox.Fs.FileSystem.TryImportAsset(scene, foxPath);

                // DO NOT close the scene if you want it visible in hierarchy
                // if (!keepScenesOpen && scene.IsValid() && scene.isLoaded)
                //     UnityEditor.SceneManagement.EditorSceneManager.CloseScene(scene, removeScene: true);

                return;
            }

            // Fallback: loose mode
            {
                ReadOnlySpan<byte> fileData = Fox.Fs.FileSystem.ReadLooseFile(externalFile);
                UnityEngine.SceneManagement.Scene scene = DataSetFile2.Read(fileData, loadMode, logger);

                Fox.Fs.FileSystem.TryImportAsset(scene, externalFile, ImportFileMode.Loose);

                // DO NOT close if you want all open
            }
        }

        private static string NormalizeFoxPath(string foxPath)
        {
            if (string.IsNullOrEmpty(foxPath))
                return null;

            foxPath = foxPath.Replace('\\', '/');

            if (foxPath.Length > 0 && foxPath[0] != '/')
                foxPath = "/" + foxPath;

            if (foxPath.StartsWith("/assets/"))
                foxPath = "/Assets/" + foxPath.Substring("/assets/".Length);

            return foxPath;
        }

        private static List<string> FindTileDirs(string locationRoot, int mapX, int mapY)
        {
            var results = new List<string>();

            string xFolder = mapX.ToString();
            string xyFolder = $"{mapX}_{mapY}";

            string[] blockFolders = { "block_extraSmall", "block_small" };

            for (int i = 0; i < blockFolders.Length; i++)
            {
                string blockPath = Path.Combine(locationRoot, blockFolders[i]);
                if (!Directory.Exists(blockPath))
                    continue;

                string xPath = Path.Combine(blockPath, xFolder);
                if (!Directory.Exists(xPath))
                    continue;

                string xyPath = Path.Combine(xPath, xyFolder);
                if (!Directory.Exists(xyPath))
                    continue;

                results.Add(xyPath);
            }

            return results;
        }
    }
}