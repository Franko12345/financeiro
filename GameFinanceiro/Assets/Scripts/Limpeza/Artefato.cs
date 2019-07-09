using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artefato : Item
{
    public bool pronta = false;
    public MaqEstadosMesa minhaMesa;
    public GameObject brilhinhos;

    public GameObject suja, meioLimpa, Limpa;

    public void AtualizaImg () {
        switch (qualidade) {
            case Qualidade.ruim:
                suja.SetActive(true); meioLimpa.SetActive(false); Limpa.SetActive(false);
                break;
            case Qualidade.boa:
                suja.SetActive(false); meioLimpa.SetActive(true); Limpa.SetActive(false);
                break;
            case Qualidade.excelente:
                suja.SetActive(false); meioLimpa.SetActive(false); Limpa.SetActive(true);
                break;
            default:
                break;
        }
    }

    private void OnMouseDown () {
        minhaMesa.clickNoArtefato = true;
    }
}
