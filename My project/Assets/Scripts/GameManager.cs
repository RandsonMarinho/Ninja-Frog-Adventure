using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
/* CRIANDO UM SIMPLES SCRIPT SOMENTE PARA ARMAZENAR OS M�TODOS QUE SER�O UTILIZADOS NOS BOT�ES DA INTERFACE*/
//-----------------------------------------------------------------------------------------------------------------

    //               M�TODO PARA REINICIAR O JOGO
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }


    //               M�TODO PARA SAIR DO JOGO
    public void Quit()
    {
        Application.Quit();
    }
}
