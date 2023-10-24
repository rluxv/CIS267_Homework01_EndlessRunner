using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<GameObject> items;
    // Start is called before the first frame update
    void Start()
    {
        spawnItem();
    }

    public void spawnItem()
    {
        Instantiate(items[Random.Range(0, items.Count)], transform.position, transform.rotation);
    }
}
