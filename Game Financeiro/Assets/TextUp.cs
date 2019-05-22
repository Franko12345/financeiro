using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUp : MonoBehaviour
{

    private void OnEnable () {
        StartCoroutine("Up");
    }

    IEnumerator Up () {
        GetComponent<Text>().enabled = true;
        Vector3 startpos = transform.position;
        float t = 0;
        float vel = 40;
        while (t < 1) {
            t += Time.deltaTime;
            transform.position = startpos + new Vector3(0 , t*vel , 0);
            yield return null;
        }
        GetComponent<Text>().enabled = false;
        transform.position = startpos;
        gameObject.SetActive(false);
    }
}
