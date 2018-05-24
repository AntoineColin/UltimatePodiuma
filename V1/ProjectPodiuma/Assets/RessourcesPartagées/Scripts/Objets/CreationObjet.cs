using UnityEngine;
using System;

using System.Collections;

public class CreationObjet : MonoBehaviour {
	//Instances du bloc
	public GameObject objet1, objet2, objet3;
	private float px;
	private float py;
	private GameObject cam;

	private GameObject cubeTAG1, cubeTAG2, cubeTAG3;

	void Start(){
		cubeTAG1 = Instantiate (objet1, new Vector3(0,0,0), new Quaternion (0, 0, 0, 0)) as GameObject;
		cubeTAG2 = Instantiate (objet2, new Vector3(-2,0,0), new Quaternion (0, 0, 0, 0)) as GameObject;
		cubeTAG3 = Instantiate (objet3, new Vector3(-2,0,0), new Quaternion (0, 0, 0, 0)) as GameObject;
		cam = GameObject.Find ("Main Camera");
	}

	//Création d'un objet lorsqu'un tag est détecté par la table
	void creation(String info)
	{
		//On split les coordonnées reçues de la table
		string[] regex = info.Split (' ');

		//Positionnement de l'objet
		Vector3 position = new Vector3 (float.Parse(regex [0]),float.Parse(regex [1]),0);
		float angle = -(float)(double.Parse (regex [2]));
		position = cam.transform.position - new Vector3 (12, -6.75f, -2) + position;

		//Création de l'objet aux coordonnées
		if (regex.Length == 3) {
			cubeTAG1.transform.position = position;
		}else if(regex.Length == 4){
			if (Int16.Parse (regex [3]) == 1) {
				cubeTAG1.transform.position = position;
				cubeTAG1.transform.eulerAngles = new Vector3(0,0,angle);
			}
			if (Int16.Parse (regex [3]) == 2) {
				cubeTAG2.transform.position = position;
				cubeTAG2.transform.eulerAngles = new Vector3(0,0,angle);
			}
			if (Int16.Parse (regex [3]) == 3){
				cubeTAG3.transform.position = position;
				cubeTAG3.transform.eulerAngles = new Vector3(0,0,angle);
			}
		}
	}


	//Suppression d'un objet (lorsque un objet est posé puis retiré, celui-ci est supprimé)
	void supression(String info)
	{
		Destroy(cubeTAG1);
	}
}
