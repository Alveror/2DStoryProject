using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _mouseText;
    
    private enum HoverState{HOVER, NONE};
    public enum MouseState
    {
        NONE,
        MOUSEENTER,
        MOUSEEXIT,
        MOUSEOVER
    }

    private HoverState _hoverState = HoverState.NONE;
    private MouseState _mouseState = MouseState.NONE;

    private bool _isEnter = false;
    private bool _isExit = false;
    
    private GameObject targetObject = null;
    
    public static MouseManager Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more then one Mouse Manager in the scene");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        _mouseText.gameObject.SetActive(false);
    }

    private void Start()
    {
        if (MainManager.Instance != null)
        {
            _hoverState = HoverState.NONE;
            _mouseState = MouseState.NONE;

            _isEnter = false;
            _isExit = false;
    
            targetObject = null;
        }
    }

    private void Update()
    {
        OnMouseMoved();
        
        /*
        if (targetObject != null && targetObject.CompareTag("Item") && _hoverState == HoverState.HOVER && !DialogManager.Instance.dialogueIsPlaying && !InventoryManager.Instance._isMouseInUse)
        {
            _mouseText.transform.position = Camera.main.WorldToScreenPoint(targetObject.transform.position + new Vector3(0,0.35f,0));
            if (targetObject.GetComponent<Item>().GetItemType() == Item.ItemType.TEXT)
            {
                _mouseText.text = "Read";
            }
            else
            {
                _mouseText.text = "Take";
            }
            _mouseText.gameObject.SetActive(true);
        }
        else if (_hoverState == HoverState.NONE)
        {
            _mouseText.gameObject.SetActive(false);
        }
        */
    }

    public MouseState GetMouseState()
    {
        return _mouseState;
    }

    public GameObject GetCollidedObject()
    {
        return targetObject;
    }

    private void OnMouseMoved()
    {
        Ray ray = Camera.main.ScreenPointToRay(InputManager.Instance.GetMousePosition());
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
        

        if (hit2D.collider != null)
        {

            targetObject = hit2D.collider.gameObject;
                
            if (_hoverState == HoverState.NONE)
            {
                // _mouseState = MouseState.MOUSEENTER;
                _isEnter = true;
            }

            _hoverState = HoverState.HOVER;
            _isExit = false;
            
        }
        
        else
        {
            if (_hoverState == HoverState.HOVER)
            {
                // _mouseState = MouseState.MOUSEEXIT;
                _isExit = true;
            }

            _hoverState = HoverState.NONE;
            _mouseState = MouseState.NONE;
            // targetObject = null;
        }

        if (_hoverState == HoverState.HOVER && !_isEnter && !_isExit)
        {
            _mouseState = MouseState.MOUSEOVER;
        }
        if (_isEnter)
        {
            _mouseState = MouseState.MOUSEENTER;
        }
        if (_isExit)
        {
            _mouseState = MouseState.MOUSEEXIT;
            _isExit = false;
        }
        
        _isEnter = false;
        
    }
    
}
