using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemyBehaviour : MonoBehaviour
{
    private Animator _animator;
    private GameObject _player;
    private bool _detected;
    public float speed;
    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (_detected)
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, speed);
            transform.rotation = (_player.transform.position.x > transform.position.x) ? Quaternion.Euler(0f, 180f, 0f) : Quaternion.identity;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _detected = true;
            _animator.SetBool("Detected", _detected);
            _player = other.gameObject;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _detected = false;
            _animator.SetBool("Detected", _detected);
        }
    }
}
