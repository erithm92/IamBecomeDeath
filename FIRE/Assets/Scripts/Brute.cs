using UnityEngine;
using System.Collections;

public class Brute : Enemy
{

	// Use this for initialization
	public override void Start () 
	{
		damage *= 2;
		health *= 2;
		moveSpeed /= 2.0f;
		transform.localScale += new Vector3(1.0f, 1.0f, 1.0f);
		base.Start ();
	}
	
	// Update is called once per frame
	public override void Update () 
	{
		base.Update ();
	}

	public override void Attack ()
	{
		playerScript.ApplyDamage(damage);
	}
}
