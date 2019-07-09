using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorInventario : MonoBehaviour
{
    public Text contador;
    public GameObject spriteCheio,spriteMeioCheio,spriteVazio;
    public int inicial;
    public bool guardaSujas;

    private void Start () {
        inicial = 10;
        Invoke("Init" , 0.2f);
    }

    void Init () {
        inicial = Inventario.i.TamanhoDaLista(Inventario.tipoLista.itens);
    }

    public void AtualizaContador () {
        //print(Inventario.i.TamanhoLista() +" nome: "+ Inventario.i.name);
        int i = Inventario.i.TamanhoDaLista(Inventario.tipoLista.itens);
        contador.text = i.ToString();
        AtualizaSprites(i);
    }

    public void AtualizaComALista (Inventario.tipoLista tipoLista) {
        //print(Inventario.i.TamanhoLista() + " nome: " + Inventario.i.name);
        int i = Inventario.i.TamanhoDaLista(tipoLista);
        contador.text = i.ToString();
        AtualizaSprites(i);
    }

    void AtualizaSprites (int i) {
        if (i == 0) {
            if (spriteCheio != null) spriteCheio.SetActive(false);
            if (spriteMeioCheio != null) spriteMeioCheio.SetActive(false);
            if (spriteVazio != null) spriteVazio.SetActive(true);
        } else if (i <= inicial / 2) {
            if (spriteCheio != null) spriteCheio.SetActive(false);
            if (spriteMeioCheio != null) spriteMeioCheio.SetActive(true);
            if (spriteVazio != null) spriteVazio.SetActive(false);
        } else {
            if (spriteCheio != null) spriteCheio.SetActive(true);
            if (spriteMeioCheio != null) spriteMeioCheio.SetActive(false);
            if (spriteVazio != null) spriteVazio.SetActive(false);
        }
    }
}
