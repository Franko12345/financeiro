using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaqEstadosMesa : MonoBehaviour
{
    enum estados { pega, instanciaReceptor, esperaFerramenta, ferramentaChegou, delay, pronta, despacha, acabaram }
    estados estadoAtual, proximoEstado;

    GameObject pecaAtual;

    public FerramentaReceptor[] demandas;
    FerramentaReceptor ferramentaReceptor;

    public GameObject[] pensamentoImgs;
    GameObject pensamentoImg;
    public Transform pensamentoPoint;

    public GameObject slider;
    public Transform pontoOrigemSlider;

    public Transform pontoSpawnArtefato;

    public Conversor conversor;

    //gatilhos de transições
    public bool ferramentaAcabouDeChegar = false;
    bool pecaAcabouDeFicarPronta = false;
    public bool clickNoArtefato = false;
    bool pecaAindaTemQueSerLimpa = false;

    public Transform cesto;

    public ContadorInventario contadorPecasEscav, contadorPecasLimpas;

    void Start()
    {
        estadoAtual = estados.pega;
        contadorPecasEscav.AtualizaContador();
        contadorPecasLimpas.AtualizaComALista(Inventario.tipoLista.pecasLimpas);
    }

    // Update is called once per frame
    void Update()
    {

        //logica de acoes
        bool peguei = false;
        switch (estadoAtual) {
            case estados.pega:
                if (Inventario.i.TamanhoDaLista(Inventario.tipoLista.itens) > 0) {
                    GameObject item = Inventario.i.RemoverDaLista(0,Inventario.tipoLista.itens);
                    pecaAtual = conversor.ItemParaArtefato(item);
                    pecaAtual.GetComponent<Artefato>().minhaMesa = this;
                    Inventario.i.ColocaNaLista(pecaAtual, Inventario.tipoLista.limboLimpeza);
                    pecaAtual.transform.position = pontoSpawnArtefato.position;
                    peguei = true;
                    contadorPecasEscav.AtualizaContador();
                }
                    break;
            case estados.instanciaReceptor:
                int random = Random.Range(0,3);
                ferramentaReceptor = Instantiate(demandas[random] , transform.position , Quaternion.identity);
                ferramentaReceptor.minhaMesa = this;
                pensamentoImg = Instantiate(pensamentoImgs[random] , pensamentoPoint.position , Quaternion.identity);
                pecaAtual.GetComponent<Artefato>().AtualizaImg();
                break;
            case estados.esperaFerramenta:
                break;
            case estados.ferramentaChegou:
                ferramentaAcabouDeChegar = false;
                if (!ferramentaReceptor.interactive) { }
                else if (ferramentaReceptor.tipo == ferramentaReceptor.fe.tipo) StartCoroutine("trat");
                SFX.sfx.SomDaFerramenta(ferramentaReceptor);
                break;
            case estados.delay:
                //executando corrotina 'trat'
                clickNoArtefato = false;
                if (pecaAindaTemQueSerLimpa || pecaAcabouDeFicarPronta) { //vai trocar de estado
                    SFX.sfx.StopSomDaFerramenta(ferramentaReceptor);
                    Destroy(ferramentaReceptor.gameObject);
                    Destroy(pensamentoImg);
                    //pecaAtual.GetComponentInChildren<ParticleSystem>().emission.enabled = true;
                }
                break;
            case estados.pronta:
                if (Bateria.tempo2 > 0.1) {
                    pecaAtual.GetComponent<Artefato>().brilhinhos.SetActive(true);
                } else {
                    pecaAtual.GetComponent<Artefato>().brilhinhos.SetActive(false);
                }
                break;
            case estados.despacha:
                //pecaAtual.transform.position = cesto.position; o colocaNaLista poe em (0,20,0)
                pecaAtual.GetComponent<Artefato>().brilhinhos.SetActive(false);
                Inventario.i.RemoverObjDaLista(pecaAtual , Inventario.tipoLista.limboLimpeza);
                Inventario.i.ColocaNaLista(pecaAtual , Inventario.tipoLista.pecasLimpas);
                contadorPecasLimpas.AtualizaComALista(Inventario.tipoLista.pecasLimpas);
                SFX.sfx.SomSucesso();
                Cesto.cesto.incrementaContadorPecasLimpas();

                break;
            case estados.acabaram:
                break;
        }

        //logica de proximo estado
        proximoEstado = estadoAtual;
        switch (estadoAtual) {
            case estados.pega:
                if (Inventario.i.TamanhoDaLista(Inventario.tipoLista.itens) == 0 && !peguei) {
                    proximoEstado = estados.acabaram;
                } else {
                    proximoEstado = estados.instanciaReceptor;
                }
                peguei = false;
                    break;
            case estados.instanciaReceptor:
                proximoEstado = estados.esperaFerramenta;
                break;
            case estados.esperaFerramenta:
                if (ferramentaAcabouDeChegar) proximoEstado = estados.ferramentaChegou;
                break;
            case estados.ferramentaChegou:
                if (ferramentaReceptor.tipo == ferramentaReceptor.fe.tipo) {
                    proximoEstado = estados.delay;
                } else {
                    proximoEstado = estados.esperaFerramenta;
                }
                break;
            case estados.delay:
                if (pecaAcabouDeFicarPronta) {
                    proximoEstado = estados.pronta; pecaAcabouDeFicarPronta = false;
                } else if (pecaAindaTemQueSerLimpa) {
                    proximoEstado = estados.instanciaReceptor; pecaAindaTemQueSerLimpa = false;
                }
                break;
            case estados.pronta:
                if (clickNoArtefato) proximoEstado = estados.despacha;
                break;
            case estados.despacha:
                if ( Inventario.i.TamanhoDaLista(Inventario.tipoLista.itens) == 0 ) {
                    proximoEstado = estados.acabaram;
                } else {
                    proximoEstado = estados.pega;
                }
                break;
            case estados.acabaram:
                break;
        }

        //atualizacao
        estadoAtual = proximoEstado;
    }

    //a corrotina expressa o que deve acontecer quando o jogador arrasta a
    //ferramenta certa ateh a peca.
    IEnumerator trat () {
        ferramentaReceptor.interactive = false;
        ferramentaReceptor.EnableSpriteRenderer(false);
        //GameObject slider = Resources.Load("slider") as GameObject;
        GameObject mySlider = Instantiate(slider , pontoOrigemSlider.position , Quaternion.identity);
        Image s = mySlider.GetComponentInChildren<Image>();
        float time = 2;//ferramentaReceptor.fe.actionTime + p.tratTime;
        float cont = 0;
        while (cont < time) {
            cont += Time.deltaTime;
            s.fillAmount = 1 - cont / time;
            yield return null;
        }
        Destroy(mySlider);

        Item item = pecaAtual.GetComponent<Item>();
        if (item.qualidade == Item.Qualidade.excelente) {
            pecaAcabouDeFicarPronta = true;
        } else {
            pecaAindaTemQueSerLimpa = true;
        }
        pecaAcabouDeFicarPronta = item.qualidade == Item.Qualidade.excelente;
        item.Melhorar();
        //p.ProximaDemanda();
    }
}
