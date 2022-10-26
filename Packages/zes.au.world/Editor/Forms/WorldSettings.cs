using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Au;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Linq;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using UnityEngine.Rendering.VirtualTexturing;

public class WorldSettings : EditorWindow
{
    [MenuItem("Au World/Settings")]
    public static void ShowExample()
    {
        WorldSettings wnd = GetWindow<WorldSettings>();
        wnd.minSize = new Vector2(800, 600);
        wnd.titleContent = new GUIContent("World Settings");
    }

    private EditorStorage storage;
    private string currentAppId;
    private WorldConfig config;
    private TextField tfId;
    private TextField tfVersion;

    public void CreateGUI()
    {
        storage = EditorStorage.Get("zes.au.world.editor");
        currentAppId = storage.GetString("appid");
        LoadConfig();
    }

    private void LoadConfig()
    {
        if (!string.IsNullOrEmpty(currentAppId))
        {
            config = WorldConfig.Load(currentAppId);
        }
    }

    private void OnGUI()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                currentAppId = EditorGUILayout.TextField("App ID", currentAppId);
                if (GUILayout.Button("Load", EditorStyles.miniButton, GUILayout.Width(64)))
                {
                    storage.SetString("appid", currentAppId);
                    LoadConfig();
                }
            }
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            if (config == null)
            {
                EditorGUILayout.LabelField("No config loaded");
                return;
            }

            config.version = EditorGUILayout.TextField("Version", config.version);
            config.displayName = EditorGUILayout.TextField("Display Name", config.displayName);
            config.entry = EditorGUILayout.TextField("Entry", config.entry);
            EditorGUILayout.LabelField("Assets");
            using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                if (config.assets != null && config.assets.Count > 0)
                {
                    config.assets
                        .ToList()
                        .ForEach(entry =>
                        {
                            EditorGUILayout.LabelField(entry.Key, $"{entry.Value.hash} ({entry.Value.size})");
                        });
                }
                else
                {
                    EditorGUILayout.LabelField("Empty");
                }
            }

            EditorGUILayout.LabelField("");

            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("Build", GUILayout.Width(120), GUILayout.Height(32)))
                {
                    if (config != null)
                    {
                        BuildWorld();
                    }
                }
                if (GUILayout.Button("Save", GUILayout.Width(120), GUILayout.Height(32)))
                {
                    GUIUtility.keyboardControl = 0;
                    if (config != null)
                    {
                        string path = Path.Combine("Assets", "Worlds", config.id, "config.json");
                        File.WriteAllText(path, LitJson.JsonMapper.ToJson(config), Files.utf8WithoutBOM);
                        Debug.Log("World config saved !");
                    }
                }
            }
        }

        async void BuildWorld()
        {
            await Task.Yield();

            if (!BuildJavascript())
            {
                Debug.LogError("Build javascript failed !");
                return;
            }

            string inputPath = Path.Combine("Assets", "Worlds", config.id);
            string outputPath = Path.Combine("Temp", "Worlds", config.id);
            AssetSetBuilder.BuildBundles(inputPath, outputPath);
            AssetDatabase.Refresh();
            Debug.Log("Build world done !");
        }

        bool BuildJavascript()
        {
            string projectPath = Path.Combine("Typescripts", config.id);
            string releasePath = Path.Combine("Typescripts", config.id, "out", "main.bytes");
            string targetPath = Path.Combine("Assets", "Worlds", config.id, "js", "main.bytes");

            var exitCode = Shell.Run("gulp", new List<string> { "build" }, projectPath);
            if (exitCode != 0)
            {
                Debug.LogError("build ts source failed with code " + exitCode);
                return false;
            }

            var source = new FileInfo(releasePath);
            if (!source.Exists)
            {
                Debug.LogError($"{source.FullName} not existed");
                return false;
            }

            Files.EnsureDir(new FileInfo(targetPath).Directory);
            source.CopyTo(targetPath, true);
            return true;

        }
    }
}