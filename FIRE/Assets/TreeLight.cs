using UnityEngine;
using System.Collections;

public class TreeLight : MonoBehaviour 
{
	public float health = 50.0f;
	public GameObject tree;
	public GameObject crown;
	public GameObject burningObject;
	public int flameCount = 0;
	public GameObject treeSeed;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (health < 30) 
		{
			crown.GetComponent<MeshRenderer> ().material.color = Color.black;
		}
		if (health < 0) 
		{
			Instantiate(treeSeed, transform.position+ Vector3.down, Quaternion.identity);
			Destroy (tree);

		}
			
	}
	public void loseHealth()
	{
		health -= .3f;
		if (health <= 50&& health >30) {
			if (flameCount == 0) {
				StartCoroutine(Burning(1));
				crown.GetComponent<MeshRenderer>().material.color = Color.gray;
				GameObject burn = Instantiate (burningObject, 
				                               transform.position + new Vector3(0,4,-1.5f), 
				                               Quaternion.identity)as GameObject;
				burn.transform.parent = tree.transform;

				flameCount ++;
			}
		}
		else if (health <= 30&& health >0) {
			if (flameCount == 1) 
			{
				crown.GetComponent<MeshRenderer>().material.color = Color.black;
				GameObject burn = Instantiate (burningObject, 
				                               transform.position + new Vector3(0,4, 0), 
				                               Quaternion.identity)as GameObject;
				burn.transform.parent = tree.transform;
				flameCount ++;
			}
		}
	}
	public IEnumerator Burning(int dmg)
	{
		while (health >=0) 
		{
			health -= dmg;
			yield return new WaitForSeconds(.25f);
		}

	}
}
