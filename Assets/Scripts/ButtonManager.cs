using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class ButtonManager : MonoBehaviour {

	public Text helpText;
	public Image screen;
	public float sliderValue=10f;


	void Start()
	{
		Activate (false);


	}

	public void Exit()
	{
		SoundManager.instance.PlaySound (SoundManager.instance.click);
		Application.Quit ();
	}

	public void Help()
	{
		SoundManager.instance.PlaySound (SoundManager.instance.click);
		Time.timeScale = 0;
		SoundManager.instance.source2.Pause ();
		Activate (true);

		if(Input.anyKey)
		{
			Activate(false);
			SoundManager.instance.source2.Play();
			Time.timeScale = 1;

		}
	
	}

	private void Activate (bool state)
	{
		helpText.enabled=state;
		screen.enabled=state;
	}

	public void LaunchGame()
	{
		SoundManager.instance.PlaySound (SoundManager.instance.click);
		Application.LoadLevel (1);
		SoundManager.instance.PlaySound (SoundManager.instance.load);
	}


}


