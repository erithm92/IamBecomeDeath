using UnityEngine;
using System.Collections;
public class Oil : MonoBehaviour {
	public GameObject fire;
	public bool onFire = false;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnFire()
	{
		if (!onFire) 
		{
			GameObject a = Instantiate (fire, transform.position + new Vector3 (0, .3f, 0), Quaternion.identity)
				as GameObject;
			a.transform.parent = transform;
			StartCoroutine("Die");
			onFire = true;
		}
	}
	 IEnumerator Die()
	{
		yield return new WaitForSeconds(5);
	
		Destroy(gameObject);
	}
}
