using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn : MonoBehaviour
{
    public void GoToScene (int scene) {
        print(scene);
        SceneManager.LoadScene(scene);
    }
}
