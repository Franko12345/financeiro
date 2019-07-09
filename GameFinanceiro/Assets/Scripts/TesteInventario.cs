using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TesteInventario : MonoBehaviour
{
    //adicionando e removendo um item
    public Item i;

    //adicionando varios itens que jah funcionam na limpeza
    public Item[] itens;

    void Start()
    {
        //TesteLoko();

        //for (int i = 0 ; i < itens.Length ; i++) { Inventario.i.ColocaItemNoInventario(itens[i].gameObject); }

        if (SceneManager.GetActiveScene().name == "TesteInventario") {
            SceneManager.LoadScene("limpeza");
        }
    }


    void TesteLoko () {
        DontDestroyOnLoad(gameObject);
        Inventario.i.ColocaItemNoInventario(i.gameObject);
        print(Inventario.i.AcessarDaLista(0, Inventario.tipoLista.itens) + " adicionado ao inventario com sucesso");
        try {
            Inventario.i.ColocaItemNoInventario(gameObject);
        } catch (Exception e) {
            print("Disparou erro ao tentar colocar no inventario algo que nao eh item: passou nesse teste"+e);
        }
        Removendo();
    }

    private void Removendo()
    {
        GameObject a=Inventario.i.RemoverDaLista(0,Inventario.tipoLista.itens);
        print(a + " removido da lista com sucesso");
        Destroy(this);
    }
}
