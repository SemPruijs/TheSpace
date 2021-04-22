using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDetected : MonoBehaviour
{
    public StandardEnemyBehaviour enemy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemy.detected = true;
            enemy.animator.SetBool("Detected", enemy.detected);
            enemy.player = other.gameObject;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemy.detected = false;
            enemy.animator.SetBool("Detected", enemy.detected);
        }
        
        
    }
}
