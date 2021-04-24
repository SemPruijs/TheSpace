using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBegin : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            player.transform.position = GameManager.Instance.spawnPoint.position;
            GameManager.Instance.cameraFollow.gameObject.transform.position = GameManager.Instance.cameraFollow.offset;
        }
    }
}
