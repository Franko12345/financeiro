using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

enum Estados
{
    parado,
    mire,
    mirando,
    bateu,
    verificaFinal,
    escolhendo
}

public class MaquinaDeEstadosEscav : MonoBehaviour
{

    //public Text vezesTxt;
    int QualidadeArtefato;
    int PicDuraLost, ArtefatoDuraLost;
    
    public static int QntPicaretas, picCounts, DurabiliPic = 100;

    public PicaretaAnim picareta;

    public GameObject metronomo, Reliquias;

    public GameObject nada, bom, excelente, vish;

    RelicIndividualControll RelicCalled;

    public DescobrindoObjeto sDescRelix;

    public MetroQuali sMetroQuali;

    public sDuraPics DisplayPics;

    Estados estadoAtual;

    public void Start()
    {
        estadoAtual = Estados.escolhendo;
        QntPicaretas = 10;
    }

    // Update is called once per frame
    void Update()
    {

        //logica de ações
        switch (estadoAtual)
        {
            case Estados.parado:
                break;
            case Estados.mire:
                //ativa e posiciona metronomo
                metronomo.GetComponent<barrinha>().ResetaPosicao();
                metronomo.SetActive(true);

                //picareta
                picareta.Anime();
                break;
            case Estados.mirando:
                break;
            case Estados.bateu:
                float y = metronomo.transform.localPosition.y;
                if (y < -0.5f)
                {
                    nada.SetActive(true);
                    PicDuraLost = 10;
                }
                else if (y < 2.5f)
                {
                    bom.SetActive(true);
                    QualidadeArtefato = +15;
                    sMetroQuali.NewPontos(15);
                    PicDuraLost = 7;
                }
                else if (y < 3.3f)
                {
                    excelente.SetActive(true);
                    QualidadeArtefato += 30;
                    sMetroQuali.NewPontos(30);
                    PicDuraLost = 5;
                }
                else
                {
                    vish.SetActive(true);
                    QualidadeArtefato -= 30;
                    sMetroQuali.NewPontos(-30);
                    PicDuraLost = 15;
                }
                metronomo.SetActive(false);
                picareta.Desanime();
                picCounts++;
                sDescRelix.Picaretadas();
                break;
            case Estados.verificaFinal:

                //decrementa contador
                DurabiliPic-= PicDuraLost;
                //vezesTxt.GetComponent<Animator>().SetTrigger("blink");
                if (picCounts>=3)
                {
                    metronomo.SetActive(false);
                    picareta.Desanime();
                    estadoAtual = Estados.escolhendo;
                    Reliquias.SetActive(true);
                    RelicCalled.EndEscavavao(QualidadeArtefato, picCounts);

                }
                {/*if (DurabiliPic<=0)// quando a picareta quebra
                {
                    QntPicaretas--;
                    if (QntPicaretas<=0)
                    {
                        SceneManager.LoadScene("menu");
                    }
                    DurabiliPic = 100;
                }
                if (QualidadeArtefato<0)//quando o artefato quebra
                {
                    metronomo.SetActive(false);
                    picareta.Desanime();
                    QualidadeArtefato = 0;
                    ArtefatoDescoberto = 0;
                    estadoAtual = Estados.escolhendo;
                    Reliquias.SetActive(true);
                    RelicCalled.EndEscavavao(QualidadeArtefato, ArtefatoDescoberto);

                }
                else if (ArtefatoDescoberto>100)//quando consegue escavar compeltamente o artefato
                {
                    metronomo.SetActive(false);
                    picareta.Desanime();
                    QualidadeArtefato = 100;
                    ArtefatoDescoberto = 100;
                    estadoAtual = Estados.escolhendo;
                    Reliquias.SetActive(true);
                    RelicCalled.EndEscavavao(QualidadeArtefato, ArtefatoDescoberto);


                }*/
                }
                DisplayPics.ChangeStats(PicDuraLost);

                if (DurabiliPic <= 0)
                {
                    QntPicaretas--;
                    DurabiliPic = 100;
                    DisplayPics.ResetCollor();
                }
                /*vezesTxt.text = "Quatidade Picaretas:" + QntPicaretas
                    + "\n Durabilidade Picareta: " + DurabiliPic + "%";*/
                PicDuraLost = 0;
                break;
            default:
                break;
        }

        //decisao do proximo estado
        Estados proximoEstado = estadoAtual;
        switch (estadoAtual)
        {
            case Estados.parado:
                if (Input.GetMouseButtonDown(0)) {
                    proximoEstado = Estados.mire;
                }
                else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    metronomo.SetActive(false);
                    picareta.Desanime();
                    estadoAtual = Estados.escolhendo;
                    Reliquias.SetActive(true);
                    RelicCalled.EndEscavavao(QualidadeArtefato, picCounts);
                    /*vezesTxt.text = "Quatidade Picaretas:" + QntPicaretas
                    + "\n Durabilidade Picareta: " + DurabiliPic + "%";*/
                    DisplayPics.ChangeStats(PicDuraLost);

                }
                break;
            case Estados.mire:
                proximoEstado = Estados.mirando;
                break;
            case Estados.mirando:
                if (Input.GetMouseButtonDown(0))
                {
                    proximoEstado = Estados.bateu;
                }
                else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    metronomo.SetActive(false);
                    picareta.Desanime();
                    estadoAtual = Estados.escolhendo;
                    Reliquias.SetActive(true);                    
                    RelicCalled.EndEscavavao(QualidadeArtefato, picCounts);
                    /*vezesTxt.text = "Quatidade Picaretas:" + QntPicaretas
                    + "\n Durabilidade Picareta: " + DurabiliPic + "%";*/
                    DisplayPics.ChangeStats(PicDuraLost);

                }
                break;
            case Estados.bateu:
                proximoEstado = Estados.verificaFinal;
                break;
            case Estados.verificaFinal:
                proximoEstado = Estados.parado;
                break;
            default:
                break;
        }

        //atualização do estado
        estadoAtual = proximoEstado;


    }


    public void NewRelic(RelicIndividualControll Relic, int Batido, int QualiR, int indexRelic)
    {
        RelicCalled = Relic;
        QualidadeArtefato = QualiR;
        picCounts = Batido;
        estadoAtual = Estados.parado;
        sMetroQuali.NewRelic(QualiR);
        Reliquias.SetActive(false);
        /*vezesTxt.text = "Quatidade Picaretas:" + QntPicaretas
          +"\n Durabilidade Picareta: " + DurabiliPic + "%";*/
        sDescRelix.ComecoPicareta(picCounts,indexRelic);
        DisplayPics.ChangeStats(PicDuraLost);
    }
}
