using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandeler : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private int _currentSprite = 2;
    public Sprite[] walkingSprites;
    public Animator animator;

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
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetInteger("Direction", ChooseWalkingSprite());
            }
            else
            {
                animator.SetInteger("Direction", 4);
            }
        }
    }

    private int ChooseWalkingSprite()
    {
        if ((int) _moveHorizontal == -1)
        {
            _currentSprite = 3;
        }

        if ((int) _moveHorizontal == 1)
        {
            _currentSprite = 1;
        }

        if ((int) _moveVertical == 1)
        {
            _currentSprite = 0;
        }
        
        if ((int) _moveVertical == -1)
        {
            _currentSprite = 2;
        }

        return _currentSprite;
    }
}