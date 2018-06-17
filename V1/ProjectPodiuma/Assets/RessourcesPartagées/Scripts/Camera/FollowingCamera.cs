using UnityEngine;
using System.Collections;
using System.Net;
using System.Security.Cryptography;


public class FollowingCamera : MonoBehaviour {

	public float XOffset = 24;
	public float yOffset = 13.5f;
	public delegate void passage();
	public Vector3 tableau;
	public GameObject block;
	private Vector3 posBase = new Vector3 (12, -6.75f, -2);

	//quand l'objet devient actif
	void OnEnable(){
		RespawnPlayer.OnDeath += SetView;
		TriggerNextTabl.NextTabl += NextView;
	}
	//quand l'objet devient inactif
	void OnDisable(){
		RespawnPlayer.OnDeath -= SetView;
		TriggerNextTabl.NextTabl -= NextView;
	}

	//Appelé à la première frame de l'objet
	void Start()
	{
		gameObject.transform.position = posBase + Vector3.Scale (tableau, new Vector3(24,13.5f,0));
	}

	//passe au prochain tableau
	public void NextView(int x, int y){
		//blockGen ();
		SetView (x,y);
	}

	//déplace la caméra vers le tableau x;y
	public void SetView(int x, int y)
	{
		tableau = new Vector3 (x, y, 0);
		gameObject.transform.position = new Vector3 (12, -6.75f, -2) + Vector3.Scale (tableau, new Vector3(24, 13.5f, 0)) ;
	}

	//génère un bloc empechant le retour en arrière
	public void blockGen(){
		GameObject bloc = Instantiate (block, posBase + Vector3.Scale (tableau, new Vector3(24,13.5f,0)), transform.rotation) as GameObject;
		bloc.AddComponent<Disappearing> ();
	}

	//indique dans quel tableau se trouve la position donnée
	public static Vector2 TellTab(Vector3 position){
		return new Vector2 ((int)(position.x / 24), (int)(position.y / 13.5f));
	}
}
