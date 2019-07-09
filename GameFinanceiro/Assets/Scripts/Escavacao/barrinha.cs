using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrinha : MonoBehaviour
{
    public Transform inicioBarra, fimBarra;
    float t;
    Vector3 direcao;

    public float vel = 2   ;
    void Start()
    {
        t = 0;
        direcao = fimBarra.position - inicioBarra.position;
        transform.up = direcao;
    }

    public void ResetaPosicao()
    {
        t = 0;
        transform.position = inicioBarra.position;
    }

    void Update()
    {

        if (vel * t > 1) {
            t = 0;
        }

        transform.position = inicioBarra.position + vel * t * direcao;

        t += Time.deltaTime;

    }
}
