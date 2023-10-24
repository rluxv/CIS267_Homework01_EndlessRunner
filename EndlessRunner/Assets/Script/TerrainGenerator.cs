using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_TERRAIN = 50f;
    public Transform terrainStart;
    public List<Transform> terrainEasyList;
    public List<Transform> terrainMediumList;
    public List<Transform> terrainHardList;
    public GameObject gameManagerObj;
    private GameManager gameManager;
    public GameObject player;
    private Vector3 lastEndPos;
    public Transform boostTerrain;
    void Start()
    {
        gameManager = gameManagerObj.GetComponent<GameManager>();
        lastEndPos = new Vector3(terrainStart.Find("EndPos").position.x + 10, terrainStart.Find("EndPos").position.y + Random.Range(0, 3));

        //Spawn some new terrain right when the game starts
        spawnTerrain();
        spawnTerrain();
        spawnTerrain();
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
        int num = Random.Range(0, 101);
        //There is a 10 percent chance that the special boost terrain will be spawned.
        if(num >= 90)
        {
            Transform lastTerrainTFM = spawnTerrain(boostTerrain, lastEndPos);
            lastEndPos = new Vector3(lastTerrainTFM.Find("EndPos").position.x + 10, lastTerrainTFM.Find("EndPos").position.y + Random.Range(0, 3));
        }
        else
        {
            //Make the terrain harder depending on player score
            if (gameManager.getScore() <= 999)
            {
                Transform terrainToSpawn = terrainEasyList[Random.Range(0, terrainEasyList.Count)];
                Transform lastTerrainTFM = spawnTerrain(terrainToSpawn, lastEndPos);
                lastEndPos = new Vector3(lastTerrainTFM.Find("EndPos").position.x + 10, lastTerrainTFM.Find("EndPos").position.y + Random.Range(0, 3));
            }
            else if (gameManager.getScore() >= 1000 && gameManager.getScore() <= 2000)
            {
                Transform terrainToSpawn = terrainMediumList[Random.Range(0, terrainMediumList.Count)];
                Transform lastTerrainTFM = spawnTerrain(terrainToSpawn, lastEndPos);
                lastEndPos = new Vector3(lastTerrainTFM.Find("EndPos").position.x + 10, lastTerrainTFM.Find("EndPos").position.y + Random.Range(0, 3));
            }
            else
            {
                Transform terrainToSpawn = terrainHardList[Random.Range(0, terrainHardList.Count)];
                Transform lastTerrainTFM = spawnTerrain(terrainToSpawn, lastEndPos);
                lastEndPos = new Vector3(lastTerrainTFM.Find("EndPos").position.x + 10, lastTerrainTFM.Find("EndPos").position.y + Random.Range(0, 3));
            }
        }
        
    }

    private Transform spawnTerrain(Transform terrain, Vector3 position)
    {
        Transform terrainTFM = Instantiate(terrain, position, Quaternion.identity);
        return terrainTFM;
    }
}
