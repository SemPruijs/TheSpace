using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed;
    public Color deadColor;

    private Rigidbody2D _rb2d;

    //input variables
    private float _moveHorizontal;
    private float _moveVertical;


    private void Start()
    {
        _rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _moveHorizontal = Input.GetAxisRaw("Horizontal");
        _moveVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.state == GameManager.State.InGame)
        {
            _rb2d.velocity = new Vector2(_moveHorizontal * moveSpeed, _moveVertical * moveSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.Dead();
            PlayerDead();
        }
    }
    
    
    public void PlayerDead()
    {
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        gameObject.GetComponent<SpriteRenderer>().color = deadColor;
    }
}