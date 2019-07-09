using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetomarJogo : MonoBehaviour
{
    public GameObject pauseMenu;

    private void OnMouseDown () {
        play();
        pauseMenu.SetActive(false);
    }

    void play () {
        Time.timeScale = 1;
    }
}
