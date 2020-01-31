using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerMenu : MonoBehaviour
{
    public void Chunli()
    {
        SceneManager.LoadScene("Chunli");
    }

    public void Kratos()
    {
        SceneManager.LoadScene("Kratos");
    }

    public void Mario()
    {
        SceneManager.LoadScene("Mario");
    }

    public void Pikachu()
    {
        SceneManager.LoadScene("Pikachu");
    }

    public void Fechar()
    {
        SceneManager.LoadScene("Inicio");
    }
}
