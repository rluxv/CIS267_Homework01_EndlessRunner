using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_TERRAIN = 50f;
    [SerializeField] private Transform terrainStart;
    [SerializeField] private Transform Terrain1;
    [SerializeField] private GameObject player;
    private Vector3 lastEndPos;
    void Start()
    {
        lastEndPos = new Vector3(terrainStart.Find("EndPos").position.x + 10, terrainStart.Find("EndPos").position.y);

        spawnTerrain();
        spawnTerrain();
    }

    private void Update()
    {
        if(Vector3.Distance(player.transform.position, lastEndPos) < PLAYER_DISTANCE_SPAWN_TERRAIN)
        {
            spawnTerrain();
        }

    }

    private void spawnTerrain()
    {
        Transform lastTerrainTFM = spawnTerrain(lastEndPos);
        lastEndPos = new Vector3(lastTerrainTFM.Find("EndPos").position.x + 10, lastTerrainTFM.Find("EndPos").position.y);
    }

    private Transform spawnTerrain(Vector3 position)
    {
        Transform terrainTFM = Instantiate(Terrain1, position, Quaternion.identity);
        return terrainTFM;
    }
}
