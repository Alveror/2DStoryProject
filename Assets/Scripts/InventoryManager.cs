using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Ink.Runtime;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    [Header("Inventory UI")] 
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject[] slotButtons;
    [SerializeField] private GameObject mousePanel;
    [SerializeField] private TextMeshProUGUI mouseText;
    
    private GameObject[] _inventory;
    private int _selectedItem;
    
    public bool _isMouseInUse { get; private set; }

    public static InventoryManager Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more then one Inventory Manager in the scene");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        _inventory = new GameObject[slotButtons.Length];
        _isMouseInUse = false;
    }

    private void Start()
    {
        for (int slot = 0; slot < slotButtons.Length; slot++)
        {
            slotButtons[slot].SetActive(false);
        }
        mousePanel.SetActive(false);
    }

    public void AddItem(GameObject item)
    {
        for (int slot = 0; slot < _inventory.Length; slot++)
        {
            if (_inventory[slot] == null)
            {
                item.SetActive(false);
                item.GetComponent<Item>().GetItemObject().IsItemTaken = false;
                _inventory[slot] = Instantiate(item,gameObject.transform);
                slotButtons[slot].GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
                slotButtons[slot].SetActive(true);
                return;
            }
        }
    }
    

    public void RemoveItem()
    {
        Destroy(_inventory[_selectedItem]);
        _inventory[_selectedItem] = null;
        slotButtons[_selectedItem].GetComponent<Image>().sprite = null;
        slotButtons[_selectedItem].SetActive(false);
    }

    public void SelectItem(int selectedIndex)
    {
        if (!_isMouseInUse)
        {
            _selectedItem = selectedIndex;
            mousePanel.GetComponent<Image>().sprite = slotButtons[selectedIndex].GetComponent<Image>().sprite;
            mousePanel.transform.position = InputManager.Instance.GetMousePosition();
            mousePanel.SetActive(true);
            _isMouseInUse = true;
            Debug.Log("Test");
        }
    }

    private void Update()
    {
        if (mousePanel.activeInHierarchy)
        {
            mousePanel.transform.position = InputManager.Instance.GetMousePosition();
            UseItem();

            if (Mouse.current.rightButton.isPressed)
            {
                mousePanel.SetActive(false);
                _isMouseInUse = false;
            }
        }
    }

    private void UseItem()
    {
        GameObject targetObject = MouseManager.Instance.GetCollidedObject();
        GameObject targetItem = _inventory[_selectedItem];
        if (_isMouseInUse)
        {
            if (targetObject != null && targetObject.CompareTag("NPC") && MouseManager.Instance.GetMouseState() == MouseManager.MouseState.MOUSEOVER)
            {
                mouseText.gameObject.transform.position = Camera.main.WorldToScreenPoint(MouseManager.Instance.GetCollidedObject().transform.position + new Vector3(0,0.7f,0));
                mouseText.text = "Give";
                mouseText.gameObject.SetActive(true);

                if (Mouse.current.leftButton.isPressed)
                {
                    InputManager.Instance.RegisterMousePressed();
                    
                    Quest targetQuest = targetObject.GetComponent<NPC>().GetCharacter().QuestList.FindQuest(targetItem.GetComponent<Item>().GetItemObject().ItemName);
                    
                    if (targetQuest != null)
                    {
                        if (targetQuest.QuestState == Quest.QuestStates.ACTIVE)
                        {
                            DialogManager.Instance.EnterDialogueMode(targetQuest.NormalDialogue);
                            targetQuest.QuestState = Quest.QuestStates.FINISHED;
                        }
                        else
                        {
                            DialogManager.Instance.EnterDialogueMode(targetQuest.EarlyDialogue);
                        }
                        
                        RemoveItem();
                        mousePanel.SetActive(false);
                        mouseText.gameObject.SetActive(false);
                        _isMouseInUse = false;
                    }
                    else
                    {
                        targetObject.GetComponent<SpriteRenderer>().color = Color.red;
                    }
                }
            }
            else
            {
                mouseText.gameObject.SetActive(false);
            }
        }
    }
}
