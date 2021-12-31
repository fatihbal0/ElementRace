using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    Save saveScript;
    private void Awake() 
    {
        saveScript = GetComponent<Save>();
        saveScript.LoadGame();
    }















    // private void Awake()
    // {

    //     /*int levelNo = PlayerPrefs.GetInt("LevelNo");
    //     Debug.Log(PlayerPrefs.GetInt("LevelNo"));
    //     //string loadingScene = levelNo.ToString();
    //     SceneManager.LoadScene(levelNo);
    //     */

    // if (PlayerPrefs.HasKey("LevelNo"))
	// {
	// 	int levelNo = PlayerPrefs.GetInt("LevelNo");
	// 	Debug.Log("Game data loaded!");
    //     SceneManager.LoadScene(levelNo);
	// }
	// else
    // {
	// 	Debug.Log("There is no save data!");
    //     SceneManager.LoadScene("TutorialLevel");
    // }

    //     // int levelNo;
    //     // if(PlayerPrefs.HasKey("LevelNo"))
    //     // {
    //     //     levelNo = PlayerPrefs.GetInt("LevelNo");
    //     // }
    //     // else
    //     // {
    //     // levelNo = 1;
    //     // }

    //     // if(PlayerPrefs.HasKey("LevelNoText"))
    //     // {
    //     //     Debug.Log("key var");
    //     // }
    //     // else
    //     // {
    //     // PlayerPrefs.SetInt("LevelNoText", 1);
    //     // PlayerPrefs.Save();
    //     // Debug.Log("key yok");
    //     // Debug.Log(PlayerPrefs.GetInt("LevelNoText"));
    //     // }
        
    //     // //int levelNo = PlayerPrefs.GetInt("LevelNo", 1);
    //     // //string loadingScene = levelNo.ToString();
    //     // SceneManager.LoadScene(levelNo);

    
    //}
}