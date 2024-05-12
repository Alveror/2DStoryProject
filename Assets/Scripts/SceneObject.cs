using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New SceneObject", menuName = "ScriptableObjects/SceneObject")]
public class SceneObject : ScriptableObject
{
    [SerializeField] private string[] sceneCharacters;
    [SerializeField] private bool isSceneMorning;
    [SerializeField] private bool isSceneOpen;

    public string[] SceneCharacters => sceneCharacters;
    public bool IsSceneMorning => isSceneMorning;
    public bool IsSceneOpen => isSceneOpen;
}
