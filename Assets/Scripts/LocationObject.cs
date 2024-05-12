using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New LocationObject", menuName = "ScriptableObjects/LocationObject")]
public class LocationObject : ScriptableObject
{
    [SerializeField] private int loadIndex;
    [SerializeField] private int currentScene;
    [SerializeField] private SceneObject[] locationScenes;
    [SerializeField] private Vector3 locationEnter;
    [SerializeField] private Vector3 locationExit;
    
    public SceneObject[] LocationScenes => locationScenes;
    public Vector3 LocationEnter => locationEnter;
    public Vector3 LocationExit => locationExit;
    public int LoadIndex
    {
        get => loadIndex;
        set => loadIndex = value;
    }
    
    public int CurrentScene
    {
        get => currentScene;
        set => currentScene = value;
    }

}
