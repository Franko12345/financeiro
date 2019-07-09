using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn : MonoBehaviour
{
    public void GoToScene (int scene) {
        SceneManager.LoadScene(scene);
    }

    public void GeraSujas () {
        TesteInventario2.i.GeraSujas();
    }

    public void GeraLimpas () {
        TesteInventario2.i.GeraParaALista(Inventario.tipoLista.pecasLimpas);
    }
}
