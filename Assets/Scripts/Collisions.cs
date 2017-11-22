using UnityEngine;
using System.Collections;

public class Collisions : MonoBehaviour {
	public BoxCollider2D block;

	void Update()
	{
		if (this.transform.position.y < -8f)
			Destroy (this.gameObject);
	}

	void Start()
	{
		block.GetComponent<BoxCollider2D> ();
	}
void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag=="wall")
			Destroy (this.gameObject);

	}

	void OnCollisionEnter2D (Collision2D other)
	{
	

		if (other.collider.tag == "Player") {
			SoundManager.instance.PlaySound(SoundManager.instance.white);
			block.enabled=false;
			FindObjectOfType<GameManager> ().LooseLife();
			
			}


	}
}
