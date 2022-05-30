using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{


   public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void openWebsiteZokiTwitter()
    {
        Application.OpenURL("https://twitter.com/zokiDev");
    }
    public void openWebsiteZokiItchIo()
    {
        Application.OpenURL("https://zokidev.itch.io/");
    }
    public void openWebsiteZombieAwakeCarrd()
    {
        Application.OpenURL("https://zombieawake.carrd.co/");
    }

    public void QuitGame()
    {
        QuitGame();
    }

}
