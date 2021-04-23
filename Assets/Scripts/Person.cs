using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public GameObject saveTile;
    public int number;
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Sword"))
        {
            GameManager.Instance.peopleKilled[number] = true;
            Destroy(gameObject);
        }
        
        if (other.gameObject.name == saveTile.name)
        {
            GameManager.Instance.peopleSave[number] = true;
            GameManager.Instance.CheckIfWon();
            Destroy(gameObject);
        }
    }
}
