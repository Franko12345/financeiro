using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PecasLimpasUI : CicloUI {
    public override void AtualizaContador () {
        string tamanho = Inventario.i.TamanhoDaLista(Inventario.tipoLista.pecasLimpas).ToString();
        text.text = "pecasLimpas: " + tamanho;
    }
}
