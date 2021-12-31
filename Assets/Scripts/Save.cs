using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Save : MonoBehaviour
{

    [SerializeField]
    Text levelText;



    public int LevelNo = 1;
    public string LevelNoText = "1";

    private void Awake()
    {
        LevelNo = SceneManager.GetActiveScene().buildIndex;
        levelText.text = LevelNo.ToString();
    }

    public void SaveGame()
    {
        if(LevelNo == 7)
        {
            LevelNo = 0;
        }
        else
        {
            LevelNo = LevelNo + 1;
        }
        
        SaveScript.SaveGame(this);
        SceneManager.LoadScene(LevelNo);
    }
    public void LoadGame()
    {
        SaveData data = SaveScript.LoadGame();

        LevelNo = data.LevelNo;
        LevelNoText = data.LevelNoText;
        SceneManager.LoadScene(LevelNo);
    }

    public void RetryScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
