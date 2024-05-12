using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class InventoryTest : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    private bool _isOnPanel = false;
    private float lerpDuration = 0.5f;
    private float timeElapsed;
    private Vector3 startValue;
    private Vector3 endValue;
    
    private enum UI_State
    {
        OPEN,
        ON_OPEN,
        CLOSE
    }

    private UI_State _uıState;
    

    private void Start()
    {
        startValue = transform.position;
        endValue = startValue + new Vector3(0, 35, 0);
        _uıState = UI_State.CLOSE;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isOnPanel = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isOnPanel = false;
    }

    private void Update()
    {
        if (_uıState == UI_State.CLOSE)
        {
            if (_isOnPanel)
            {
                timeElapsed = 0;
                _uıState = UI_State.ON_OPEN;
            }
        }
        else if (_uıState == UI_State.OPEN)
        {
            if (!_isOnPanel)
            {
                timeElapsed = 0;
                _uıState = UI_State.ON_OPEN;
            }
        }
        else if (_uıState == UI_State.ON_OPEN)
        {
            if (timeElapsed < lerpDuration)
            {
                if (_isOnPanel)
                {
                    transform.position = Vector3.Lerp(startValue,endValue,timeElapsed / lerpDuration);
                    timeElapsed += Time.deltaTime;
                }
                else
                {
                    transform.position = Vector3.Lerp(endValue,startValue,timeElapsed / lerpDuration);
                    timeElapsed += Time.deltaTime;
                }
            }
            else
            {
                if (_isOnPanel)
                {
                    transform.position  = endValue;
                    _uıState = UI_State.OPEN;
                }
                else
                {
                    transform.position  = startValue;
                    _uıState = UI_State.CLOSE;
                }
            }
        }
    }
}
