using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene("LightingTest");
    }

	public void NextLevelBack()
	{
		MenuController.instance.Hide();
	}

	public void PlayButton()
	{
		MenuController.instance.ToggleMainMenu();
	}

	public void LevelSelect()
	{
		MenuController.instance.ShowLevelMenu();
	}

	public void LevelSelectBack()
	{
		MenuController.instance.ShowMainMenu();
	}

	public void LevelOne()
	{
		SceneManager.LoadScene("mark_w5");
	}

	public void LevelTwo()
	{
		SceneManager.LoadScene("LightingTest");
	}
}
