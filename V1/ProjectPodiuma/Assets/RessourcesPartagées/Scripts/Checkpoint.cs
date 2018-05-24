using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D oth){
		if(oth.gameObject.tag == "Player"){	//Si on trouve un checkpoint
			Debug.Log ("trigger");
			oth.gameObject.GetComponent<RespawnPlayer> ().checkpoint = gameObject;	//on le garde en mémoire
		}
	}
}
