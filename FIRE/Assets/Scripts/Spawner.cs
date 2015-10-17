using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
	public GameObject[] enemyPrefabs;
	private GameObject spawnPoint;
	private GameObject[] spawnPoints;
	private float timer;
	public float spawnInterval;
	public float spawnRateCap;


	// Use this for initialization
	void Start () 
	{
		enemyPrefabs = Resources.LoadAll<GameObject>("Enemies");
		spawnPoints = GameObject.FindGameObjectsWithTag ("SpawnPoint");
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		if (timer >= spawnInterval)
		{
			SpawnEntity();
			timer = 0.0f;
		}
	}

	public void IncreaseSpawnRate()
	{
		if (spawnInterval >= spawnRateCap)
		{
			spawnInterval -= 0.1f;
		}
	}

	public void DecreaseSpawnRate()
	{
		if (spawnInterval != spawnRateCap)
		{
			spawnInterval += 0.05f;
		}
	}

	private void SpawnEntity ()
	{
		int treeScore = GameManager.GetInstance ().treeScore;
		spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
		if (treeScore >= 5 && treeScore < 15)
		{
			Instantiate (enemyPrefabs[Random.Range(1, enemyPrefabs.Length)], spawnPoint.transform.position, spawnPoint.transform.rotation);
		}
		else if (treeScore >= 15)
		{
			Instantiate (enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], spawnPoint.transform.position, spawnPoint.transform.rotation);
		}
		else
		{
			Instantiate (enemyPrefabs[Random.Range(1, 2)], spawnPoint.transform.position+ Vector3.up, spawnPoint.transform.rotation);
		}
	}
}
