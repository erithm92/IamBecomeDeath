using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	private static GameManager instance;
	private Player player;
	private Spawner spawner;
	public int score;
	public int treeScore;

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () 
	{
		spawner = GameObject.Find ("Spawner").GetComponent<Spawner>();
		player = GameObject.Find ("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void AddScore(string type, int Score)
	{
		if (type == "Enemy")
		{
			score += Score;
			print (score);
		}
		else
		{
			treeScore += Score;
			spawner.IncreaseSpawnRate();
			print (treeScore);
		}
	}

	public static GameManager GetInstance()
	{
		return instance;
	}
}