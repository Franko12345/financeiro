using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerramentaReceptor : MonoBehaviour
{
    tipo t;
    public peca p;
    float tempo;
    SpriteRenderer sr;

    private void Update () {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D (Collider2D col) {
        Ferramenta f = col.GetComponent<Ferramenta>();
        if (f == null) return;
        if (f.fr != this) {
            if (f.fr != null) f.fr.Perdeu();
            f.fr = this;
        }
        sr.enabled = false;
    }

    public void Perdeu () {
        sr.enabled = true;
    }

    public void Tratamento(tipo tipoFerramenta) {
        if (t == tipoFerramenta) {
            //acertou
            p.ProximaDemanda();
        }
    }
}
