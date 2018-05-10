using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// manages moving between scenes / menus
/// </summary>
public static class MenuManager
{
    /// <summary>
    /// Goes to menu with given name
    /// </summary>
    /// <param name="name">name of menu to go to</param>
    public static void GoToMenu(MenuNames name)
    {
        switch (name)
        {
            case MenuNames.scene0:
                SceneManager.LoadScene("scene0");
                break;
            case MenuNames.Menu:
                SceneManager.LoadScene("Menu");
                break;
            case MenuNames.HelpMenu:
                SceneManager.LoadScene("HelpMenu");
                break;
        }
    }
}
