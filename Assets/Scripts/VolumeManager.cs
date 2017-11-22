using UnityEngine;
using System.Collections;

public class VolumeManager : MonoBehaviour {

	private float sliderValue=1f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


			AudioListener.volume = sliderValue;
		
	}
	public void VolumeControle(float volumeControle)
	{
		AudioListener.volume = sliderValue;

	}

}
