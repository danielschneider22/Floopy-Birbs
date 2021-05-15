using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoseGameIfHitWall : MonoBehaviour
{
    public LoseGameManager loseGameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.name.Contains("Wall") || collision.gameObject.name.Contains("Floor")) && !collision.gameObject.name.Contains("ThroughWallArea"))
        {
            loseGameManager.LoseGame();
        }
    }
}
