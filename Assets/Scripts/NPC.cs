using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    [SerializeField] private Character character;

    private SpriteRenderer _spriteRenderer;
    private Material _defaultMaterial;
    // private bool _enterDialogue = false;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultMaterial = _spriteRenderer.material;
        
    }

    private void Start()
    {
        character.Position = gameObject.transform.position;
    }

    private void Update()
    {
        if (MouseManager.Instance.GetCollidedObject() != null)
        {
            if (MouseManager.Instance.GetCollidedObject() == this.gameObject)
            {
                if (MouseManager.Instance.GetMouseState() == MouseManager.MouseState.MOUSEENTER)
                {
                    if (!DialogManager.Instance.dialogueIsPlaying && !InventoryManager.Instance._isMouseInUse)
                    {
                        _spriteRenderer.material = character.GlowMaterial;   
                    }
                }
                else if (MouseManager.Instance.GetMouseState() == MouseManager.MouseState.MOUSEOVER)
                {
                    if (InputManager.Instance.GetMousePressed() && !DialogManager.Instance.dialogueIsPlaying && !InventoryManager.Instance._isMouseInUse)
                    {
                        // DialogManager.Instance.SetTextColor(textColor);
                        // _enterDialogue = true;
                        DialogManager.Instance.EnterDialogueMode(character.Dialogues[character.SceneIndex]);
                    }
                }
                else if (MouseManager.Instance.GetMouseState() == MouseManager.MouseState.MOUSEEXIT && !InventoryManager.Instance._isMouseInUse)
                {
                    _spriteRenderer.material = _defaultMaterial;
                }
                else
                {
                    _spriteRenderer.material = _defaultMaterial;
                }
            }
        }
    }

    /*
    private void LateUpdate()
    {
        if (_enterDialogue)
        {
            DialogManager.Instance.EnterDialogueMode(_sceneDialogues[sceneIndex]);
            _enterDialogue = false;
        }
    }
    */
    
    public Character GetCharacter()
    {
        return character;
    }

}
