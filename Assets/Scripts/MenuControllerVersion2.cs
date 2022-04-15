using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuControllerVersion2 : MonoBehaviour
{
    public static MenuControllerVersion2 instance;
    
    // Outlets
    public GameObject mainMenu;
    public GameObject levelMenu;
   
    // Methods
    void Awake()
    {
        instance = this;
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        ShowMainMenu();
        CharacterController.instance.isPaused = true;
        if (MouseController.instance && KeyboardController.instance)
        {
            MouseController.instance.isPaused = true;
            KeyboardController.instance.isPaused = true;
        }
        Time.timeScale = 0;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        if (CharacterController.instance != null)
        {
            CharacterController.instance.isPaused = false;
        }

        if (MouseController.instance && KeyboardController.instance)
        {
            MouseController.instance.isPaused = false;
            KeyboardController.instance.isPaused = false;
        }
    }

    void SwitchMenu(GameObject someMenu)
    {
        print("in SwitchMenu(), called with parameter: " + someMenu);
        // Turn off all menus
        mainMenu.SetActive(false);
        levelMenu.SetActive(false);
        
        // Turn on requested menu
        someMenu.SetActive(true);
    }

    public void ShowMainMenu()
    {
        SwitchMenu(mainMenu);
    }

    public void ShowLevelMenu()
    {
        SwitchMenu(levelMenu);
    }
    
    public void LoadLevel(int level)
    {
        SceneManager.LoadSceneAsync(level);
    }
}
