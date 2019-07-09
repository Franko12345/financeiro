using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mesas : MonoBehaviour
{
    public static List<Transform> mesas; //lista de mesas
    void Start()
    {
        PovoaListaDeMesas();
    }

    //acha uma referencia para cada mesa do jogo, e guarda uma lista de mesas na variavel mesas
    void PovoaListaDeMesas () {
        mesas = new List<Transform>();
        GameObject[] Gmesas = GameObject.FindGameObjectsWithTag("mesa");
        for (int i = 0 ; i < Gmesas.Length ; i++) {
            mesas.Add(Gmesas[i].GetComponent<Transform>());
            if (Inventario.i.TamanhoDaLista(Inventario.tipoLista.itens) > 0) {
                GameObject item = Inventario.i.RemoverDaLista(0,Inventario.tipoLista.itens);
                peca p = item.GetComponent<peca>();
                p.EncontreMesaVazieVaParaElaESetFr();
                //p.minhaMesa = mesas[i].GetComponent<mesa>();
            }
        }
    }
}
