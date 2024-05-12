using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private LocationList locationList;
    

    public static LevelLoader Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Found more than one Level Loader in the scene");
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }

    public void LoadSelectedLevel(LocationObject location,int ExitIndex,bool isEnter)
    {
        if (location.LocationScenes[location.CurrentScene].IsSceneMorning)
        {
            StartCoroutine(LoadLevel(location.LoadIndex,ExitIndex,isEnter));
        }
        else
        {
            StartCoroutine(LoadLevel(location.LoadIndex+1,ExitIndex,isEnter));
        }
    }

    private IEnumerator LoadLevel(int locationIndex,int ExitIndex,bool isEnter)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        
        ChangePlayerPos(ExitIndex,isEnter);
        
        SceneManager.LoadScene(locationIndex);

    }

    public IEnumerator SkipTime()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        ChangeScenes();

        if (SceneManager.GetActiveScene().buildIndex % 2 == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
    

    private void ChangePlayerPos(int sceneIndex,bool isEnter)
    {

        foreach (LocationObject location in locationList.LocationObjects)
        {
            if (location.LoadIndex == sceneIndex)
            {
                if (isEnter)
                {
                    GameObject.FindGameObjectWithTag("Player").transform.position = location.LocationEnter;
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Player").transform.position = location.LocationExit;
                }
            }
        }

    }

    public void ChangeScenes()
    {
        foreach (LocationObject location in locationList.LocationObjects)
        {
            location.CurrentScene++;
        }
    }

}
