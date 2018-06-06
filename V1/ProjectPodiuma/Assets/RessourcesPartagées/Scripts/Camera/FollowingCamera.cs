using UnityEngine;
using System.Collections;
using System.Net;
using System.Security.Cryptography;


public class FollowingCamera : MonoBehaviour {

	public float XOffset = 24;
	public float yOffset = 13.5f;
	public delegate void passage();
	public int[] tabl = new int[2];
	private Vector3 tableau;
	public GameObject block;
	private Vector3 posBase = new Vector3 (12, -6.75f, -2);



	void OnEnable(){
		RespawnPlayer.OnDeath += SetView;
		TriggerNextTabl.NextTabl += NextView;
	}
	void OnDisable(){
		RespawnPlayer.OnDeath -= SetView;
		TriggerNextTabl.NextTabl -= NextView;
	}

	void Start()
	{
		tableau = new Vector3 (tableau[0], tabl[1], 0);
		gameObject.transform.position = posBase + Vector3.Scale (tableau, new Vector3(24,13.5f,0));
	}

	public void NextView(int x, int y){
		blockGen ();
		SetView (x,y);
		Debug.Log ("nextview");
	}

	public void SetView(int x, int y)			//déplace la caméra vers le prochain tableau
	{
		Debug.Log ("SetView : " + x + y);
		tableau = new Vector3 (x, y, 0);
		gameObject.transform.position = new Vector3 (12, -6.75f, -2) + Vector3.Scale (tableau, new Vector3(24, 13.5f, 0)) ;
	}

	public void blockGen(){
		GameObject bloc = Instantiate (block, posBase + Vector3.Scale (tableau, new Vector3(24,13.5f,0)), transform.rotation) as GameObject;
		bloc.AddComponent<Disappearing> ();
	}

	public static Vector2 TellTab(Vector3 position){
		return new Vector2 ((int)(position.x / 24), (int)(position.y / 13.5f));
	}
}
