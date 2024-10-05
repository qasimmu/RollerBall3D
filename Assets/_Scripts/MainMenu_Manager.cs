﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu_Manager : MonoBehaviour
{

    public static MainMenu_Manager instance;

    public string NextScene;
    public string PreviousScene;

    [Header("Loading Screen")]
    public Image LoadingBar;
    public Text loading_Text;
    public GameObject loadingPanel;
    public float loadingDelayTime = 2f; 


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    void Start()
    {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        OnStartInitialize();

    }

    public void OnStartInitialize()
    {
        Time.timeScale = 1f;

    }

    public void PlayButtonClickSound()
    {
        if (SoundManager._SoundManager)
        {
            SoundManager._SoundManager.playButtonClickSound();

        }
    }

    public void Play()
    {
PlayButtonClickSound();
        StartCoroutine(LoadSceneWithDelay(NextScene));
    }

    void UpdateLoadingUI(float progress)
    {
        if (LoadingBar) LoadingBar.fillAmount = progress;
        if (loading_Text) loading_Text.text = Mathf.RoundToInt(progress * 100) + "%";
    }
    IEnumerator LoadSceneWithDelay(string name)
    {

if(loadingDelayTime>0){
        loadingPanel.SetActive(true);

}
        float timer = 0f;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name);
        asyncOperation.allowSceneActivation = false;
        while (timer < loadingDelayTime)
        {
            timer += Time.deltaTime;
            float fillAmount = Mathf.Clamp01(timer / loadingDelayTime);
            UpdateLoadingUI(fillAmount);
            yield return null;
        }
        yield return new WaitForSeconds(1f);

        asyncOperation.allowSceneActivation = true;

    }
    
    public void OpenGithubLink()
    {
PlayButtonClickSound();

        Application.OpenURL("https://github.com/qasimmu/RollerBall3D.git");
    }
    
        public void OpenItchio()
    {
PlayButtonClickSound();

        Application.OpenURL("https://rainbow-flamingo.itch.io/3d-roller-ball");
    }
    

}
