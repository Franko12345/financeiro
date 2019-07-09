using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FerramentaReceptor : MonoBehaviour
{
    public TipoFerramenta tipo;
    public peca p;
    float tempo;
    private SpriteRenderer sr;
    public Ferramenta fe;
    public bool interactive = true;
    public MaqEstadosMesa minhaMesa;

    private void Start () {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D (Collider2D col) {
        if (!interactive) return;
        Ferramenta f = col.GetComponent<Ferramenta>();
        if (f == null) return;
        if (f.fr != this) { //se o receptor dessa ferramenta nao sou eu
            //print("O receptor dela nao sou eu");
            if (f.fr != null) f.fr.Perdeu(); // se o receptor era outra peca, a peca perde o direito.
            f.fr = this; // de qualquer forma, eu quero virar o receptor dela!!
            fe = f; // e ela virarah minha ferramenta S2
        }
        EnableSpriteRenderer(false);
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
        if (f.fr == this) { //se o receptor dessa ferramenta chegante sou eu
            if (f.drag) { // se ela estah sendo arrastada
                //StartCoroutine("sera" , f); // esperar um pouco e desfazer conexao
                f.fr = null; //deixei de usar corrotina pq tava bugando qd troca mt rapido
                fe = null;
            }
        }

        EnableSpriteRenderer(true);
    }

    public void Perdeu () {
        //GetComponent<SpriteRenderer>().enabled = true;
        EnableSpriteRenderer(true);
    }

    public void Tratamento(TipoFerramenta tipoFerramenta) {
        if (!interactive) return;
        if (tipo == tipoFerramenta) {
            StartCoroutine("trat");
        }
    }

    //a corrotina expressa o que deve acontecer quando o jogador arrasta a
    //ferramenta certa ateh a peca.
    IEnumerator trat () {
        interactive = false;
        EnableSpriteRenderer(false);
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

    public void EnableSpriteRenderer(bool b) {
        //sr.enabled = b; estah comentado para que fique sempre falso.
        //para ligar efeito de ativar e desativar sprite renderer, basta descomentar.
    }
}
