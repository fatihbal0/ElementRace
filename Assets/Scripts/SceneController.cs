// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;
// // using UnityEngine.SceneManagement;
// // using UnityEngine.UI;

// // public class SceneController : MonoBehaviour
// // {
    
// //     int _levelNoText;
// //     int levelNo;
// //     [SerializeField]
// //     Text levelText;
// //     private void Awake()
// //     {
        
// //         //_levelNoText = PlayerPrefs.GetInt("LevelNoText",1);
        
// //         levelNo = SceneManager.GetActiveScene().buildIndex;
// //         //_levelNoText = PlayerPrefs.GetInt("LevelNoText");
// //         //Debug.Log(levelNo);
// //         //levelNo = PlayerPrefs.GetInt("LevelNo");


// //         // if(PlayerPrefs.HasKey("LevelNoText"))
// //         // {
// //         //     _levelNoText = PlayerPrefs.GetInt("LevelNoText");
// //         //     Debug.Log("deger var");
// //         // }
// //         // else
// //         // {
// //         // _levelNoText = 1;
// //         // Debug.Log("deger yok");
// //         // }
// //         //levelText.text = _levelNoText.ToString();


// //     }

// //     private void Start()
// //     {
// //         _levelNoText = PlayerPrefs.GetInt("LevelNoText");
// //         levelText.text = _levelNoText.ToString();
// //     }
// //     public void NextScene()
// //     {
        
        
// //          if (levelNo == 8)
// //              levelNo = 1;
// //         levelNo++;
// //         _levelNoText++;
// //         PlayerPrefs.SetInt("LevelNo", levelNo);
// //         PlayerPrefs.SetInt("LevelNoText", _levelNoText);
// //         PlayerPrefs.Save();
// //         SceneManager.LoadScene("Loader");
// //         //PlayerPrefs.Save();

// //     }

// //     public void RetryScene()
// //     {
// //         SceneManager.LoadScene("Loader");
// //     }
// // }


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;

// public class SceneController : MonoBehaviour
// {
//     [SerializeField]
//     Text levelText;

//     int _levelNoText;
//     int _levelNo;
//     private void Start()
//     {
        
//         _levelNoText = GetInt("LevelNoText");

//         levelText.text = _levelNoText.ToString();
        
//         _levelNo = GetInt("LevelNo");
//         //_levelNo = SceneManager.GetActiveScene().buildIndex;
//     }

//     public void NextScene()
//     {
        
        
//          if (_levelNo == 8)
//              _levelNo = 1;
//         _levelNo++;
//         _levelNoText++;
//         SetInt("LevelNo", _levelNo);
//         SetInt("LevelNoText", _levelNoText);
//         Debug.Log(GetInt("LevelNoText"));
//         Debug.Log(GetInt("LevelNo"));
//         SceneManager.LoadScene("Loader");

//     }

//     public void RetryScene()
//     {
//         SceneManager.LoadScene("Loader");
//     }


// //----sets gets

//     public void SetInt(string KeyName, int Value)
//     {
//         PlayerPrefs.SetInt(KeyName, Value);
//         PlayerPrefs.Save();        
//     }

//     public int GetInt(string KeyName)
//     {
//         if(PlayerPrefs.HasKey(KeyName))
//         {
//             return PlayerPrefs.GetInt(KeyName);
//         }
//         else
//         {
//             return 0;
//         }
//     }
// }