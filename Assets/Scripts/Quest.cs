using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "ScriptableObjects/Quest")]
public class Quest : ScriptableObject
{
    public enum QuestStates
    {
        PASSIVE,
        ACTIVE,
        FINISHED,
    }
    
    [SerializeField] private string neededItem;
    [SerializeField] private TextAsset normalDialogue;
    [SerializeField] private TextAsset earlyDialogue;
    [SerializeField] private QuestStates questState;

    public string NeededItem => neededItem;
    public TextAsset NormalDialogue => normalDialogue;
    public TextAsset EarlyDialogue => earlyDialogue;

    public QuestStates QuestState
    {
        get => questState;
        set => questState = value;
    }
}
