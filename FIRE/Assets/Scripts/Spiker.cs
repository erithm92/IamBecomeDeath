using UnityEngine;
using System.Collections;

public class Spiker : Enemy
{
	private GameObject projectile;
	public GameObject shootSpot;

	// Use this for initialization
	public override void Start () 
	{
		projectile = Resources.Load ("TreeProjectile")as GameObject;
		shootSpot = transform.FindChild ("ShootSpot").gameObject;
		base.Start ();
	}
	
	// Update is called once per frame
	public override void Update () 
	{
		base.Update ();
	}

	public override void Attack ()
	{
		GameObject temp = (GameObject)Instantiate (projectile, shootSpot.transform.position, shootSpot.transform.rotation);
		temp.GetComponent<Projectile>().damage = damage;
	}
}
