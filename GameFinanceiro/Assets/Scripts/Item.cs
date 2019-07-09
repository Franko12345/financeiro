using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Qualidade { ruim, boa, excelente }
    public enum Tipo { pontaDeLanca, Pratinho, Vaso }

    public Qualidade qualidade;
    public Tipo tipo;

    public void Melhorar() {
        if (qualidade == Qualidade.ruim) qualidade = Qualidade.boa;
        else if (qualidade == Qualidade.boa) qualidade = Qualidade.excelente;
    }

}
