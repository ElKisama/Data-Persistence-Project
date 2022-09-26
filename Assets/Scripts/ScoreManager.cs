using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public string currentPlayerName;
    public string bestPlayerName;
    public int bestPlayerScore;
    
    [System.Serializable]
    class SaveData
    {
        public string savedName;
        public int savedScore;
    }

    public void SaveHighScoreData(string playerName, int playerScore)
    {
        SaveData data = new SaveData();
        data.savedName = playerName;
        data.savedScore = playerScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScoreData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.savedName;
            bestPlayerScore = data.savedScore;
        }
    }

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
}
