using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private Transform terrainStart;
    [SerializeField] private Transform Terrain1;
    private Vector3 lastEndPos;
    void Start()
    {
        //Instantiate(Terrain1, new Vector3(-0, -0), Quaternion.identity);
        lastEndPos = new Vector3(terrainStart.Find("EndPos").position.x + 10, terrainStart.Find("EndPos").position.y);

        spawnTerrain();
        spawnTerrain();
        //lastTerrainTFM = spawnTerrain(new Vector3(terrainStart.Find("EndPos").position.x + 10, terrainStart.Find("EndPos").position.y));
        //lastTerrainTFM = spawnTerrain(new Vector3(lastTerrainTFM.Find("EndPos").position.x + 10, lastTerrainTFM.Find("EndPos").position.y));
        //lastTerrainTFM = spawnTerrain(new Vector3(lastTerrainTFM.Find("EndPos").position.x + 10, lastTerrainTFM.Find("EndPos").position.y));
        //lastTerrainTFM = spawnTerrain(new Vector3(lastTerrainTFM.Find("EndPos").position.x + 10, lastTerrainTFM.Find("EndPos").position.y));
        //lastTerrainTFM = spawnTerrain(new Vector3(lastTerrainTFM.Find("EndPos").position.x + 10, lastTerrainTFM.Find("EndPos").position.y));
        //spawnTerrain(new Vector3(terrainStart.Find("EndPos").position.x + 10, terrainStart.Find("EndPos").position.y));
        //spawnTerrain(new Vector3(terrainStart.Find("EndPos").position.x + 10, terrainStart.Find("EndPos").position.y));
        //spawnTerrain(new Vector3(terrainStart.Find("EndPos").position.x + 10, terrainStart.Find("EndPos").position.y));
        //spawnTerrain(lastTerrainTFM.Find("EndPos").position);
        //spawnTerrain(new Vector3(0, 0));
        //spawnTerrain(new Vector3(0, 0) + new Vector3(40, 0));
        //spawnTerrain(new Vector3(0, 0) + new Vector3(40 + 40, 0));
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
