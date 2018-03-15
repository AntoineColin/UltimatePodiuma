using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RespawnPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}


	void OnTriggerEnter2D(Collider2D oth) 
	{

		if (oth.gameObject.transform.tag == "Respawn") {
			Application.LoadLevel ("Test");
			Debug.Log ("Recommencer");
		}

	}
}

