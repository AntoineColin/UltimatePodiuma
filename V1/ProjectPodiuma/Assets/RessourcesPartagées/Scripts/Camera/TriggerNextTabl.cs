using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class TriggerNextTabl : MonoBehaviour {

	Vector2 tableauSuivant;

	public delegate void CamReset (int xTile, int yTile);
	public static event CamReset NextTabl;

	void OnEnable(){RespawnPlayer.OnDeath += Reset;}
	void OnDisable(){RespawnPlayer.OnDeath -= Reset;}


	void Start(){
		tableauSuivant = FollowingCamera.TellTab (transform.position);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		NextTabl ((int)tableauSuivant.x, (int)tableauSuivant.y);			//on génère un bloqueur d'où on vient
		GetComponent<Rigidbody2D> ().isKinematic = true;
	}

	void Reset(int useless, int parameters){
		GetComponent<Rigidbody2D> ().isKinematic = false;
	}
}
