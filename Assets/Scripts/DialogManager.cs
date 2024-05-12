using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using TMPro;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UIElements;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class DialogManager : MonoBehaviour
{

    [SerializeField] private CharacterList _characters;

    [Header("Parameters")] 
    [SerializeField] private float typingSpeed = 0.04f;

    [Header("Load Globals Ink File")] 
    [SerializeField] private TextAsset loadGlobalsJSON;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private GameObject choicePanel;
    [SerializeField] private TextMeshProUGUI dialogText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;

    [Header("Characters Setup")]


    private Dictionary<string, Character> _charactersDictionary;

    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    private Color textColor;
    
    private const string SPEAKER_TAG = "speaker";
    private const string QUEST_TAG = "quest";

    private GameObject Player;
    private Vector3 _playerPanelPos;
    private Vector3 _npcPanelPos;
    private Vector3 _choicePanelPos;

    public bool dialogueIsPlaying { get; private set; }

    private Coroutine displayLineCoroutine;

    private DialogVariables _dialogVariables;
    
    private string _currentTalker;

    public static DialogManager Instance 
    { 
        get;
        private set; 
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Found more than one Dialog Manager in the scene");
            Destroy(gameObject);
            return;
        }
        Instance = this;

        _dialogVariables = new DialogVariables(loadGlobalsJSON);
        
        _charactersDictionary = new Dictionary<string, Character>();


        foreach (Character character in _characters.CharList)
        {
            _charactersDictionary.Add(character.CharName,character);
        }

    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialogPanel.SetActive(false);
        choicePanel.SetActive(false);
        
        choicesText = new TextMeshProUGUI[choices.Length];
        
        Player = GameObject.FindGameObjectWithTag("Player");
        
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
        
    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }

        if (currentStory.currentChoices.Count == 0 && InputManager.Instance.GetMousePressed())
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialogPanel.SetActive(true);
        
        _dialogVariables.StartListening(currentStory);
        
        // _playerPanelPos = Camera.main.WorldToScreenPoint(Player.transform.position + new Vector3(-0.3f,0.7f,0));
        // _choicePanelPos = Camera.main.WorldToScreenPoint(Player.transform.position + new Vector3(0,1.5f,0));
        // _npcPanelPos = Camera.main.WorldToScreenPoint(MouseManager.Instance.GetCollidedObject().transform.position + new Vector3(-0.3f,0.7f,0));

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        
        _dialogVariables.StopListening(currentStory);
        
        dialogueIsPlaying = false;
        dialogPanel.SetActive(false);
        dialogText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            

            HandleTags(currentStory.currentTags);

            //currentStory.variablesState.Assign();
            
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(":");
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropriately parsed:" + tag);
            }

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    //Debug.Log("speaker=" + tagValue);
                    if (tagValue == "Player")
                    {
                         dialogPanel.transform.position = Camera.main.WorldToScreenPoint(Player.transform.position + new Vector3(0,0.7f,0));
                         dialogText.color = Color.white;
                    }
                    else
                    {
                        dialogPanel.transform.position = Camera.main.WorldToScreenPoint(GetCharacterPos(tagValue) + new Vector3(0,0.7f,0));
                        dialogText.color = GetCharacterTextColor(tagValue);
                        _currentTalker = tagValue;
                    }
                    break;

                case QUEST_TAG:
                    if (_currentTalker != null)
                    {
                        _charactersDictionary[_currentTalker].QuestList.FindQuest(tagValue).QuestState = Quest.QuestStates.ACTIVE;
                    }
                    break;


                default:
                    Debug.LogWarning("Tag come in but is not currently being handled" + tag);
                    break;
            }
        }
    }

    private void DisplayChoices()
    {

        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("UI supported choice number:" + currentChoices.Count);
        }

        if (currentChoices.Count > 0 )
        {
            choicePanel.transform.position = Camera.main.WorldToScreenPoint(Player.transform.position  + new Vector3(0,0.7f,0)); // 0.75f
            choicePanel.SetActive(true);
        }
        else
        {
            choicePanel.SetActive(false);
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
        
    }
    
    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        //InputManager.Instance.RegisterMousePressed();
        ContinueStory();
    }
    
    // public void SetTextColor(Color color)
    // {
    //     textColor = color;
    // }

    private IEnumerator DisplayLine(string line)
    {
        dialogText.text = "";

        bool isAddingRichTextTag = false;
        choicePanel.SetActive(false);
        
        foreach (char letter in line.ToCharArray())
        {
            if (letter == '<' || isAddingRichTextTag)
            {
                isAddingRichTextTag = true;
                dialogText.text += letter;
                if (letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            else if (letter == '\n')
            {
                DisplayChoices();
            }
            else
            {
                dialogText.text += letter;
                yield return new WaitForSeconds(typingSpeed);   
            }
        }
        
    }

    private Vector3 GetCharacterPos(string tagValue)
    {
        return _charactersDictionary[tagValue].Position;
    }

    private Color GetCharacterTextColor(string tagValue)
    {
        return tagValue == "Player" ? Color.white : _charactersDictionary[tagValue].TextColor;
    }
    
    
    
}
