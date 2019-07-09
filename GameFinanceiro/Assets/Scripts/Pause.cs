using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;

    private void OnMouseDown () {
        pause();
        pauseMenu.SetActive(true);
    }

    void pause() {
        Time.timeScale = 0;
    }
}
