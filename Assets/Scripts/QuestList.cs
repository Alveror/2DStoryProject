using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New QuestList", menuName = "ScriptableObjects/QuestList")]
public class QuestList : ScriptableObject
{
    [SerializeField] private Quest[] quests;

    public Quest[] Quests => quests;

    public Quest FindQuest(string questItemName)
    {
        if (quests == null) return null;
        
        foreach (Quest quest in quests)
        {
            if (quest.NeededItem == questItemName)
            {
                return quest;
            }
        }

        return null;
    }
}
