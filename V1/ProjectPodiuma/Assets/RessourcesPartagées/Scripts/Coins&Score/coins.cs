using UnityEngine;
using System.Collections;


public class coins : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.transform.tag == "Player") 
		{
			changementScore.score += 100;
			Destroy (gameObject);

		}
		
	}



}
