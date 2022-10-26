using Au.TS;
using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;

namespace Au
{
    public class World
    {
        public string id { get; private set; }

        public WorldConfig config { get; private set; }

        public TSApp app { get; private set; }
        public AssetSet assets { get; private set; }

        private Log log = Log.GetLogger<World>();

        public async Task<bool> Init(string id, Action<float> progress)
        {
            this.id = id;
            config = WorldConfig.Load(id);
            Assert.IsNotNull(config, $"Load config of {id} failed");
            await Task.Yield();
            // TODO add patch functions
            progress?.Invoke(1);
            return true;
        }

        public bool Run(GameObject root, AssetSet appAssets)
        {
            var path = Path.Combine(id, "dist", "index.js");
            path = path.Replace("\\", "/");
            // TODO use bundle script in runtime
            log.Info($"Run world js {path}");
            StartupInfo startupInfo = new StartupInfo();
            startupInfo.script = path;
            startupInfo.initActions = (env) =>
            {
                env.UsingAction<string, AssetSet, GameObject>();
            };
            app = new TSApp(startupInfo);
            app.Run();
            var main = app.GetFunc<Action<string, AssetSet, GameObject>>("main");
            assets = appAssets == null ? new AssetSet(id) : appAssets.CreateChild(id);
            main.Invoke(id, assets, root);
            return true;
        }

        public void Tick()
        {
            app?.Tick();
        }

        public void Close()
        {
            assets.UnloadAllBundles();
        }
    }
}

