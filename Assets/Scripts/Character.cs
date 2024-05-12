using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "ScriptableObjects/Character")]
public class Character : ScriptableObject
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private string charName;
    [SerializeField] private Vector3 position;

    [SerializeField] private TextAsset[] dialogues;
    [SerializeField] private QuestList questList;
    [SerializeField] private int sceneIndex;

    [SerializeField] private Material glowMaterial;
    [SerializeField] private Color textColor;

    public GameObject Prefab => prefab;
    public string CharName => charName;
    public TextAsset[] Dialogues => dialogues;
    public QuestList QuestList => questList;

    public int SceneIndex
    {
        get => sceneIndex;
        set => sceneIndex = value;
    }

    public Vector3 Position
    {
        get => position;
        set => position = value;
    }
    
    

    public Material GlowMaterial => glowMaterial;

    public Color TextColor => textColor;
}
