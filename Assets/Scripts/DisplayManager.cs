using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject inGame;
    public GameObject dead;

    //Makes DisplayManager singleton
    private static DisplayManager _instance;

    public static DisplayManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void UpdateUI()
    {
        menu.SetActive(GameManager.Instance.state == GameManager.State.Menu);
        inGame.SetActive(GameManager.Instance.state == GameManager.State.InGame);
        dead.SetActive(GameManager.Instance.state == GameManager.State.Dead);
    }
}