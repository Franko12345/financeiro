using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sDuraPics : MonoBehaviour
{
    public Color ThisCollor, TargetCollor;
    public Color CGreen = new Color(70, 255, 70), CRed = new Color(255, 70, 70), Cyellow = new Color(255, 255, 70);
    Image Img;
    public Text PicsTxtCount;
    int proporcao;

    // Start is called before the first frame update
    void Start()
    {
        CGreen = new Color(70,255,70);
        CRed = new Color(255,70,70);
        Cyellow = new Color(255,255,70);
        Img = GetComponent<Image>();
        Img.color = Color.green;
        ThisCollor = Img.color;
        PicsTxtCount.text =MaquinaDeEstadosEscav.picCounts.ToString();
        proporcao = 25;
    }

    public void ChangeStats( float DuraPic)
    {
        /*
         50 - 100
         maq.DurabiliPic-50  - agora

        maq -50 = 50
        50 = agora
        agora = maq-50/100*50
        

         */
        PicsTxtCount.text =MaquinaDeEstadosEscav.picCounts.ToString();
        if (TargetCollor == Color.yellow && MaquinaDeEstadosEscav.DurabiliPic <50)
        {
            proporcao = 50;

        }
        else
        {
            proporcao = 25;

        }
        if (MaquinaDeEstadosEscav.DurabiliPic>50)
        {
            TargetCollor = Cyellow;

        }
        else
        {
            TargetCollor = CRed;
        }
        ThisCollor = Color.Lerp(ThisCollor, TargetCollor, DuraPic / proporcao);
        Img.color = ThisCollor;
        PicsTxtCount.text =MaquinaDeEstadosEscav.QntPicaretas.ToString();

    }
    public void ResetCollor()
    {
        ThisCollor = CGreen;
        Img.color = ThisCollor;

    }
}
