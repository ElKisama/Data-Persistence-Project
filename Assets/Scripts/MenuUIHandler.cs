using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameField;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private Button startButton;
    public static MenuUIHandler Instance;
    public string playerName;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        startButton.interactable = false;
        ScoreManager.Instance.LoadHighScoreData();
        
        
        bestScoreText.SetText($"Best Score - {ScoreManager.Instance.bestPlayerName}: {ScoreManager.Instance.bestPlayerScore}");
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void SaveText()
    {
        playerName = nameField.text;
        ScoreManager.Instance.currentPlayerName = playerName;
        startButton.interactable = true;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
