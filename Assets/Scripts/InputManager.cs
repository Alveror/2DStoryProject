using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{

    private float moveDirection = 0f;
    private Vector2 mousePosition = Vector2.zero;
    private bool mouseMoved = false;
    private bool _mousePressed = false;
    private bool interectPressed = false;
    private bool movePressed = false;
    private bool stairsPressed = false;
    private bool mouseHold = false;
    private float stairsDirection = 0f;
    
    public static InputManager Instance
    {
        get;
        private set;
    }
    
    
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more then one Input Manager in the scene");
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        if (MainManager.Instance != null)
        {
            moveDirection = 0f;
            mousePosition = Vector2.zero;
            mouseMoved = false;
            _mousePressed = false;
            interectPressed = false;
            movePressed = false;
            stairsPressed = false;
            mouseHold = false;
            stairsDirection = 0f;
        }
    }

    public void MovePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            movePressed = true;
            moveDirection = context.ReadValue<float>();
        }
        else if (context.canceled)
        {
            movePressed = false;
            moveDirection = context.ReadValue<float>();
        }
    }

    public void MousePosition(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            mouseMoved = true;
            mousePosition = context.ReadValue<Vector2>();
        }
        else if(context.canceled)
        {
            mouseMoved = false;
            mousePosition = context.ReadValue<Vector2>();
        }
    }

    public void InteractionButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interectPressed = true;
        }
        else if (context.canceled)
        {
            interectPressed = false;
        }
    }

    public void MousePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _mousePressed = true;
        }
        else if (context.canceled)
        {
            _mousePressed = false;
        }
    }

    public void StairsPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            stairsPressed = true;
            stairsDirection = context.ReadValue<float>();
        }
        else if(context.canceled)
        {
            stairsPressed = false;
            stairsDirection = context.ReadValue<float>();
        }
    }

    public void MouseHold(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            mouseHold = true;
        }
        else if(context.canceled)
        {
            mouseHold = false;
        }
    }

    public float GetMoveDirection()
    {
        return moveDirection;
    }

    public Vector2 GetMousePosition()
    {
        return mousePosition;
    }

    public float GetStairsDirection()
    {
        return stairsDirection;
    }

    public bool GetMouseMoved()
    {
        bool result = mouseMoved;
        mouseMoved = false;
        return result;
    }

    public bool GetInteractPressed()
    {
        /*
        bool result = interectPressed;
        interectPressed = false;
        */
        return interectPressed;
    }

    public bool GetMousePressed()
    {
        bool result = _mousePressed;
        _mousePressed = false;
        return result;
    }
    
    public bool GetMovePressed()
    {
        bool result = movePressed;
        movePressed = false;
        return result;
    }

    public bool GetStairsPressed()
    {
        bool result = stairsPressed;
        stairsPressed = false;
        return result;
    }

    public bool GetMouseHold()
    {
        /*
        bool result = mouseHold;
        mouseHold = false;
        */
        return _mousePressed;
    }
    
    public void RegisterMousePressed()
    {
        _mousePressed = false;
    }

    public void RegisterInteractionPressed()
    {
        interectPressed = false;
    }
}
