using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace Au
{
    [Serializable]
    public class WorldConfig
    {
        public string id;
        public string displayName;
        public string version;
        public string entry;

        public static WorldConfig Load(string id)
        {
            var path = Path.Combine(Application.persistentDataPath, id);
#if UNITY_EDITOR
            path = Path.Combine("Assets", "Worlds", id, "config.json");
#endif
            if (!Files.Exists(path))
            {
                Log.GetLogger<WorldConfig>().Error($"{path} not exists");
                return null;
            }

            var json = File.ReadAllText(path, Files.utf8WithoutBOM);
            var config = LitJson.JsonMapper.ToObject<WorldConfig>(json);
            return config;
        }
    }
}
