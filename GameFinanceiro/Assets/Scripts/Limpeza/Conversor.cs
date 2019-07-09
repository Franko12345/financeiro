using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversor : MonoBehaviour
{
    public GameObject moldeArtefato;
    //public GameObject vaso, pratinho, pontaDeLanca; //sujas
    //public GameObject vasoMeioLimpo, pratinhoMeioLimpo, pontaDeLancaMeioLimpa;
    //public GameObject vasoLimpo, pratinhoLimpo, pontaDeLancaLimpa;
    public GameObject[] vasoImgs, pratinhoImgs, pontaLancaImgs;

    //nao destroi item
    public GameObject ItemParaArtefato (Item item) {
        GameObject artefatoNode = Instantiate(moldeArtefato);
        Artefato artefato = artefatoNode.GetComponent<Artefato>();
        artefato.qualidade = item.qualidade;
        artefato.tipo = item.tipo;

        if (artefato.tipo == Item.Tipo.Vaso) {
            PovoaImagens(vasoImgs , artefato);
        } else if (artefato.tipo == Item.Tipo.Pratinho) {
            PovoaImagens(pratinhoImgs , artefato);
        } else {
            PovoaImagens(pontaLancaImgs , artefato);
        }

        return artefatoNode;
    }

    //destroi item (Recomendado)
    public GameObject ItemParaArtefato (GameObject item) {
        GameObject artefato = this.ItemParaArtefato(item.GetComponent<Item>());
        Destroy(item);
        return artefato;
    }

    public void PovoaImagens (GameObject[] imgArtefato, Artefato artefato) {
        List<GameObject> clones = new List<GameObject>();
        for (int i = 0 ; i < imgArtefato.Length ; i++) {
            clones.Add(Instantiate(imgArtefato[i]));
            clones[i].transform.SetParent(artefato.transform);
            clones[i].transform.localPosition = Vector3.zero;
        }
        artefato.suja = clones[0];
        artefato.meioLimpa = clones[1];
        artefato.Limpa = clones[2];
    }
}
