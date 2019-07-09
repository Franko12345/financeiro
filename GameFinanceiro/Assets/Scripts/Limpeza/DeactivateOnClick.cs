using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnClick : MonoBehaviour
{
    public GameObject obj;
    private void OnMouseDown () {
        obj.SetActive(false);
    }
}
