using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CicloUI : MonoBehaviour
{
    protected Text text;
    protected string texto;

    protected void Start()
    {
        text = GetComponent<Text>();
        texto = text.text;
        AtualizaContador();
        PassaCiclo.onPassaCiclo += AtualizaContador;
    }

    protected void OnDisable () {
        PassaCiclo.onPassaCiclo -= AtualizaContador;
    }

    public virtual void AtualizaContador () {
        text.text = texto + Melhoraveis.m.GetCiclo();
    }
}
