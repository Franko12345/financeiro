using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicaretaAnim : MonoBehaviour
{
    float angles = 15f;
    Transform picareta;
    float vel = 15;
    float startAngle;
    bool animando = false;

    void Start()
    {
        picareta = transform;
        startAngle = picareta.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Anime()
    {
        StartCoroutine("IdlePicareta");
    }

    public void Desanime()
    {
        animando = false;
    }

    //faz a picareta ficar balançando
    IEnumerator IdlePicareta()
    {
        float nowAngle = 0;
        animando = true;

        while (animando)
        {
            nowAngle += vel * Time.deltaTime;
            if (nowAngle > angles)
            {
                nowAngle = angles - 0.1f;
                vel = -vel;
            }

            if (nowAngle < 0)
            {
                nowAngle = 0.1f;
                vel = -vel;
            }

            picareta.eulerAngles = new Vector3(0, 0, startAngle + nowAngle);
            yield return null;
        }

        //no final dah uma batida
        picareta.eulerAngles = new Vector3(0, 0, 0);
        Camera.main.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        picareta.eulerAngles = new Vector3(0, 0, startAngle);
    }
}
