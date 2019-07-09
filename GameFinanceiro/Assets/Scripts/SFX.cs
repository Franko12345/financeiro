using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public static SFX sfx;
    public AudioSource playOneShot,escovinha,arzinho,esponja;
    public int contEsponja, contEscovinha, contArzinho;

    public AudioClip sucesso;

    void Awake () {
        if (!sfx) {
            sfx = this;
            contEsponja = 0; contEscovinha = 0; contArzinho = 0;
        } else {
            Destroy(gameObject);
        }
    }

    public void SomDaFerramenta(FerramentaReceptor fr) {
        switch (fr.tipo) {
            case TipoFerramenta.arzinho:
                contArzinho++;
                arzinho.Play();
                break;
            case TipoFerramenta.escovinha:
                contEscovinha++;
                escovinha.Play();
                break;
            case TipoFerramenta.esponja:
                contEsponja++;
                esponja.Play();
                break;
        }
    }

    public void StopSomDaFerramenta(FerramentaReceptor fr) {
        switch (fr.tipo) {
            case TipoFerramenta.arzinho:
                contArzinho--;
                if (contArzinho == 0) arzinho.Stop();
                if (contArzinho < 0) contArzinho = 0;
                break;
            case TipoFerramenta.escovinha:
                contEscovinha--;
                if (contEscovinha == 0) escovinha.Stop();
                if (contEscovinha < 0) contEscovinha = 0;
                break;
            case TipoFerramenta.esponja:
                contEsponja--;
                if (contEsponja == 0) esponja.Stop();
                if (contEsponja < 0) contEsponja = 0;
                break;
        }
    }

    public void SomSucesso () {
        playOneShot.PlayOneShot(sucesso);
    }
}
