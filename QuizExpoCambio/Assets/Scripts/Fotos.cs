using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Fotos : MonoBehaviour
{
    // Start is called before the first frame update

    public List<string> fotos = new List<string>();
    public int indice = 0;

    /*private void Start()
    {
        Listar();
    }*/

    public void Listar(){
        Debug.Log("Carregar Foto");
        
        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        FileInfo[] info = dir.GetFiles("*.*");
        foreach (FileInfo f in info){
            fotos.Add(f.ToString());
        }

        foreach (string item in fotos){
            Debug.Log(item);
        }

        byte[] byteArray = File.ReadAllBytes(@fotos[indice]);
        Texture2D sampleTexture = new Texture2D(2,2);
        bool isLoaded = sampleTexture.LoadImage(byteArray);
        GameObject image = GameObject.Find("RawImage");
        if (isLoaded)
        {
            image.GetComponent<RawImage>().texture = sampleTexture;
        }
    }


    public void Anterior(){
        indice--;
        byte[] byteArray = File.ReadAllBytes(@fotos[indice + 1]);
        Texture2D sampleTexture = new Texture2D(2,2);
        bool isLoaded = sampleTexture.LoadImage(byteArray);
        GameObject image = GameObject.Find("RawImage");
        if (isLoaded)
        {
            image.GetComponent<RawImage>().texture = sampleTexture;
        }
    }

    public void Proxima(){
        indice++;
        byte[] byteArray = File.ReadAllBytes(@fotos[indice + 1]);
        Texture2D sampleTexture = new Texture2D(2,2);
        bool isLoaded = sampleTexture.LoadImage(byteArray);
        GameObject image = GameObject.Find("RawImage");
        if (isLoaded)
        {
            image.GetComponent<RawImage>().texture = sampleTexture;
        }
    }
}
