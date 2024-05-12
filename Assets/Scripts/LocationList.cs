using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LocationList", menuName = "ScriptableObjects/LocationList")]
public class LocationList : ScriptableObject
{
    [SerializeField] private LocationObject[] locationObjects;

    public LocationObject[] LocationObjects => locationObjects;
}
