using UnityEngine;
using System.Collections;

public class RedCollided : MonoBehaviour {
	public SpriteRenderer spren;


	void Start()
	{
		spren.GetComponent<SpriteRenderer> ();
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		if (this.tag == "Red") {
			if (other.collider.tag == "Player") {
				SoundManager.instance.PlaySound(SoundManager.instance.red);
				spren.color=Color.white;
				
				FindObjectOfType<GameManager> ().lifes = 1;
				FindObjectOfType<GameManager> ().LooseLife ();

			}
		}
	}
}
