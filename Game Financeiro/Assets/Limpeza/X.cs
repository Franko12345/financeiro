using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class X : MonoBehaviour
{
    public peca p;
    private void OnMouseDown () {
        if (p == null) SceneManager.LoadScene("menu");
        if (p.pronta) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else {
            SceneManager.LoadScene("menu");
        }
    }
}
