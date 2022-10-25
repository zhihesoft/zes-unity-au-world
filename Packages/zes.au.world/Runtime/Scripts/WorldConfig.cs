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
        public string name;
        public string displayName;
        public string version;
        public string[] scenes;

        public static async Task<WorldConfig> Load(string id)
        {
            var path = Path.Combine(Application.persistentDataPath, id);
#if UNITY_EDITOR
            path = Path.Combine("Assets", id, "config.json");
#endif
            if (!Files.Exists(path))
            {
                Log.GetLogger<WorldConfig>().Error($"{path} not exists");
                return null;
            }

            var json = await Files.Read(path);
            var config = LitJson.JsonMapper.ToObject<WorldConfig>(json);
            return config;
        }
    }
}
