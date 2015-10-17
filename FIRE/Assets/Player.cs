﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Player : MonoBehaviour 
{
	Rigidbody rb;
	public GameObject flamer;
	public float speed = 10;
	Vector3 normalizedMovement;
	public GameObject flameSpawn;
	public GameObject mainCam;
	public float rotSpeed = 50;
	public List<GameObject> oilSlick = new List<GameObject> ();
	public float health = 100; 
	// Use this for initialization
	void Start () 
	{

		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		normalizedMovement = Vector3.zero;


	 	if (Input.GetKey (KeyCode.W)) 
		{
			normalizedMovement += Vector3.forward;
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			normalizedMovement += Vector3.left;
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			normalizedMovement += Vector3.back;
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			normalizedMovement += Vector3.right;
		}
		if (normalizedMovement != Vector3.zero) 
		{
			rb.transform.Translate (normalizedMovement * speed* Time.deltaTime);
		}
		if (Input.GetKeyDown (KeyCode.Mouse0)) 
		{
			flameSpawn.GetComponent<ParticleSystem>().Play();
		}
		if (Input.GetKeyUp (KeyCode.Mouse0)) 
		{
			flameSpawn.GetComponent<ParticleSystem>().Stop();
		}
		if (Input.GetKeyDown (KeyCode.Mouse1)) 
		{
			flameSpawn.GetComponent<ParticleSystem>().emissionRate +=3;
			flameSpawn.GetComponent<ParticleSystem>().startSpeed +=3;
			flameSpawn.GetComponent<ParticleSystem>().startSize +=1.5f;
			flameSpawn.GetComponent<ParticleSystem>().Play();
		}
		if (Input.GetKeyUp (KeyCode.Mouse1)) 
		{
			flameSpawn.GetComponent<ParticleSystem>().emissionRate -=3;
			flameSpawn.GetComponent<ParticleSystem>().startSpeed -=3;
			flameSpawn.GetComponent<ParticleSystem>().startSize -=1.5f;
			flameSpawn.GetComponent<ParticleSystem>().Play();
			flameSpawn.GetComponent<ParticleSystem>().Stop();
		}
		RotateToMouse ();

	}
	void RotateToMouse() {
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);

		//flamer.transform.LookAt(mousePos);
		mousePos -= flamer.transform.position;
		Quaternion lerpTo = Quaternion.LookRotation (new Vector3(mousePos.x,flamer.transform.position.y,mousePos.z));
		flamer.transform.rotation = Quaternion.Lerp(transform.rotation, lerpTo, rotSpeed);
	}
	public void ApplyDamage( int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			Destroy(gameObject);
		}
	}
}
