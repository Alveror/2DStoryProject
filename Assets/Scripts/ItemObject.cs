using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemObject", menuName = "ScriptableObjects/ItemObject")]
public class ItemObject : ScriptableObject
{
    public enum ItemEnum
    {
        TEXT,
        KEY,
        STORY
    }
    [Header("Item Properties")]
    [SerializeField] private string itemName;
    [TextArea] [SerializeField] private string itemDescrpition;
    [SerializeField] private bool isItemTaken;
    [SerializeField] private ItemEnum itemType;


    [Header("Glow Material")] 
    [SerializeField] private Material glowMaterial;

    public string ItemName => itemName;
    public string ItemDescription => itemDescrpition;
    public ItemEnum ItemType => itemType;
    public Material GlowMaterial => glowMaterial;
    public bool IsItemTaken
    {
        get => isItemTaken;
        set => isItemTaken = value;
    }
    
    
    

}
