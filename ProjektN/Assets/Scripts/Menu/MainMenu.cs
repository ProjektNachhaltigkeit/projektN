using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject settingsMenuUI;
    public GameObject mainMenuUI;
    private static int menuIndex = 0;

    void Start()
    {
        Debug.Log("-----> MENUINDEX = " + getMenuIndex());
        if(getMenuIndex() == 1)
        {
            mainMenuUI.SetActive(false);
            settingsMenuUI.SetActive(true);
        }else
        {
            mainMenuUI.SetActive(true);
            settingsMenuUI.SetActive(false);
        }
    }

    public static int getMenuIndex()
    {
        return menuIndex;
    }

    public static void setMenuIndex(int index)
    {
        menuIndex = index;

    }

    public void PlayGame()
    {   
        setMenuIndex(1);
        Debug.Log("-----> MENUINDEX CHANGED TO: " + getMenuIndex());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void QuitGame()
    {
        //Does not happen inside the Unity Editor, only when built
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void setMainMenuUI (bool boolean)
    {
        mainMenuUI.SetActive(boolean);
    }

    public void setSettingsMenuUI(bool boolean)
    {
        settingsMenuUI.SetActive(boolean);
    }
}
