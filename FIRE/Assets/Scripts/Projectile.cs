using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	public float speed;
	public int damage;
	public int health;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.up * speed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.name == "Player")
		{
			other.gameObject.GetComponent<Player>().ApplyDamage(damage);
		}
	}
}
