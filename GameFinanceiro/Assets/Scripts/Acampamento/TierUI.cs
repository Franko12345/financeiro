using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TierUI : CicloUI {
    public override void AtualizaContador () {
        text.text = texto + Melhoraveis.m.tierPrestigio;
    }
}
