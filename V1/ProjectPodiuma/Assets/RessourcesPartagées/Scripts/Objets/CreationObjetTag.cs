using UnityEngine;
using System;

using System.Collections;

public class CreationObjet : MonoBehaviour {
	//Instances du bloc
	public GameObject objet;
	public float px;
	public float py;

	void Start () {
		//GameObject bloc = Resources.Load ("Bloc") as GameObject;
	}

	// Update is called once per frame
	void Update () {

	}

	//Création d'un objet lorsqu'un tag est détecté par la table
	void creation(String info)
	{
		//On split les coordonnées reçues de la table
		string[] regex = info.Split (' ');

		//Positionnement de l'objet
		Vector2 position = new Vector2 (float.Parse(regex [0]),float.Parse(regex [1]));
		//Création de l'objet aux coordonnées
		Instantiate (objet, position, new Quaternion(0,0,0,0));
	}

	//Suppression d'un objet (lorsque un objet est posé puis retiré, celui-ci est supprimé)
	void supression(String info)
	{
		Destroy(objet);
	}
}
