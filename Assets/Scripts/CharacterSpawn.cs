using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    [SerializeField] private LocationObject _locationObject;
    private void OnEnable()
    {
        GameObject[] NPCs = GameObject.FindGameObjectsWithTag("NPC");
        
        foreach (GameObject NPC in NPCs)
        {
           NPC.SetActive(false); 
        }
        
        foreach (GameObject NPC in NPCs)
        {
            foreach (string sceneCharacter in _locationObject.LocationScenes[_locationObject.CurrentScene].SceneCharacters)
            {
                if (NPC.name == sceneCharacter)
                {
                    NPC.SetActive(true);
                }
            }
        }
    }
}
