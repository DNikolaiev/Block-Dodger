using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public BoxCollider2D player;
	public Rigidbody2D rb2D;
	public float slowDownFactor=10f;
	public  int defaultLifes=3;
	[HideInInspector]
	public int lifes;
	public Text life;
	public Text powerText;
	public int power=0;
	private float vel;
	public Image end;
	public Text endText;
	public Text exit;
	public Text restart;
	private bool canSlowDown;

	private void ActivateCanvas(bool state)
	{
		endText.enabled = state;
		exit.enabled = state;
		restart.enabled = state;
		end.enabled = state;
	}
	void Start()
	{
		canSlowDown = true;
		ActivateCanvas (false);
		player.GetComponent<BoxCollider2D> ();
		lifes = defaultLifes;
		life.GetComponent<Text> ();
		life.text = "Health: " + lifes;
		powerText.text = "Power: " + power + "/3";
		vel = FindObjectOfType<PlayerMovement> ().speed;


	}

	void Update()
	{
		life.text = "Health: " + lifes;
		if (power <= 2)
			powerText.text = "Power: " + power + "/3";
		else
			powerText.text = "Power: Space";
		if (power==3&&Input.GetKeyDown(KeyCode.Space))
		{
			StartCoroutine(ActivatePower(10f));
		}
		else if (Input.GetKeyUp(KeyCode.Space)&&canSlowDown)
		{
			SoundManager.instance.source2.pitch = 1f;
			FindObjectOfType<PlayerMovement>().speed=vel;
			Time.timeScale=1;

		}
	}


	public void AddPower()
	{

		if (power <= 2)
			power++;
		else
			power = 3;

	}


	public void LooseLife()
	{
		lifes--;
		if (lifes > 0) {
			StartCoroutine (SlowMotion (slowDownFactor));

		} else if (lifes < 0)
			lifes = 0; 
		else
			GameOver();
	}
	// Use this for initialization
	public IEnumerator SlowMotion(float slowDownFactor)
	{
		SoundManager.instance.source1.pitch = 0.6f;
		canSlowDown = false;
		SoundManager.instance.source2.pitch = 0.8f;
		Time.timeScale = 1f / slowDownFactor;
		player.enabled = false;
		Time.fixedDeltaTime = Time.fixedDeltaTime / slowDownFactor;
		yield return new WaitForSeconds(1f/slowDownFactor);
		Time.timeScale = 1f;
		Time.fixedDeltaTime = Time.fixedDeltaTime * slowDownFactor;
		player.enabled = true;
		SoundManager.instance.source2.pitch = 1f;
		FindObjectOfType<PlayerMovement>().speed=vel;
		canSlowDown = true;
		yield return null;

	}

	public IEnumerator ActivatePower(float slowDownFactor)
	{
		if (canSlowDown) {
			SoundManager.instance.source1.pitch = 0.6f;
			power = 0;
			SoundManager.instance.source2.pitch = 0.7f;
			Time.timeScale = 2f / slowDownFactor;
			FindObjectOfType<PlayerMovement> ().speed = FindObjectOfType<PlayerMovement> ().speed * slowDownFactor / 2;
			Time.fixedDeltaTime = Time.fixedDeltaTime / slowDownFactor;
			yield return new WaitForSeconds (2f);

			Time.timeScale = 1f;
			Time.fixedDeltaTime = Time.fixedDeltaTime * slowDownFactor;
			FindObjectOfType<PlayerMovement> ().speed = vel;
			SoundManager.instance.source2.pitch = 1f;
			yield return null;
		}

		
	}

	public IEnumerator EndMotion()
	{
		
		while (Time.timeScale>0) {
			SoundManager.instance.PlaySound(SoundManager.instance.gameOver);
			player.enabled = false;
			SoundManager.instance.source1.pitch-=0.2f;
			SoundManager.instance.source2.pitch-=0.2f;
			Time.timeScale-=0.2f;
			Time.fixedDeltaTime = Time.fixedDeltaTime -0.2f;
			yield return new WaitForSeconds(0.1f);
		}
		SoundManager.instance.source2.pitch=0;
		
	}

	void GameOver()
	{
		canSlowDown = false;
		StartCoroutine (EndMotion());
		FindObjectOfType<PlayerMovement> ().sprend.sprite = FindObjectOfType<PlayerMovement> ().whenDamaged;
		PlayerMovement.playerCanMove = false;
		ActivateCanvas (true);
		SoundManager.instance.source2.Stop ();
		endText.text = "Game Over!\n\nYou survived " + FindObjectOfType<SpawnManager> ().waves + " Waves";



}

	public void Restart()
	{
		PlayerMovement.playerCanMove = true;
		Application.LoadLevel (Application.loadedLevel);
		Time.timeScale = 1;

	}

}
