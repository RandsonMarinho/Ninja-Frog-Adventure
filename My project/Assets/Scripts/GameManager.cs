using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
/* CRIANDO UM SIMPLES SCRIPT SOMENTE PARA ARMAZENAR OS MÉTODOS QUE SERÃO UTILIZADOS NOS BOTÕES DA INTERFACE*/
//-----------------------------------------------------------------------------------------------------------------

    //               MÉTODO PARA REINICIAR O JOGO
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }


    //               MÉTODO PARA SAIR DO JOGO
    public void Quit()
    {
        Application.Quit();
    }
}
