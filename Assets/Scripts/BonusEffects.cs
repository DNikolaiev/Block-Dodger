using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BonusEffects : MonoBehaviour {




	void OnTriggerEnter2D(Collider2D other)
	{
		if (this.tag == "Green") {
			if (other.tag == "Player") {
				Destroy (this.gameObject);
				FindObjectOfType<GameManager> ().lifes++;
				SoundManager.instance.PlaySound(SoundManager.instance.green);

			}
		}  else if (this.tag == "Blue") {
		
			if (other.tag=="Player"){
				Destroy(this.gameObject);
				FindObjectOfType<GameManager>().AddPower();
				SoundManager.instance.PlaySound(SoundManager.instance.blue);
			}
		}
		if(other.tag=="wall")
		{
			Destroy(this.gameObject);
		}
	}




}

