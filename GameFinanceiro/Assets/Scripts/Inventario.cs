using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Inventario : MonoBehaviour
{
    public enum tipoLista {
        itens,
        pecasLimpas,
        limboLimpeza,
    }

    [SerializeField]
    private List<GameObject> itens; //usar os metodos públicos abaixo para acessar essa lista.
    //motivo: poder configurar mais coisas quando um acesso eh feito do que soh fornecer/remover item
    [SerializeField]
    private List<GameObject> pecasLimpas;
    [SerializeField]
    private List<GameObject> limboLimpeza;

    //ferramentas:
    public int qtddArzinho = 25;
    public int qtddEscovinha = 25;
    public int qtddEsponja = 25;

    public GameObject itemParaClonar;

    Vector3 LugarDoInventario;

    private float dinheiro = 0;

    //padrao Singleton garante um só inventário no jogo:
    public static Inventario i;
    void Awake () {
        if (!i) {
            i = this;
            itens = new List<GameObject>();
            pecasLimpas = new List<GameObject>();
            limboLimpeza = new List<GameObject>();
            DontDestroyOnLoad(gameObject);
            LugarDoInventario = new Vector3(0 , 20 , 0);
        } else {
            Destroy(gameObject);
        }

    }

    public float GetDinheiro () {
        return this.dinheiro;
    }

    public bool SomaAoDinheiro (float quantia) {
        if (dinheiro + quantia < 0) {
            print("Dinheiro insuficiente. Quantia solicitada = " + quantia);
            return false;
        }
        dinheiro += quantia;
        return true;
    }

    //metodo usado no sistema de Save
    public Item CriaItem () {
        return Instantiate(itemParaClonar).GetComponent<Item>();
    }

    public void ColocaNaLista (GameObject obj, tipoLista tipo) {
        List<GameObject> lista = ListaDoTipo(tipo);
        lista.Add(obj);
        obj.transform.position = LugarDoInventario;

        //DontDestroyOnLoad(obj); ao inves de destruir, seta pai pra o inventario, que nao
        obj.transform.SetParent(transform); //sera destruido ao trocar de cena
    }
    public GameObject AcessarDaLista(int index , tipoLista tipo) {
        List<GameObject> lista = ListaDoTipo(tipo);
        return lista[index];
    }
    public GameObject RemoverDaLista (int index, tipoLista tipo) {
        List<GameObject> lista = ListaDoTipo(tipo);
        GameObject obj = lista[index];
        obj.transform.SetParent(Camera.main.transform); //marca objetos para serem destruidos, uma
        //vez que a main camera estah sendo destruida em todas as cenas....
        lista.Remove(obj);
        return obj;
    }

    public void RemoverObjDaLista (GameObject obj , tipoLista tipo) {
        List<GameObject> lista = ListaDoTipo(tipo);
        obj.transform.SetParent(Camera.main.transform); //marca objetos para serem destruidos, uma
        //vez que a main camera estah sendo destruida em todas as cenas....
        lista.Remove(obj);
    }

    public void JuntaListas (tipoLista receptora, tipoLista doadora) {
        List<GameObject> doa = ListaDoTipo(doadora);
        foreach (GameObject obj in doa) {
            ColocaNaLista(obj , receptora);
        }
        doa.Clear();
    }

    public int TamanhoDaLista (tipoLista tipo) {
        List<GameObject> lista = ListaDoTipo(tipo);
        return lista.Count;
    }

    public void LimpaLista(tipoLista tipo) {
        List<GameObject> lista = ListaDoTipo(tipo);
        lista.Clear();
    }

    public void ColocaItemNoInventario(GameObject item)
    {

        if ( item.GetComponent<Item>() == null)
        {
            print("ADICIONE COMPONENTE ITEM AO OBJETO QUE TÁS PONDO NA LISTA!!!");
            throw new TentouAdicionarAoInventarioAlgoQueNaoEhItem();
        }
        ColocaNaLista(item , tipoLista.itens);
    }

    List<GameObject> ListaDoTipo (tipoLista t) {
        List<GameObject> l = null;
        switch (t) {
            case tipoLista.itens:
                l = itens;
                break;
            case tipoLista.limboLimpeza:
                l = limboLimpeza;
                break;
            case tipoLista.pecasLimpas:
                l = pecasLimpas;
                break;
            default:
                print("Tipo de lista nao encontrado no metodo ListaDoTipo, da classe Inventario");
                break;
        }
        return l;
    }
}

class TentouAdicionarAoInventarioAlgoQueNaoEhItem : Exception
{

}
