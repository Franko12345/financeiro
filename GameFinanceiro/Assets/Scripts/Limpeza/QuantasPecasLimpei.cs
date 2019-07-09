using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuantasPecasLimpei : MonoBehaviour
{
    private void Start () {
        Text text = GetComponent<Text>();
        text.text = Cesto.cesto.contadorPecasLimpas.ToString();
    }
}
