using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostInFieldTextField : MonoBehaviour
{
    public AudioClip helpMeClip;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Animator>().SetBool("ShowField", true);
            GetComponent<AudioSource>().PlayOneShot(helpMeClip);
        }
    }
}
