using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneElement : MonoBehaviour
{

    public GameObject[] ativarOnDestroy;
    public GameObject[] destruirOnDestroy;
    public float tempoAtivo;
    protected float time = 0;
    
    protected virtual void Update()
    {
        if (time < tempoAtivo) {
            time += Time.deltaTime;
        } else {
            Ativacoes();
            foreach (GameObject obj in destruirOnDestroy) {
                Destroy(obj);
            }
            Destroy(gameObject);
        }
    }

    protected void Ativacoes () {
        foreach (GameObject obj in ativarOnDestroy) {
            obj.SetActive(true);
        }
    }
}
