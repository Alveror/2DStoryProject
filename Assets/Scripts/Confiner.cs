using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Confiner : MonoBehaviour
{
    private GameObject _vrCamera;
    private void Start()
    {
        _vrCamera = GameObject.FindWithTag("Camera");
        _vrCamera.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = gameObject.GetComponent<PolygonCollider2D>();;
        _vrCamera.GetComponent<CinemachineVirtualCamera>().m_Follow = GameObject.FindWithTag("Player").transform;

    }
}
