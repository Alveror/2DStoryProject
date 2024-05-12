using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainFollow : MonoBehaviour
{

    private GameObject _player;
    private void Start()
    {
        gameObject.transform.position = Vector3.zero;
        _player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (_player != null)
        {
            Vector3 position = new Vector3(_player.transform.position.x, 0, 0);
            gameObject.transform.position = position;
        }
    }
}
