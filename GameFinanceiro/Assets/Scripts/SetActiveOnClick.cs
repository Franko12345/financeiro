using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveOnClick : MonoBehaviour
{
    public GameObject obj;

    private void OnMouseDown () {
        obj.SetActive(true);
    }
}
