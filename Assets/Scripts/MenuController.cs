//Source/Citation: Quest 7

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{

	//	Outlets
	public static MenuController instance;
	public Canvas mainMenu;
	public Canvas directions;
	public Canvas levelSelectMenu;
	
	// States
	private bool mainMenuOn;


	// Methods
	void Awake() 
	{
		instance = this;
		mainMenuOn = false;
		Hide();
	}
	
	public void Hide()
	{
		mainMenu.enabled = false;
		directions.enabled = false;
		levelSelectMenu.enabled = false;
	}
	
	public void ShowMainMenu()
	{
		mainMenuOn = false;
		ToggleMainMenu();
	}
	

	// Toggle the main menu
	public void ToggleMainMenu()
	{
		// Turn off all menus
		mainMenu.enabled = false;
		directions.enabled = false;
		levelSelectMenu.enabled = false;
		
		
		if (mainMenuOn)
		{
			mainMenu.enabled = false;
			mainMenuOn = false;
			Hide();
		}
		else
		{
			mainMenu.enabled = true;
			mainMenuOn = true;
		}
	}
	
	public void ShowDirectionsMenu()
	{
		Hide();
		directions.enabled = true;
	}

	public void ShowLevelSelectMenu()
	{
		Hide();
		levelSelectMenu.enabled = true;
	}

	public void LevelOne()
	{
		Hide();
		SceneManager.LoadScene("mark_w5");
	}

	public void LevelTwo()
	{
		Hide();
		SceneManager.LoadScene("LightingTest");
	}
	
}






