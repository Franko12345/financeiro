using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelaInitLimpeza : CutSceneElement
{

    protected override void Update () {
        if (Input.GetMouseButton(0)) {
            Ativacoes();
            Destroy(gameObject);
        }
        base.Update();
    }
}
