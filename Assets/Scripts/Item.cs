using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    [SerializeField] private ItemObject itemObject;

    private SpriteRenderer _spriteRenderer;
    private Material _defaultMaterial;
    
    // private Dictionary<string, TextAsset> dialogueList;
    
    private void Awake()
    {

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultMaterial = _spriteRenderer.material;

    }

    private void Start()
    {
        if (itemObject.IsItemTaken)
        {
            Destroy(gameObject);
        }
        
        // dialogueList = new Dictionary<string, TextAsset>();
        //
        // TextAsset[] questDialogues = _itemState.GetQuestDialogues();
        // string[] characterNames = _itemState.GetCharacterNames();
        //
        // if (questDialogues.Length != characterNames.Length)
        // {
        //     Debug.LogWarning("Quest dialogues and names are not the same length in ItemState");
        // }
        // else
        // {
        //     for (int i = 0; i < _itemState.GetQuestDialogues().Length; i++)
        //     {
        //         dialogueList.Add(characterNames[i],questDialogues[i]);
        //     }
        // }
    }

    private void Update()
    {
        if (MouseManager.Instance.GetCollidedObject() != null)
        {
            if (MouseManager.Instance.GetCollidedObject() == this.gameObject)
            {
                if (MouseManager.Instance.GetMouseState() == MouseManager.MouseState.MOUSEENTER)
                {
                    if (!DialogManager.Instance.dialogueIsPlaying)
                    {
                        _spriteRenderer.material = itemObject.GlowMaterial;   
                    }
                }
                else if (MouseManager.Instance.GetMouseState() == MouseManager.MouseState.MOUSEOVER)
                {
                    if (InputManager.Instance.GetMousePressed() && !DialogManager.Instance.dialogueIsPlaying && !InventoryManager.Instance._isMouseInUse)
                    {
                        if (itemObject.ItemType == ItemObject.ItemEnum.TEXT)
                        {
                            Debug.Log(itemObject.ItemDescription);
                        }
                        else if (itemObject.ItemType == ItemObject.ItemEnum.KEY)
                        {
                            InventoryManager.Instance.AddItem(this.gameObject);
                            Destroy(gameObject);
                        }
                        else if (itemObject.ItemType == ItemObject.ItemEnum.STORY)
                        {
                            InventoryManager.Instance.AddItem(this.gameObject);
                            Destroy(gameObject);
                        }
                    }
                }
                else if (MouseManager.Instance.GetMouseState() == MouseManager.MouseState.MOUSEEXIT)
                {
                    _spriteRenderer.material = _defaultMaterial;
                }
            }
        }
    }
    

    public ItemObject GetItemObject()
    {
        return itemObject;
    }
    
    
}
