using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerBehaviour _playerBehaviour;
    public CameraFollow cameraFollow;
    public bool inRoom;
    public List<Boolean> peopleSave = new List<bool>() {false, false, false, false, false, false};
    public bool[] peopleKilled;
    
    //Makes GameManager singleton
    private static GameManager _instance;
    public static GameManager Instance {
        get {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    private void Start()
    {
        _playerBehaviour = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();
        cameraFollow = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>();
        Menu();
    }

    private void Update()
    {
        if (state == State.Menu && Input.GetKeyDown(KeyCode.Space))
        {
            cameraFollow.InGameCamera();
            InGame();
        }
    }

    public enum State
    {
        Menu,
        InGame,
        Dead,
        WonPeace,
        WonDeath
    }

    public State state;


    public void Menu()
    {
        state = State.Menu;
        cameraFollow.MenuCamera();
    }

    public void InGame()
    {
        state = State.InGame;
        DisplayManager.Instance.UpdateUI();
    }

    public void Dead()
    {
        state = State.Dead;
        DisplayManager.Instance.UpdateUI();
    }

    public void WonPeace()
    {
        state = State.WonPeace;
        DisplayManager.Instance.UpdateUI();
    }

    public void WonDeath()
    {
        state = State.WonPeace;
        DisplayManager.Instance.UpdateUI();
    }

    public void CheckIfWon()
    {
        var list = new List<bool>(peopleSave);
        list.RemoveAll(person => person);
        if (list.Count == 0)
        {
            WonPeace();
        }
    }

    public IEnumerator KnockBack(float duration, float power, Transform current ,Transform relativeToObject)
    {
        float timer = 0f;
        while (duration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (relativeToObject.position - current.position).normalized;
            {
                current.GetComponent<Rigidbody2D>().AddForce(-direction * power);
            }
            
            yield return null;
        }
    }
}
