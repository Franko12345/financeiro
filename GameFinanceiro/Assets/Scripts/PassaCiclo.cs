using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassaCiclo : MonoBehaviour
{
    public delegate void OnPassaCiclo ();
    public static event OnPassaCiclo onPassaCiclo;


    public void passaCiclo () {
        if (!Melhoraveis.m.SomaAoCiclo(1)) {
            print("chegou ao maximo de ciclos");
            return;
        }

        Inventario.i.SomaAoDinheiro(Melhoraveis.m.GranaDoCiclo());

        int limpas = Inventario.i.TamanhoDaLista(Inventario.tipoLista.pecasLimpas);
        Melhoraveis.m.ProgressoPrestigio(limpas);
        Inventario.i.LimpaLista(Inventario.tipoLista.pecasLimpas);

        onPassaCiclo(); //gerenciar interfaces e cenario com o delegate.
    }

    public void AtualizaUI () {
        onPassaCiclo();
    }
}
