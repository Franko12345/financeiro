using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peca : Item
{
    bool naMesa = false;
    public bool pronta = false;
    public mesa minhaMesa;
    public FerramentaReceptor[] demandas;
    int iDemanda = 0;
    FerramentaReceptor fr;
    public float tratTime;

    void PovoaDemandas()
    {
        print(Inventario.i.AcessarDaLista(0, Inventario.tipoLista.itens));
    }

    public void OnMouseDown () {
        if (naMesa && pronta) VaiParaCesto();
    }

    void VaiParaCesto () {
        GameObject cesto = GameObject.FindGameObjectWithTag("cesto");
        naMesa = false;
        transform.position = cesto.transform.position;
        minhaMesa.vazia = true;
        if (Inventario.i.TamanhoDaLista(Inventario.tipoLista.itens) > 0) {
            Inventario.i.RemoverDaLista(0, Inventario.tipoLista.itens).GetComponent<peca>().EncontreMesaVazieVaParaElaESetFr();
        }
        Destroy(this); //soh o script
    }

    public void EncontreMesaVazieVaParaElaESetFr () {
        int i = EncontreMesaVazia();
        if (i != -1) {
            VaParaMesa(i);
            fr = Instantiate(demandas[0] , (transform.position + new Vector3(-1, 2, 0)) , Quaternion.identity);
            fr = Instantiate(demandas[0] , transform.position , Quaternion.identity);
            fr.p = this;
        }
    }

    int EncontreMesaVazia() {
        print("nome do game object "+gameObject.name);
        for (int i = 0 ; i < Mesas.mesas.Count ; i++) {
            mesa m = Mesas.mesas[i].GetComponent<mesa>();
            if (m.vazia) {
                return i;
            }
        }
        //todas as mesas estao ocupadas.
        StartCoroutine("wrong");
        return -1;
    }

    void VaParaMesa(int i)
    {
        mesa m = Mesas.mesas[i].GetComponent<mesa>();
        minhaMesa = m;
        naMesa = true;
        m.vazia = false;
        transform.position = m.transform.position;
        GameObject.FindGameObjectWithTag("contadorInventario").GetComponent<ContadorInventario>().AtualizaContador();
    }

    //faz piscar vermelho
    IEnumerator wrong () {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        Color originalColor = sp.color;
        int vezes = 6;
        while (vezes > 0) {
            vezes--;
            if (sp.color == originalColor) {
                sp.color = Color.red;
            } else {
                sp.color = originalColor;
            }
            yield return new WaitForSeconds(0.12f);
        }
        sp.color = originalColor;
    }

    //peça pede proxima acao ou fica pronta e vai para o vaso.
    public void ProximaDemanda () {
        iDemanda++;
        if (iDemanda >= demandas.Length) {
            pronta = true;
            Destroy(fr.gameObject);
            //TODO pronta: tem que esperar input. Adicionar brilhinhos e balao pensando.
        }
        else {
            Destroy(fr.gameObject);
            fr = Instantiate(demandas[iDemanda] , transform.position , Quaternion.identity);
            fr.p = this;
        }
    }

}
