using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FerramentaReceptor : MonoBehaviour
{
    public tipo t;
    public peca p;
    float tempo;
    SpriteRenderer sr;
    Ferramenta fe;
    bool interactive = true;

    private void Start () {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D (Collider2D col) {
        if (!interactive) return;
        Ferramenta f = col.GetComponent<Ferramenta>();
        if (f == null) return;
        if (f.fr != this) {
            if (f.fr != null) f.fr.Perdeu();
            f.fr = this;
            fe = f;
        }
        sr.enabled = false;
    }

    IEnumerator sera (Ferramenta f) {
        yield return new WaitForSeconds(.1f);
        f.fr = null;
        fe = null;
    }

    private void OnTriggerExit2D (Collider2D col) {
        if (!interactive) return;
        Ferramenta f = col.GetComponent<Ferramenta>();
        if (f == null) return;
        if (f.fr == this) {
            if (f.drag) {
                StartCoroutine("sera" , f);
            }
        }
        
        sr.enabled = true;
    }

    public void Perdeu () {
        GetComponent<SpriteRenderer>().enabled = true;
    }

    public void Tratamento(tipo tipoFerramenta) {
        if (!interactive) return;
        if (t == tipoFerramenta) {
            StartCoroutine("trat");
        }
    }

    //a corrotina expressa o que deve acontecer quando o jogador arrasta a
    //ferramenta certa ateh a peca.
    IEnumerator trat () {
        interactive = false;
        sr.enabled = false;
        GameObject slider = Resources.Load("slider") as GameObject;
        slider = Instantiate(slider , transform.position , Quaternion.identity);
        Image s = slider.GetComponentInChildren<Image>();
        float time = fe.actionTime + p.tratTime;
        float cont = 0;
        while (cont < time) {
            cont += Time.deltaTime;
            s.fillAmount = cont / time;
            yield return null;
        }
        Destroy(slider);
        p.ProximaDemanda();
    }
}
