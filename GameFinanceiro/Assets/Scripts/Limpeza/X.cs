using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//volta para o menu ao clicar nisso
public class X : MonoBehaviour
{

    public GameObject MenuExit;
    //public peca p;
    public void OpenMenu (){
        MenuExit.SetActive(true);
    }

    public void CloseMenu()
    {
        MenuExit.SetActive(false);
    }

    public void GoCamp()
    {
        
        SceneManager.LoadScene("menu");
    }
}
