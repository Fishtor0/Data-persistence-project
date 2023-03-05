using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

[DefaultExecutionOrder(1000)]
public class MenuScript : MonoBehaviour
{

    public TextMeshProUGUI highScroreText;
    

    // Start is called before the first frame update
    void Start()
    {
        highScroreText.SetText("High Score: " + PersistentData.persistentData.topPlayer + ": " + PersistentData.persistentData.highScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrentPlayerName(string newPlayerName)
    {
        PersistentData.persistentData.SetCurrentPlayerName(newPlayerName);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else

        Application.Quit();
#endif
    }
}
