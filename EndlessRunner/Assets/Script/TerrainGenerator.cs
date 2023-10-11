using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private Transform Terrain1;
    void Start()
    {
        //Instantiate(Terrain1, new Vector3(-0, -0), Quaternion.identity);
        spawnTerrain(new Vector3(0, 0));
        spawnTerrain(new Vector3(0, 0) + new Vector3(40, 0));
        spawnTerrain(new Vector3(0, 0) + new Vector3(40 + 40, 0));
    }

    private void spawnTerrain(Vector3 position)
    {
        Instantiate(Terrain1, position, Quaternion.identity);
    }
}
