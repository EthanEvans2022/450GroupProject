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
	public Canvas mainMenu;
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
		Hide();
		currentLevel = 1;
		currentDialogue = 0;
	}
	
	public void Hide()
	{
		print("In the Hide() method of the MenuController\n");
		mainMenu.enabled = false;
		mainMenuOn = false;
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
		ToggleMainMenu();
	}
	

	// Toggle the main menu
	public void ToggleMainMenu()
	{
		print("In the ToggleMainMenu() method of the MenuController\n");
		// Turn off all menus
		mainMenu.enabled = false;
		directions.enabled = false;
		levelSelectMenu.enabled = false;
		nextLevelMenu.enabled = false;
		
		
		if (mainMenuOn)
		{
			mainMenu.enabled = false;
			mainMenuOn = false;
			Hide();
			//CharacterController.isPause = false;
		}
		else
		{
			mainMenu.enabled = true;
			mainMenuOn = true;
			//CharacterController.isPause = true;

		}
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
		levelSelectMenu.enabled = true;
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






