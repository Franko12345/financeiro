using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelicIndividualControll : MonoBehaviour
{
    public Text countRelicstxt;
    //public Image CaixaItens;
    static int RelicsCount;
    public GameObject EscavacaoPic;
    public MaquinaDeEstadosEscav machine;
    public int QualiRlic=45, pics = 0, indexRelic;
    public bool Terminado, descoberto;
    public Sprite sCompleto, sImcompleto,CaixaCItens;

    private void Start()
    {
        indexRelic = Random.Range(0,2);
    }

    public void OnClicked()
    {
        if (!Terminado) {
            EscavacaoPic.SetActive(true);
            machine.NewRelic(this, pics, QualiRlic,indexRelic);
        }
    }

    public void EndEscavavao(int qRelic, int PicCount)
    {
        if (PicCount >= 3)
        {
            if (qRelic >= 60)
            {                
                descoberto = true;
                Terminado = true;
            }
            else if(qRelic >= 30)
            {
                Terminado = true;
                descoberto = false;
            }
            else
            {
                descoberto = false;
                Terminado = true;
            }
            GetComponent<Image>().sprite = sCompleto;
            //CaixaItens.sprite = CaixaCItens;
            RelicsCount++;
            countRelicstxt.text = RelicsCount.ToString();

        }
        else
        {
            //GetComponent<Image>().sprite = sCompleto;
            QualiRlic = qRelic;
            pics = PicCount;

        }
        EscavacaoPic.SetActive(false);
    }
}
