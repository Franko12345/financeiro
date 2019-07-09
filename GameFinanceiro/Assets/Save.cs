using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class Save : MonoBehaviour
{
    string nomeArquivoInventario = "/inventario.ccc";
    string nomeArquivoMelhoraveis = "/melhoraveis.ccc";
    Inventario inventario;
    Melhoraveis melhoraveis;

    private void Start () {
        if (inventario == null) inventario = Inventario.i;
        melhoraveis = Melhoraveis.m;
    }

    public void SalvaInventario () {
        SalvaTipo<DadosInventario>(nomeArquivoInventario , new DadosInventario(inventario));
    }

    public void LoadInventario () {
        DadosInventario dados = LoadTipo<DadosInventario>(nomeArquivoInventario);
        dados.CopiaProInventario(inventario);
    }

    public void SalvaMelhoraveis () {
        SalvaTipo<DadosMelhoraveis>(nomeArquivoMelhoraveis , new DadosMelhoraveis(melhoraveis));
    }

    public void LoadMelhoraveis () {
        DadosMelhoraveis dados = LoadTipo<DadosMelhoraveis>(nomeArquivoMelhoraveis);
        dados.CopiaProMelhoraveis(melhoraveis);
    }

    public void SalvaTipo<T> (string nomeArquivo, T dadosDoObjeto) {
        BinaryFormatter formater = new BinaryFormatter();
        string path = Application.persistentDataPath + nomeArquivo;
        FileStream stream = new FileStream(path, FileMode.Create);
        formater.Serialize(stream , dadosDoObjeto);
        stream.Close();
    }

    public T LoadTipo<T> (string nomeArquivo) {
        string path = Application.persistentDataPath + nomeArquivo;
        if (File.Exists(path)) {
            BinaryFormatter formater = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            T dados =  (T) formater.Deserialize(stream);
            stream.Close();

            return dados;
        } else {
            print("nao tem save!!!!!!!!!!!!");
            return default(T);
        }
    }
}
