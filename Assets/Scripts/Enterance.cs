using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enterance : MonoBehaviour
{
    [SerializeField] private LocationObject _locationObject;
    [SerializeField] private int LoadIndex;
    [SerializeField] private bool isEnter;
    
    
    private bool _onTrigger = false;

    private void Update()
    {
        //Debug.Log(_onTrigger);
        if (InputManager.Instance.GetInteractPressed() && _onTrigger && _locationObject.LocationScenes[_locationObject.CurrentScene].IsSceneOpen)
        {
            LevelLoader.Instance.LoadSelectedLevel(_locationObject,LoadIndex,isEnter);
            InputManager.Instance.RegisterInteractionPressed();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _onTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _onTrigger = false;
        }
    }

    /*
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _isPressed)
        {
            _onTrigger = t
            Debug.Log("Test");
            LevelLoader.Instance.LoadSelectedLevel(sceneIndex);
        }
    }
    */
    
}
