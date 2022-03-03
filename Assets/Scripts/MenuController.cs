//Source/Citation: Quest 7

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	//	Outlets
	public static MenuController instance;
	public GameObject mainMenu;
	public GameObject optionsMenu;
	public GameObject levelMenu;
	public GameObject nextMenu;
	private AssetBundle myLoadedAssetBundle;
	private string[] scenePaths;
	
	// States
	private bool mainMenuOn;


	// Methods
	void Awake() 
	{
		//print("top of Awake()");
		instance = this;
		mainMenuOn = false;
		Hide();
	}



	public void Show()
	{
		//print("top of Show()");
		this.gameObject.SetActive(true);
	}

	public void Hide()
	{
		//print("top of Hide()");
		this.gameObject.SetActive(false);
	}

	void SwitchMenu(GameObject someMenu)
	{
		//print("top of SwitchMenu()");
		//Turn off all menus
		mainMenu.SetActive(false);
		optionsMenu.SetActive(false);
		levelMenu.SetActive(false);
		nextMenu.SetActive(false);
		Hide();

		// Turn on requested menu
		Show();
		someMenu.SetActive(true);
	}

	// Even simpler switch menu functions:
	public void ShowMainMenu()
	{
		//print("top of ShowMainMenu()");
		SwitchMenu(mainMenu);
	}
	
	// Toggle the main menu
	public void ToggleMainMenu()
	{
		print("top of ToggleMainMenu()");
		
		// Turn off all menus
		mainMenu.SetActive(false);
		optionsMenu.SetActive(false);
		levelMenu.SetActive(false);
		nextMenu.SetActive(false);
		Hide();
		
		
		if (mainMenuOn)
		{
			print("in ToggleMainMenu(), in the if");
			mainMenu.SetActive(false);
			mainMenuOn = false;
			Hide();
		}
		else
		{
			print("in ToggleMainMenu(), in the else");
			mainMenu.SetActive(true);
			mainMenuOn = true;
			Show();
		}
	}

	public void ShowOptionsMenu()
	{ 
		//print("top of ShowOptionsMenu()");
		SwitchMenu(optionsMenu);
	}

	public void ShowLevelMenu()
	{
		//print("top of ShowLevelMenu()");
		SwitchMenu(levelMenu);
	}

	public void ShowNextMenu()
	{
		print("top of ShowNextMenu()");
		SwitchMenu(nextMenu);
	}
	
}












