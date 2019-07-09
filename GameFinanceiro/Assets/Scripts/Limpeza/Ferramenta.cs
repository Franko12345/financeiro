using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TipoFerramenta {
    arzinho,
    esponja,
    escovinha
}

public class Ferramenta : MonoBehaviour
{
    public bool drag = false;
    public TipoFerramenta tipo;
    public FerramentaReceptor fr;
    public float actionTime;
    public Text qtdd;
    public Sprite spriteArrastando;
    SpriteRenderer spriteRenderer;
    public GameObject canvas;

    private void Start () {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (canvas != null)
            canvas.transform.SetParent(transform.parent); // pra poder andar juntos no editor,
        //e depois nao clonar eles juntos
        if (qtdd != null)
            qtdd.text = System.Convert.ToString(QtddFerramenta(tipo, 0));
    }

    private void OnMouseDown () {
        if (QtddFerramenta(tipo , 0) > 0) {
            drag = true;
            StartCoroutine("Drag");
        } else {
            if(GetComponentInChildren<SpriteRenderer>() != null) {
                GetComponentInChildren<SpriteRenderer>().color = Color.red;
                drag = false; //redundante
            }
        }
    }

    private void OnMouseUp () {
        if (drag == true) {
            drag = false;
            GetComponent<Collider2D>().enabled = false;
            //print(fr.name);
            if (fr != null) { //peça foi arrastada para um receptor 
                              //print(fr.name);
                              //fr.Tratamento(t);
                if (tipo == fr.tipo) fr.minhaMesa.ferramentaAcabouDeChegar = true;
                //decrementa contador
                qtdd.text = System.Convert.ToString(QtddFerramenta(tipo , -1));
            }
            Destroy(gameObject);
        }
    }

    IEnumerator Drag () {
        GameObject f = 
        Instantiate(gameObject , transform.position , Quaternion.identity);
        spriteRenderer.sprite = spriteArrastando;
        spriteRenderer.sortingLayerName = "ferramenta";
        while (drag) {
            Vector2 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mPos;
            yield return null;
        }
        GetComponent<Collider2D>().enabled = true;
    }

    public static int QtddFerramenta (TipoFerramenta tipo, int somar) {
        int q = 0;
        switch (tipo) {
            case TipoFerramenta.arzinho:
                Inventario.i.qtddArzinho += somar;
                q = Inventario.i.qtddArzinho;
                break;
            case TipoFerramenta.escovinha:
                Inventario.i.qtddEscovinha += somar;
                q = Inventario.i.qtddEscovinha;
                break;
            case TipoFerramenta.esponja:
                Inventario.i.qtddEsponja += somar;
                q = Inventario.i.qtddEsponja;
                break;
        }
        return q;
    }

    public void ComprarPacote(int num) {
        QtddFerramenta(TipoFerramenta.arzinho, num);
        QtddFerramenta(TipoFerramenta.escovinha , num);
        QtddFerramenta(TipoFerramenta.esponja , num);
    }
}
