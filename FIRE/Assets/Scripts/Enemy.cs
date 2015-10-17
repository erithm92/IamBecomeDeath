using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public delegate void EnemyDeathHandler ();
	public event EnemyDeathHandler onEnemyDeath;
	public int health;
	public int damage;
	public float moveSpeed;
	public float attackRange;
	public float attackInterval;
	public GameObject player;
	public Player playerScript;
	private float timer;
	private float fireTimer;
	public GameObject fire;
	public bool isOnFire;

	// Use this for initialization
	public virtual void Start () 
	{
		fire = (GameObject)Resources.Load ("Fire");
		player = GameObject.Find ("Player");
		playerScript = player.GetComponent<Player>();
	}
	
	// Update is called once per frame
	public virtual void Update () 
	{
//		if (Input.GetKeyDown(KeyCode.Space))
//		{
//			ApplyDamage(1000);
//		}
		timer += Time.deltaTime;
		if (isOnFire)
		{
			fireTimer += Time.deltaTime;
		}
		if (fireTimer >= 0.25f)
		{
			fireTimer = 0.0f;
			ApplyDamage(5);
		}
		if (player != null)
		{
			if (Vector3.Distance(transform.position, player.transform.position) <= attackRange)
			{
				transform.LookAt (player.transform.position);
				if (timer >= attackInterval)
				{
					Attack();
					timer = 0.0f;
				}
			}
			else
			{
				transform.LookAt (player.transform.position);
				transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
			}
		}
	}

	public virtual void ApplyDamage(int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			GameManager.GetInstance().AddScore("Enemy", 1);
			Destroy(gameObject);
		}
	}

	public virtual void Attack ()
	{
		playerScript.ApplyDamage(damage);
	}
}
