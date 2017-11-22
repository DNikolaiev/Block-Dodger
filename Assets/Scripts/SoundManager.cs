using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public AudioSource source1;
	public AudioSource source2;
	public AudioClip green;
	public AudioClip blue;
	public AudioClip red;
	public AudioClip white;
	public AudioClip gameOver;
	public AudioClip click;
	public AudioClip load;
	public static SoundManager instance=null;

	void Awake()
	{
		if (instance == null)
		{
			instance=this;
		} 
		else  if (instance!=this)
		{
			Destroy (gameObject);
		}
	}
	// Use this for initialization
	void Start () {

		source2.GetComponent<AudioSource> ();
		source2.Play ();

	}
	
	public void PlaySound(AudioClip clip)
	{			
		source1.clip = clip;
		source1.Play ();
	}
}
