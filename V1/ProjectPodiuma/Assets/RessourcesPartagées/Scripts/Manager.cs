﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class Manager : MonoBehaviour {

	private PlayerMovement move;

	// Use this for initialization
	void Start () {
		try{
			move = GameObject.Find ("Player").GetComponent <PlayerMovement>();
		}catch(Exception e){}
	}


	//Fonction de déplacement pour la table Surface
	public void MyFunction(string s)
	{
		Debug.Log ("myfunction");
		/******Récupération des données envoyées par la table surface******/
		//Initialisation des données
		string[] coordonnees;
		//Récupération et division des coordonnées
		coordonnees = s.Split (' ');


		//Gérer les input comme des clicks
		List<RaycastResult> hits = new List<RaycastResult>(1);
		PointerEventData ray = new PointerEventData (EventSystem.current);
		//ray.position = new Vector2 (Single.Parse (coordonnees [0]), -Single.Parse (coordonnees [1])-2);
		Debug.Log ("ray position : " + ray.position);


		EventSystem.current.RaycastAll (ray, hits);
		Debug.Log ("rayposition : " + ray.position + " touched : " + hits[0]);
		try{
			foreach(RaycastResult hit in hits){
				hit.gameObject.GetComponent<Button> ().onClick.Invoke ();
			}
		}catch(Exception e){
			Debug.Log ("ce qui est cliqué n'est pas un bouton");
		}
	}

	public void Avancer(String b){
		if (b == "Vrai")
			move.avanceAppuye = true;
		if (b== "Faux")
			move.avanceAppuye = false;
	}

	public void Reculer(String b){
			if (b == "Vrai")
				move.reculeAppuye = true;
			if (b== "Faux")
					move.reculeAppuye = false;
	}

	public void Saute(String b){
		if (b == "Vrai")
			move.sauteAppuye = true;
		if (b== "Faux")
			move.sauteAppuye = false;
	}
}
