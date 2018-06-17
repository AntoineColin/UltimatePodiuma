using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	private LineRenderer lr;
	public LayerMask ignoredLayers;
	private Vector2 pos;

	// Use this for initialization
	void Start () {
		lr = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		RaycastHit2D hit =  Physics2D.Raycast (transform.position,transform.up,800, ignoredLayers);
		pos = hit.point;
		Debug.Log (hit.collider);
		lr.SetPosition (0,transform.position);
		if(hit.collider == null){
			lr.SetPosition (1, transform.position + transform.up*100);
		}else{
			lr.SetPosition (1,pos);
			if(hit.transform.tag == "Player"){
				hit.collider.gameObject.GetComponent<RespawnPlayer> ().Hurt ();
			}
		}
	}
}
