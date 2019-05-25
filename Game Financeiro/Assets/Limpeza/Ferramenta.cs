using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum tipo {
    arzinho,
    esponja,
    escovinha
}

public class Ferramenta : MonoBehaviour
{
    bool drag = false;
    public tipo t;
    public FerramentaReceptor fr;

    private void OnMouseDown () {
        drag = true;
        StartCoroutine("Drag");
    }

    private void OnMouseUp () {
        drag = false;
        GetComponent<Collider2D>().enabled = false;
        fr.Tratamento(t);
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
