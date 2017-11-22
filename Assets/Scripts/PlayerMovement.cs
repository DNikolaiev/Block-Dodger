using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public  float speed=15f;
	public float maxWidth=4f;

	public SpriteRenderer sprend;
	public Sprite whenHealed;
	public Sprite whenDamaged;
	public Sprite whenPowered;
	private Sprite defSprite;
	public static bool playerCanMove=true;


	Rigidbody2D rb2D;
	BoxCollider2D col;
	float x;

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
		sprend.GetComponent<SpriteRenderer> ();
		defSprite = sprend.sprite;

	}
	
	// Update is called once per frame
	void FixedUpdate () {


			x = Input.GetAxis ("Horizontal") * Time.fixedDeltaTime * speed;

		Vector2 target = this.transform.position + transform.right * x;
		target.x = Mathf.Clamp (target.x, -maxWidth, maxWidth);
		if (playerCanMove)
		rb2D.MovePosition (target);

	}

	void OnTriggerEnter2D(Collider2D block)
	{
		if (block.tag == "Green")
			StartCoroutine (ChangeColor (whenHealed));
		else if (block.tag == "Blue")
			StartCoroutine (ChangeColor (whenPowered));


	}

	IEnumerator ChangeColor(Sprite anotherSprite)
	{
		this.sprend.sprite = anotherSprite;
		yield return new WaitForSeconds(0.2f);
		this.sprend.sprite = defSprite; 
	} 
}
