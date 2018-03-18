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

	void Start()
	{
		tableau = new Vector3 (tableau[0], tabl[1], 0);
		gameObject.transform.position = posBase + Vector3.Scale (tableau, new Vector3(24,13.5f,0));
	}

	public void nextTablView(int x, int y)			//déplace la caméra vers le prochain tableau
	{
		tableau = new Vector3 (x, y, 0);
		gameObject.transform.position = new Vector3 (12, -6.75f, -2) + Vector3.Scale (tableau, new Vector3(24, 13.5f, 0)) ;
	}

	public void blockGen(){
		GameObject bloc = Instantiate (block, posBase + Vector3.Scale (tableau, new Vector3(24,13.5f,0)), transform.rotation) as GameObject;
	}
		
}
