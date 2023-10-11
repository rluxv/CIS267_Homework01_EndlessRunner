using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private Transform Terrain1;
    private void Awake()
    {
        Instantiate(Terrain1, new Vector3(-0, -0), Quaternion.identity);
    }
}
