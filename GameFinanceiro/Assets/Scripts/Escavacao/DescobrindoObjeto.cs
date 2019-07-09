using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescobrindoObjeto : MonoBehaviour
{
    public SpriteRenderer srobjeto, srterra;
    public Sprite[] reliquias, terras; 

    void Start()
    {
        srobjeto = transform.GetChild(0).GetComponent<SpriteRenderer>();
        srterra = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    public void ComecoPicareta(int IndexRel,int quantPic)
    {
        srobjeto.sprite = reliquias[IndexRel];
        srterra.sprite = terras[quantPic];
    }

    public void Picaretadas()
    {
        srterra.sprite = terras[MaquinaDeEstadosEscav.picCounts];        
    }

}
