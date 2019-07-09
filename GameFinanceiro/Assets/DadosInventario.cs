using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DadosInventario {
    public float dinheiro = 0;

    public int qtddArzinho = 25;
    public int qtddEscovinha = 25;
    public int qtddEsponja = 25;

    public List<Item.Tipo> itemTipo;
    public List<Item.Qualidade> itemQualidade;

    public List<Item.Tipo> limpoTipo;
    public List<Item.Qualidade> limpoQualidade;

    public DadosInventario (Inventario i) {
        CopiaDoInventario(i);
    }

    public void CopiaProInventario (Inventario i) {
        i.SomaAoDinheiro(this.dinheiro - i.GetDinheiro());//subtrai para apagar o que tinha

        i.qtddArzinho = this.qtddArzinho;
        i.qtddEscovinha = this.qtddEscovinha;
        i.qtddEsponja = this.qtddEsponja;

        CopiaItemParaLista(i, Inventario.tipoLista.itens, itemTipo, itemQualidade);
        CopiaItemParaLista(i, Inventario.tipoLista.pecasLimpas, limpoTipo, limpoQualidade);
    }

    void CopiaItemParaLista (Inventario i, Inventario.tipoLista tipo,
                            List<Item.Tipo> t, List<Item.Qualidade> q) {

        int tamanho = i.TamanhoDaLista(tipo);
        for (int k = 0 ; k < tamanho ; k++) {
            i.RemoverDaLista(0 , tipo);
        }

        for (int k = 0 ; k < t.Count ; k++) {
            Item item = i.CriaItem();
            item.tipo = t[k];
            item.qualidade = q[k];
            i.ColocaNaLista(item.gameObject, tipo);
        }
    }

    public void CopiaDoInventario (Inventario i) {
        this.dinheiro = i.GetDinheiro();

        this.qtddArzinho = i.qtddArzinho;
        this.qtddEscovinha = i.qtddEscovinha;
        this.qtddEsponja = i.qtddEsponja;

        CopiaItemDaLista(i , Inventario.tipoLista.itens, ref itemTipo , ref itemQualidade);
        CopiaItemDaLista(i , Inventario.tipoLista.pecasLimpas, ref limpoTipo , ref limpoQualidade);
    }

    public void CopiaItemDaLista (Inventario i, Inventario.tipoLista tipo,
                                    ref List<Item.Tipo> t , ref List<Item.Qualidade> q) {
        t = new List<Item.Tipo>();
        q = new List<Item.Qualidade>();

        for (int k = 0 ; k < i.TamanhoDaLista(tipo) ; k++) {
            Item item = i.AcessarDaLista(k,tipo).GetComponent<Item>();
            t.Add(item.tipo);
            q.Add(item.qualidade);
        }
    }
}
