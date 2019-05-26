using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum tipo {
    arzinho,
    esponja,
    escovinha
}

public class Ferramenta : MonoBehaviour
{
    public bool drag = false;
    public tipo t;
    public FerramentaReceptor fr;
    public float actionTime;
    public Text qtdd;

    private void OnMouseDown () {
        drag = true;
        StartCoroutine("Drag");
    }

    private void OnMouseUp () {
        drag = false;
        GetComponent<Collider2D>().enabled = false;
        if (fr != null) { //peça foi arrastada para um receptor 
            fr.Tratamento(t);
            int q = System.Convert.ToInt32(qtdd.text);
            qtdd.text = System.Convert.ToString(q - 1);
        }
        Destroy(gameObject);
    }

    IEnumerator Drag () {
        GameObject f = 
        Instantiate(gameObject , transform.position , Quaternion.identity);
        while (drag) {
            Vector2 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mPos;
            yield return null;
        }
        GetComponent<Collider2D>().enabled = true;
    }

}
