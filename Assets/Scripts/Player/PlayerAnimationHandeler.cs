using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandeler : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public Sprite[] walkingSprites;

    //input variables
    private float _moveHorizontal;
    private float _moveVertical;

    private List<int> _input;

    private void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        _moveHorizontal = Input.GetAxisRaw("Horizontal");
        _moveVertical = Input.GetAxisRaw("Vertical");
        if (GameManager.Instance.state == GameManager.State.InGame)
        {
            _spriteRenderer.sprite = walkingSprites[ChooseWalkingSprite()];
        }
    }

    private int ChooseWalkingSprite()
    {
        if ((int) _moveHorizontal == -1)
        {
            return 3;
        }

        if ((int) _moveHorizontal == 1)
        {
            return 1;
        }

        if ((int) _moveVertical == 1)
        {
            return 0;
        }

        return 2;
    }
}