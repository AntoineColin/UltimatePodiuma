﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class TriggerNextTabl : MonoBehaviour {

	private GameObject cam;
	private FollowingCamera scriptCam;
	public Vector2 tabl;

	void Start(){
		cam = GameObject.Find ("Main Camera");
		try{
			scriptCam = cam.GetComponent<FollowingCamera> ();
		}catch(Exception e){
			Debug.Log ("la camera a besoin d'un script followingCamera");
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		scriptCam.blockGen ();								//on génère un bloqueur d'où on vient
		scriptCam.nextTablView ((int)tabl.x, (int)tabl.y);	//on déplace la caméra sur le nouveau tableau
		gameObject.SetActive (false);
	}
}
