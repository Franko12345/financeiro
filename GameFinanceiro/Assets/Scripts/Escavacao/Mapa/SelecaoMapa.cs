using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SelecaoMapa : MonoBehaviour
{
    public string NameScene;
    public bool lockScene;

    /*private void Awake()
    {
        if (lockScene && PlayerPrefs.HasKey("lockand" + NameScene))
        {
            if (PlayerPrefs.GetInt("lockand" + NameScene) == 0)
            {
                PlayerPrefs.SetInt("lockand" + NameScene, 1);
            }
        }
        else if (lockScene)
        {
            PlayerPrefs.SetInt("lockand" + NameScene, 1);
        }
    }*/

    private void OnMouseDown()
    {
        {/* if (lockScene)
         {
             print(PlayerPrefs.HasKey("lockand" + NameScene));
             if (PlayerPrefs.HasKey("lockand" + NameScene))
             {
                 if (PlayerPrefs.GetInt("lockand" + NameScene) == 1) {
                     PlayerPrefs.SetInt("lockand" + NameScene, 2);
                     SceneManager.LoadScene(NameScene);
                 }
             }
         }
         else 
         {
             SceneManager.LoadScene(NameScene);
         }
         }*/}
        SceneManager.LoadScene(NameScene);
    }
}