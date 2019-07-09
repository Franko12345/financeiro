using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaFim : MonoBehaviour
{
    public Pause pause;
    double timer;
    public double delayPraVerResultadoAntesDeClicar;

    private void OnEnable () {
        timer = 0;
        Destroy(pause);
    }
    void Update()
    {
        //clica para acabar, mas tem um delayzinho pra que nao cliquem sem querer.
        if (timer < delayPraVerResultadoAntesDeClicar) {
            timer += Time.deltaTime;
        } else {
            if (Input.GetMouseButtonDown(0)) {
                FimLimpeza();
            }
        }
    }

    public static void FimLimpeza () {
        Time.timeScale = 1;
        Inventario.i.JuntaListas(Inventario.tipoLista.itens , Inventario.tipoLista.limboLimpeza);
        SceneManager.LoadScene("menu");
    }
}
