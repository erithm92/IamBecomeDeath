using UnityEngine;
using System.Collections;

public class TreeSeed : MonoBehaviour 
{
	public float  timer= 20.0f;
	public GameObject tree;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
		if (timer <= 0) 
		{
			Instantiate(tree, transform.position,Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
