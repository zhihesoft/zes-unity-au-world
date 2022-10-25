using Au;
using UnityEngine;

public class WorldRunnerEditor : MonoBehaviour
{
    public string worldId;
    public GameObject root;

    World world;

    // Start is called before the first frame update
    void Start()
    {
        RunWorld();
    }

    // Update is called once per frame
    void Update()
    {
        world?.Tick();
    }

    async void RunWorld()
    {
        world = new World();
        await world.Init(worldId, null);
        world.Run(root, null);
    }
}
