using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed;
    public float moveSpeedWhileFighting;
    public GameObject mainCamera;
    public float respawnTime;
    public Color deadColor;
    public Color aliveColor;
    public bool isFighting;

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
        isFighting = Input.GetKey(KeyCode.LeftShift);
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.state == GameManager.State.InGame)
        {
            _rb2d.velocity = new Vector2(_moveHorizontal * MoveSpeed(), _moveVertical * MoveSpeed());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.Dead();
            StartCoroutine(Respawn());
            PlayerLook("dead");
        }
    }
    
    
    public void PlayerLook(string state)
    {
        if (state == "dead")
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            gameObject.GetComponent<SpriteRenderer>().color = deadColor;
        }
        else if (state == "alive")
        {
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.GetComponent<SpriteRenderer>().color = aliveColor;
        }
        else
        {
            Debug.Log("Did not recognize state in playerLook function");
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Floor0"))
        {
            GameManager.Instance.inRoom = true;
            GameManager.Instance.cameraFollow.FloorZero();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Floor0"))
        {
            GameManager.Instance.inRoom = false;
            GameManager.Instance.cameraFollow.InGameCamera();
        }
    }

    private float MoveSpeed()
    {
        return isFighting ? moveSpeedWhileFighting : moveSpeed;
    }


    private IEnumerator Respawn()
    {
        GameManager.Instance.cameraFollow.DeadCamera();
        float time = 0;

        while (time < respawnTime)
        {
            mainCamera.transform.position = gameObject.transform.position + GameManager.Instance.cameraFollow.offset;
            time += Time.deltaTime;
            
            yield return null;
        }

        gameObject.transform.position = GameManager.Instance.spawnPoint.position;
        PlayerLook("alive");
        GameManager.Instance.InGame();
        GameManager.Instance.cameraFollow.InGameCamera();
    }
}