using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bed : MonoBehaviour
{
    // [SerializeField] private TextMeshProUGUI mouseText;
    [SerializeField] private Quest _questActiveTrigger;
    [SerializeField] private Quest _questFinishedTrigger;
    [SerializeField] private Material _glowMaterial;

    private SpriteRenderer _spriteRenderer;
    private Material _defaultMaterial;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultMaterial = _spriteRenderer.material;
    }

    private void Update()
    {
        // if (InputManager.Instance.GetInteractPressed() && _onTrigger)
        // {
        //     StartCoroutine(LevelLoader.Instance.SkipTime());
        // }
        if (_questActiveTrigger.QuestState == Quest.QuestStates.ACTIVE || _questFinishedTrigger.QuestState == Quest.QuestStates.FINISHED)
        {
            if (MouseManager.Instance.GetCollidedObject() != null)
            {
                if (MouseManager.Instance.GetCollidedObject() == this.gameObject)
                {
                    if (MouseManager.Instance.GetMouseState() == MouseManager.MouseState.MOUSEENTER)
                    {
                        if (!DialogManager.Instance.dialogueIsPlaying && !InventoryManager.Instance._isMouseInUse)
                        {
                            _spriteRenderer.material = _glowMaterial;
                            // mouseText.gameObject.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position + Vector3.up);
                            // mouseText.text = "Sleep";
                            // mouseText.gameObject.SetActive(true);
                        }
                    }
                    else if (MouseManager.Instance.GetMouseState() == MouseManager.MouseState.MOUSEOVER)
                    {
                        if (InputManager.Instance.GetMousePressed() && !DialogManager.Instance.dialogueIsPlaying && !InventoryManager.Instance._isMouseInUse)
                        {
                            StartCoroutine(LevelLoader.Instance.SkipTime());
                        }
                    }
                    else if (MouseManager.Instance.GetMouseState() == MouseManager.MouseState.MOUSEEXIT && !InventoryManager.Instance._isMouseInUse)
                    {
                        _spriteRenderer.material = _defaultMaterial;
                        // mouseText.text = "";
                        // mouseText.gameObject.SetActive(false);
                    }
                    else
                    {
                        _spriteRenderer.material = _defaultMaterial;
                    }
                }
            }
        }

    }
}
