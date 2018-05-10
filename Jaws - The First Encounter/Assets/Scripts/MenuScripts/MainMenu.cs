using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // AudioManager.Play(AudioClipName.__________);
        MenuManager.GoToMenu(MenuNames.scene0);
    }

    public void OpenHelp()
    {
        // AudioManager.Play(AudioClipName.__________);
        MenuManager.GoToMenu(MenuNames.HelpMenu);
    }

    public void Back()
    {
        // AudioManager.Play(AudioClipName.__________);
        MenuManager.GoToMenu(MenuNames.Menu);
    }

    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
    