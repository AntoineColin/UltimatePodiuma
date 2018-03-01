using UnityEngine;
using System.Collections;
using System.Net;
using System.Security.Cryptography;

public class FollowingCamera : MonoBehaviour {

	public float XOffset = 24;
	public float yOffset = 13.5f;
	public delegate void passage();
	public Vector3 tableau;

	void Start()
	{
		gameObject.transform.position = new Vector3 (6.75f, 12, -2) + Vector3.Scale (tableau, new Vector3(24)) ;

	}

	public void nextTablView(int x, int y)			//déplace la caméra vers le prochain tableau
	{
		tableau = new Vector3 (x, y, 0);
		gameObject.transform.position = new Vector3 (6.75f, 12, -2) + Vector3.Scale (tableau, new Vector3(24)) ;
	}

}
