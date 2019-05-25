using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peca : MonoBehaviour
{
    bool naMesa = false;
    bool pronta = false;
    List<Transform> mesas;
    int mSize = 0;
    public FerramentaReceptor[] demandas;
    int iDemanda = 0;
    Transform cesto;
    
    void Start()
    {
        mesas = new List<Transform>();
        GameObject[] Gmesas = GameObject.FindGameObjectsWithTag("mesa");
        for (int i = 0 ; i < Gmesas.Length ; i++) {
            mesas.Add(Gmesas[i].GetComponent<Transform>());
            mSize++;
        }
        GameObject c = GameObject.FindGameObjectWithTag("cesto");
        cesto = c.GetComponent<Transform>();
    }

    public void OnMouseDown () {
        if (naMesa) {
            if (pronta) {

            }
        } else {
            for (int i = 0 ; i < mSize ; i++) {
                mesa m = mesas[i].GetComponent<mesa>();
                if (m.vazia) {
                    naMesa = true;
                    m.vazia = false;
                    transform.position = m.transform.position;
                    FerramentaReceptor fr = 
                        Instantiate(demandas[0] , transform.position , Quaternion.identity);
                    fr.p = this;
                    return;
                }
            }
            StartCoroutine("wrong");
        }
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

    public void ProximaDemanda () {
        iDemanda++;
        if (iDemanda >= demandas.Length) { //pronta
            pronta = true;
            naMesa = false;
            transform.position = cesto.transform.position;
        }
    }
}
