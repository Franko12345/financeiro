using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetroQuali : MonoBehaviour
{
    public Transform FimGreen, Middle, FimRed;
    float PontosNow,newY;

    public void NewPontos(float pontuacao)
    {
        PontosNow += pontuacao;
        newY = ((3 * PontosNow) / 90) -1.5f;

        if (newY>FimGreen.localPosition.y) {
            transform.localPosition = new Vector3(transform.localPosition.x, FimGreen.localPosition.y, transform.localPosition.z);          
        }
        else if (newY<FimRed.localPosition.y)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, FimRed.localPosition.y, transform.localPosition.z);

        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
        }
    }
    public void NewRelic(float ponto)
    {
        PontosNow = ponto;
        newY = ((3 * ponto) / 90) - 1.5f;

        if (newY > FimGreen.localPosition.y)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, FimGreen.localPosition.y, transform.localPosition.z);
        }
        else if (newY < FimRed.localPosition.y)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, FimRed.localPosition.y, transform.localPosition.z);

        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
        }

    }
    public void ResetBarra()
    {
        PontosNow = 45;
        newY = 0;
    }

}
