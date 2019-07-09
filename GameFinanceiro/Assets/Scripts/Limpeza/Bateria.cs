using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bateria : MonoBehaviour
{
    public float tempo = 30f;
    public static float tempo2 =30f; //gambiarra pro playtest
    float cont = 0;
    float originalScale;
    float scale;
    public GameObject telaFim;

    void Start()
    {
        originalScale = transform.localScale.x;
        scale = originalScale;
        cont = tempo;
        Bateria.tempo2 = tempo;
    }

    // Update is called once per frame
    void Update()
    {
        if (cont > 0) {
            cont -= Time.deltaTime;
            tempo2 -= Time.deltaTime;
            float f = cont/tempo;
            scale = f * originalScale;
            transform.localScale =
                new Vector3(scale , transform.localScale.y , transform.localScale.z);
        } else {
            telaFim.SetActive(true);
            //SceneManager.LoadScene("menu");
        }
    }
}
