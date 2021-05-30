using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomlySpawnWalls : MonoBehaviour
{
    public GameObject TopWall;
    public GameObject BottomWall;

    public Transform MaxHeightTop;
    public Transform MinHeightBottom;

    void Start()
    {
        gameObject.transform.position = new Vector2(MaxHeightTop.position.x, gameObject.transform.position.y);
        TopWall.transform.position = MaxHeightTop.position;
        BottomWall.transform.position = MinHeightBottom.position;

        float randomAddY = Random.Range(0f, 5f);
        BottomWall.transform.position = new Vector2(BottomWall.transform.position.x, BottomWall.transform.position.y + randomAddY);

        float randomYBufferDiff = Random.Range(10.5f, 13f);
        TopWall.transform.position = new Vector2(TopWall.transform.position.x, BottomWall.transform.position.y + randomYBufferDiff);
    }

}
