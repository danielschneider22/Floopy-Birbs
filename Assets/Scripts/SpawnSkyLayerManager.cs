using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkyLayerManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("SkyLayer"))
        {
            GameObject newSkyLayer = Instantiate(collision.gameObject);
            float width = collision.gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
            newSkyLayer.transform.position = collision.gameObject.transform.GetChild(0).position;
            newSkyLayer.transform.position = new Vector2(newSkyLayer.transform.position.x + (width / 2) - .01f, newSkyLayer.transform.position.y);
        }
    }
}
