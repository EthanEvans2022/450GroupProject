//Source/Citation: Quest 7

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



public class MenuController : MonoBehaviour
{

	//	Outlets
	public static MenuController instance;
	//public Canvas mainMenu;
	public GameObject mainMenu;
	public Canvas directions;
	public Canvas levelSelectMenu;
	public Canvas nextLevelMenu;
	public Canvas dialogueBox;
	public TMP_Text dialogueText;
	
	// States
	private bool mainMenuOn;
	private int currentLevel;
	private int currentDialogue;
	
	// Configurations
	private string[] textParts =
	{
		"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
		"Semper viverra nam libero justo. Arcu odio ut sem nulla pharetra diam sit amet.",
		"Varius morbi enim nunc faucibus a pellentesque sit amet. Id donec ultrices tincidunt arcu. Imperdiet sed euismod nisi porta lorem mollis."
	};


	// Methods
	void Awake() 
	{
		print("In the Awake() method of the MenuController\n");
		instance = this;
		mainMenuOn = false;
		print("in Awake(), mainMenuOn = " + mainMenuOn);
		Hide();
		currentLevel = 1;
		currentDialogue = 0;
	}
	
	public void Hide()
	{
		print("In the Hide() method of the MenuController\n");
		//mainMenu.enabled = false;
		mainMenu.SetActive(false);
		mainMenuOn = false;
		print("in Hide(), mainMenuOn = " + mainMenuOn);
		//print("in Hide(), mainMenu.enabled = " + mainMenu.enabled);
		directions.enabled = false;
		levelSelectMenu.enabled = false;
		nextLevelMenu.enabled = false;
		dialogueBox.enabled = false;
		dialogueText.enabled = false;
	}
	
	public void ShowMainMenu()
	{
		print("In the ShowMainMenu() method of the MenuController\n");
		mainMenuOn = false;
		print("in ShowMainMenu(), mainMenuOn = " + mainMenuOn);
		ToggleMainMenu();
	}
	

	// Toggle the main menu
	public void ToggleMainMenu()
	{
		//print("At the top of ToggleMainMenu() method of the MenuController. mainMenu.enabled: " + mainMenu.enabled);
		// Turn off all menus
		//mainMenu.enabled = false;
		mainMenu.SetActive(false);
		directions.enabled = false;
		levelSelectMenu.enabled = false;
		nextLevelMenu.enabled = false;
		//print("in ToggleMainMenu() before the if-else statement, mainMenuOn = " + mainMenuOn + ", mainMenu.enabled: " + mainMenu.enabled);
		
		if (mainMenuOn)
		{
			//mainMenu.enabled = false;
			mainMenu.SetActive(false);
			mainMenuOn = false;
			Hide();
			print("in the if statement\n");
			print("mainMenuOn is: " + mainMenuOn);
			//print("mainMenu.enabled is: " + mainMenu.enabled);
			//CharacterController.isPause = false;
		}
		else
		{
			//mainMenu.enabled = true;
			mainMenu.SetActive(true);
			mainMenuOn = true;
			print("in the else statement\n");
			print("mainMenuOn is: " + mainMenuOn);
			//print("mainMenu.enabled is: " + mainMenu.enabled);
			//CharacterController.isPause = true;

		}

		//print("at the bottom of the ToggleMainMenu() method of the MenuController. Value of mainMenuOn: " + mainMenuOn + ". Value of mainMenu.enabled: " + mainMenu.enabled);
	}
	
	// Show menus
	public void ShowDirectionsMenu()
	{
		print("In the ShowDirectionsMenu() method of the MenuController\n");
		Hide();
		directions.enabled = true;
	}
	
	public void ShowLevelSelectMenu()
	{
		print("In the ShowLevelSelectMenu() method of the MenuController\n");
		Hide();
		//levelSelectMenu.enabled = true;
	}
	
	public void ShowNextLevelMenu()
	{
		print("In the ShowNextLevelMenu() method of the MenuController\n");
		Hide();
		nextLevelMenu.enabled = true;
	}
	
	// Level Select Menu Button Functionality
	public void LevelOne()
	{
		print("In the LevelOne() method of the MenuController\n");
		Hide();
		SceneManager.LoadScene("mark_w5");
	}

	public void LevelTwo()
	{
		print("In the LevelTwo() method of the MenuController\n");
		Hide();
		SceneManager.LoadScene("LightingTest");
	}

	// Next Level Menu Button Functionality
	public void Replay()
	{
		print("In the Replay() method of the MenuController\n");
		SceneManager.LoadScene("mark_w5");
	}

	public void NextLevel()
	{
		print("In the NextLevel() method of the MenuController\n");
		SceneManager.LoadScene("LightingTest");
		Hide();
	}
	
	// Dialogue Box Functionality
	public void DisplayDialogue()
	{
		dialogueBox.enabled = true;
		dialogueText.enabled = true;

		if (currentDialogue < textParts.Length)
		{
			dialogueText.text = textParts[currentDialogue];
			currentDialogue = currentDialogue + 1;
		}
		else
		{
			dialogueBox.enabled = false;
			dialogueText.enabled = false;
			currentDialogue = 0;
		}

	}
	
}






