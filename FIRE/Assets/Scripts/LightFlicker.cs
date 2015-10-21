using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {
	Light fire;
	public bool switcher = false;
	Color orig;
	// Use this for initialization
	void Start () 
	{
		fire = GetComponent<Light> ();
		switcher = false;
		//fire.intensity = 3;
		//orig = fire.color;
		StartCoroutine("Flicker");
	}
	// Update is called once per frame
	void Update () 
	{
		//if (!switcher)
		
	}
	IEnumerator Flicker()
	{
		//switcher = true;
		while (true) {
			//fire.enabled = true;
			fire.intensity = Random.Range (2.5f, 4);
			yield return new WaitForSeconds (Random.Range (.1f, .3f));
			//fire.enabled = false;
			fire.intensity = Random.Range (0f, .3f);
			yield return new WaitForSeconds (Random.Range (.1f, .3f));
		}
		//switcher = false;
	}
}

