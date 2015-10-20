using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class WorldGen : MonoBehaviour 
{
	public GameObject[] tiles;
	List<Vector3> positions= new List<Vector3>();
	public int worldSize = 10;
	// Use this for initialization
	void Start () 
	{
			for(int x = 0; x< worldSize; x ++)
			{
				for(int y = 0; y< worldSize; y ++)
				{
					positions.Add (new Vector3((x*10),0,(y*10)));
				}
			}
		GenerateMap ();

	}
	void GenerateMap()
	{
		for (int i = 0; i< positions.Count; i ++)
		{
			int rng = Random.Range (0, 6);
			Instantiate(tiles[rng], positions[i],Quaternion.identity);
		}
	}
}
