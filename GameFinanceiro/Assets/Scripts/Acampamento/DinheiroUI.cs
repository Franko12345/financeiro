using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinheiroUI : CicloUI
{
    public override void AtualizaContador () {
        text.text = texto + Inventario.i.GetDinheiro();
    }
}
