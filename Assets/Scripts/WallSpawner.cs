using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public float timer = 0f;

    public Transform MaxHeightTop;
    public Transform MinHeightBottom;

    public GameObject WallPairPrefab;

    public bool shouldSpawn;

    private void Start()
    {
        shouldSpawn = true;
    }
    void FixedUpdate()
    {
        if(timer <= 0f && shouldSpawn)
        {
            GameObject newWallPair = Instantiate(WallPairPrefab);
            newWallPair.GetComponent<RandomlySpawnWalls>().MaxHeightTop = MaxHeightTop;
            newWallPair.GetComponent<RandomlySpawnWalls>().MinHeightBottom = MinHeightBottom;
            newWallPair.transform.parent = transform;
            timer = Random.Range(2f, 5f);
        } else
        {
            timer = timer - Time.deltaTime;
        }
    }

}
