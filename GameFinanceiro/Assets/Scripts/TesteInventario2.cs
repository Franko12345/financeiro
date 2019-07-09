using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class TesteInventario2 : MonoBehaviour
{
    public static TesteInventario2 i;
    public GameObject item;
    //coloca o 5 copias do artefato no inventario.
    bool PasseiPeloMenu;

    private void Awake () {
        if (!i) {
            i = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //o metodo eh bom, mas to colo
        //Ferramenta.QtddFerramenta(TipoFerramenta.arzinho , 25);
        //Ferramenta.QtddFerramenta(TipoFerramenta.escovinha , 25);
        //Ferramenta.QtddFerramenta(TipoFerramenta.esponja , 25);
        DontDestroyOnLoad(item);
        if (SceneManager.GetActiveScene().name == "menu") PasseiPeloMenu = true;
        if (!PasseiPeloMenu) GeraSujas();
    }

    //esses Gera sao botoes de teste!!
    public void GeraSujas () {
        GeraParaALista(Inventario.tipoLista.itens);
    }

    public void GeraParaALista (Inventario.tipoLista tipo) {
        for (int i = 0 ; i < 10 ; i++) {
            GameObject obj = Instantiate(item);

            Item objItem = obj.GetComponent<Item>();

            objItem.tipo = RandomEnumValue<Item.Tipo>();
            objItem.qualidade = RandomEnumValue<Item.Qualidade>();

            Inventario.i.ColocaNaLista(obj , tipo);
        }
    }

    //peguei do stack overflow
    T RandomEnumValue<T> () {
        var v = Enum.GetValues (typeof (T));
        return (T)v.GetValue(UnityEngine.Random.Range(0,3));
    }
}
