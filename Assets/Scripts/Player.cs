using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int speed;
    private float _directionX;
    private bool _isLeft = false;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private static readonly int Speed = Animator.StringToHash("Speed");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (DialogManager.Instance.dialogueIsPlaying)
        {
            _animator.SetFloat(Speed,0);
            return;
        }
        
        if (InputManager.Instance.GetMovePressed())
        {
            _directionX = InputManager.Instance.GetMoveDirection();
            _animator.SetFloat(Speed,Mathf.Abs(_directionX));

            if (_directionX < 0)
            {
                _isLeft = true;
            }
            else if(_directionX > 0)
            {
                _isLeft = false;
            }
            
        }
        else
        {
            _directionX = InputManager.Instance.GetMoveDirection();
            _animator.SetFloat(Speed,Mathf.Abs(_directionX));
        }

        transform.Translate(-_directionX * -1 * speed * Time.deltaTime,0,0);
        
        _spriteRenderer.flipX = _isLeft;
    }

    private void Update()
    {
        if (InputManager.Instance.GetInteractPressed())
        {
            //Debug.Log("Interaction pressed");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("StairsUp"))
        {
            other.GetComponentInParent<EdgeCollider2D>().enabled = false;
            other.GetComponentInParent<CapsuleCollider2D>().enabled = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        else if (other.gameObject.CompareTag("StairsDown"))
        {
            other.GetComponentInParent<EdgeCollider2D>().enabled = false;
            other.GetComponentInParent<CapsuleCollider2D>().enabled = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
    

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("StairsUp"))
        {
            if (InputManager.Instance.GetStairsDirection() < 0  && _isLeft)
            {
                other.GetComponentInParent<EdgeCollider2D>().enabled = true;
                other.GetComponentInParent<CapsuleCollider2D>().enabled = false;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 5f;
            }
        }
        else if (other.gameObject.CompareTag("StairsDown"))
        {
            if (InputManager.Instance.GetStairsDirection() > 0  && !_isLeft)
            {
                other.GetComponentInParent<EdgeCollider2D>().enabled = true;
                other.GetComponentInParent<CapsuleCollider2D>().enabled = false;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.8f;
            }
        }

    }

    public bool GetPlayerFace()
    {
        return _isLeft;
    }
}
