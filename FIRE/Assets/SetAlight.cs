using UnityEngine;
using System.Collections;

public class SetAlight : MonoBehaviour {

	//public GameObject Burning;
	public GameObject player;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnParticleCollision(GameObject other)
	{
		if (other.gameObject.tag == "Tree") 
		{
			other.GetComponent<TreeLight>().loseHealth();
			//Rigidbody burnVictim = other.GetComponent<Rigidbody> ();
			//if (burnVictim) {
				//print ("onfire");
				//Instantiate (Burning, other.transform.position + Vector3.up, Quaternion.identity);
			//}
		}
		if (other.gameObject.tag == "Oil") 
		{
			other.GetComponent<Oil>().OnFire();
		}
		if (other.gameObject.name.Contains ("Enemy")) 
		{
			other.GetComponent<Enemy>().ApplyDamage(10);
		}
		if (other.gameObject.name.Contains ("Brute")) 
		{
			other.GetComponent<Brute>().ApplyDamage(10);
		}
		if (other.gameObject.name.Contains ("Spiker")) 
		{
			other.GetComponent<Spiker>().ApplyDamage(10);
		}
	}

}
