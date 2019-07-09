using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnIventario : MonoBehaviour
{
    public GameObject Iventario;

    public void OpenCloseIventory()
    {
        if (Iventario.activeInHierarchy)
        {
            Iventario.SetActive(false);
        }
        else
        {
            Iventario.SetActive(true);
        }
    }
}
