using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melhoraveis : MonoBehaviour
{
    int prestigioPorPecaLimpa = 50;

    public int ciclo = 1;
    private int maximoCiclos = 11;

    public int tierPrestigio = 1;
    private int tierMaximo = 5;

    public int progressoPrestigio = 0;
    public int maximoProgressoPrestigio = 500;

    //nao estou salvando os seguintes (no save/load)
    public bool tendaReforcada = false;
    public int numeroSitiosEscav = 1;
    public float precoCombustivel = 4;

    public static Melhoraveis m;
    private void Awake () {
        if (!m) {
            m = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public float GetCiclo () {
        return ciclo;
    }

    public bool SomaAoCiclo (int somar) {
        if (ciclo+somar < maximoCiclos) {
            ciclo += somar;
            return true;
        } else {
            return false;
        }
    }

    public float GranaDoCiclo () {
        return (tierPrestigio) * 2048;
    }

    public void ProgressoPrestigio (int quantia) {
        quantia = quantia * prestigioPorPecaLimpa;

        progressoPrestigio = progressoPrestigio + quantia;

        while (progressoPrestigio > maximoProgressoPrestigio && tierPrestigio < tierMaximo) {
            progressoPrestigio -= maximoProgressoPrestigio;
            tierPrestigio++;
        }

        print("tier: " + tierPrestigio + " progressoPrestigio: " + progressoPrestigio);        

    }

    public void TendaReforcada () {
        bool deu = Inventario.i.SomaAoDinheiro(-2500);
        if (deu) {
            tendaReforcada = true;
            print("tenda foi reforçada.");
        } else {
            print("nao ha dinheiro para reforcar a tenda.");
        }
    }

    public void PalestraInternacional () {
        bool deu = Inventario.i.SomaAoDinheiro(-1000);
        if (deu) {
            ProgressoPrestigio(150);
        } else {
            print("nao ha dinheiro para palestra internacional.");
        }
    }

    public void Prospeccao1 () {
        bool deu = Inventario.i.SomaAoDinheiro(-3000);
        if (deu) {
            numeroSitiosEscav += 1;
        } else {
            //print("dinheiro insuficiente para Prospeccao1");
        }
    }

    public void Prospeccao2 () {
        Prospeccao1();
    }

    public void Prospeccao3 () {
        Prospeccao1();
    }

    public void RevisaoNoAutomovel () {
        bool deu = Inventario.i.SomaAoDinheiro(-2000);
        if (deu) {
            precoCombustivel *= .85f;
        } else {
            
        }
    }

}
