using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour {

	public GameObject[] spawnPoints;
	public GameObject block;
	public GameObject powerBlock;
	public GameObject healBlock;
	public GameObject killBlock;
	private GameObject spawnobj;
	public float timeBetweenWaves=2f;
	public float spawnRate=2.1f;
	public int waves;
	public Text score;
	private float param=0.08f;

	private int randomIndex;
	private int Index;
	public int bonusFrequency=10;


	// Use this for initialization
	void Start () {
		block.GetComponent<GameObject> ();
		score.GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= timeBetweenWaves)
		{
			StartCoroutine(Fall (timeBetweenWaves));
			timeBetweenWaves=Time.time+spawnRate;
			spawnRate=Mathf.Clamp(spawnRate-param,0.7f,spawnRate);

			if(waves==20) 
				param=.02f;
			if(waves==40)
				param=0.1f;


		}


	}

	IEnumerator Fall (float timeBetweenWaves)
	{
		randomIndex = Random.Range (0, spawnPoints.Length);


		for (int i=0; i<spawnPoints.Length;i++)
		{
			Index=Random.Range(0,bonusFrequency);


			if(i!=randomIndex)
			{
				if(Index==bonusFrequency/2)
				{
					spawnobj=killBlock;
				}
				else if (Index==bonusFrequency/2+3)
				{
					spawnobj=healBlock;
				}
				else if (Index==1)
				{
					spawnobj=powerBlock;
				}
				else spawnobj=block;
				Instantiate(spawnobj,spawnPoints[i].transform.position,Quaternion.identity);
			}
		}
		waves++;
		score.text = "Wave: " + waves;
		yield return new WaitForSeconds(timeBetweenWaves);


	}




}
