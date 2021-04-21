﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerBehaviour _playerBehaviour;
    
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
        Menu();
        _playerBehaviour = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();
    }

    private void Update()
    {
        if (state == State.Menu && Input.GetKeyDown(KeyCode.Space))
        {
            InGame();
        }
    }

    public enum State
    {
        Menu,
        InGame,
        Dead
    }

    public State state;


    public void Menu()
    {
        state = State.Menu;
        DisplayManager.Instance.UpdateUI();
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
}
