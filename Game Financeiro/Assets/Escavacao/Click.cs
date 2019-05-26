using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{

    bool metronEnabled = false;
    public Text vezesTxt;
    int vezes = 10;

    float angles = 15f;
    public Transform picareta;
    float vel = 15;
    float startAngle;

    public GameObject metronomo;

    public GameObject nada, bom, excelente, vish;

    void Start()
    {
        startAngle = picareta.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            metronEnabled = !metronEnabled;
            metronomo.SetActive(metronEnabled);
            GetComponent<Animator>().SetTrigger("change");
            if (metronEnabled) {
                metronomo.transform.position = new Vector3(metronomo.transform.position.x , -4.2f , 0);
                vezes--;
                vezesTxt.text = ""+vezes;
                vezesTxt.GetComponent<Animator>().SetTrigger("blink");
                StartCoroutine("IdlePicareta");
            } else {
                float y = metronomo.transform.position.y;
                if (y < -1.4f) {
                    nada.SetActive(true);
                } else if (y < 1.8f) {
                    bom.SetActive(true);
                } else if (y < 2.5f) {
                    excelente.SetActive(true);
                } else {
                    vish.SetActive(true);
                }

            }

        }
    }

    IEnumerator IdlePicareta () {
        float nowAngle = 0;

        while (metronEnabled) {
            nowAngle += vel*Time.deltaTime;
            if (nowAngle > angles) {
                nowAngle = angles - 0.1f;
                vel = -vel;
            }

            if (nowAngle < 0) {
                nowAngle = 0.1f;
                vel = -vel;
            }

            picareta.eulerAngles = new Vector3(0 , 0 , startAngle+nowAngle);
            yield return null;
        }
        picareta.eulerAngles = new Vector3(0 , 0 , 0);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        picareta.eulerAngles = new Vector3(0 , 0 , startAngle);
    }


}
