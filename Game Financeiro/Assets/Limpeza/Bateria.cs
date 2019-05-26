using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bateria : MonoBehaviour
{
    float tempo = 30f;
    float cont = 0;
    float originalScale;
    float scale;
    void Start()
    {
        originalScale = transform.localScale.x;
        scale = originalScale;
        cont = tempo;
    }

    // Update is called once per frame
    void Update()
    {
        if (cont > 0) {
            cont -= Time.deltaTime;
            float f = cont/tempo;
            scale = f * originalScale;
            transform.localScale =
                new Vector3(scale , transform.localScale.y , transform.localScale.z);
        } else {
            SceneManager.LoadScene("menu");
        }
    }
}
