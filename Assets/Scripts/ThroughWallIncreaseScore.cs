using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroughWallIncreaseScore : MonoBehaviour
{
    public ScoreManager scoreManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("ThroughWallArea"))
        {
            scoreManager.addToScore();
            Destroy(collision.gameObject);
        }
    }
}
