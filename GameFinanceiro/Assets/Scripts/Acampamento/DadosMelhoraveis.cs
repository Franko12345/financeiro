using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DadosMelhoraveis
{
    private int ciclo = 1;
    public int tierPrestigio = 1;
    public int progressoPrestigio = 0;

    public DadosMelhoraveis (Melhoraveis m) {
        this.ciclo = m.ciclo;
        this.tierPrestigio = m.tierPrestigio;
        this.progressoPrestigio = m.progressoPrestigio;
    }

    public void CopiaProMelhoraveis (Melhoraveis m) {
        m.ciclo = this.ciclo;
        m.tierPrestigio = this.tierPrestigio;
        m.progressoPrestigio = this.progressoPrestigio;
    }
}
