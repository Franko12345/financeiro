using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cesto : MonoBehaviour
{
    public static Cesto cesto;

    private void Awake () {
        cesto = this;
    }

    public int contadorPecasLimpas = 0;

    public void incrementaContadorPecasLimpas () {
        contadorPecasLimpas++;
    }
}
