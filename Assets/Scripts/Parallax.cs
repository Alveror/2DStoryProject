using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public Camera cam;
    public Transform subject;

    Vector2 startPosition;
    float startZ;
    Vector2 travel => (Vector2)cam.transform.position - startPosition;

    float distanceFromSubject => transform.position.z - subject.position.z;
    float clippingPlane =>(cam.transform.position.z +(distanceFromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane ));
    float parallaxFactor => Mathf.Abs(distanceFromSubject) / clippingPlane;

    // Start is called before the first frame update
    void Start()
    {
        subject = GameObject.FindWithTag("Player").transform;
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        startPosition = transform.position;
        startZ = transform.position.z;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 newPos = startPosition + travel * parallaxFactor;
        transform.position = new Vector3(newPos.x, startPosition.y, startZ);
    }
}
