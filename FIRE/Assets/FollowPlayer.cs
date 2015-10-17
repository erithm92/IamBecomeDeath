using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour 
{
	public GameObject anchor;
	public GameObject player;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3(Mathf.Lerp (transform.position.x, anchor.transform.position.x, 4f *Time.deltaTime),
		                                 /*Mathf.Lerp (transform.position.y, anchor.transform.position.y, 2f)*/
		                                 transform.position.y,
		                                 Mathf.Lerp (transform.position.z, anchor.transform.position.z, 4f *Time.deltaTime));

	}
}
