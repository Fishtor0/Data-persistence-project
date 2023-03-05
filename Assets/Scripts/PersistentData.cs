using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class  PersistentData : MonoBehaviour
{

    public string currentPlayerName;
    public int highScore;
    public string topPlayer;
    public static PersistentData persistentData;
    // Start is called before the first frame update
    public void Start()
    {
       if(persistentData != null)
        {
            Destroy(gameObject);
        }
        persistentData = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();

    }

    public void SetTopPlayer(string newPlayerName)
    {
        topPlayer = newPlayerName;
    }
    public void SetHighScore(int newScore)
    {
        highScore = newScore;
    }

    public void SetCurrentPlayerName(string playerName)
    {
        currentPlayerName = playerName;
    }
    [System.Serializable]
    class SavedData
    {
        public int highScore;
        public string topPlayer; 
    }

    public void SaveHighScore()
    {
        SavedData data = new SavedData();

        data.highScore = highScore;
        data.topPlayer = topPlayer;

        string json = JsonUtility.ToJson(data);
            
        File.WriteAllText(Application.persistentDataPath + "/savedFile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savedFile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SavedData data = JsonUtility.FromJson<SavedData>(json);

            highScore = data.highScore;
            topPlayer = data.topPlayer;
        }
    }
}
