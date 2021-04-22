using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemyBehaviour : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    public bool detected;
    public float speed;
    public int lives = 5;
    public ParticleSystem particleSystem;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (GameManager.Instance.state == GameManager.State.InGame)
        {
            if (detected)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                transform.rotation = (player.transform.position.x > transform.position.x) ? Quaternion.Euler(0f, 180f, 0f) : Quaternion.identity;
            }
        }
        else
        {
            detected = false;
            animator.SetBool("Detected", detected);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            lives--;
            particleSystem.Play(true);
            StartCoroutine(GameManager.Instance.KnockBack(0.01f, 700f, gameObject.transform, player.transform));
            if (lives == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
