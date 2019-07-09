using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoltarAcampamento : MonoBehaviour
{
    private void OnMouseDown () {
        VoltaAcampamento();
    }

    public void VoltaAcampamento () {
        TelaFim.FimLimpeza();
    }

}
