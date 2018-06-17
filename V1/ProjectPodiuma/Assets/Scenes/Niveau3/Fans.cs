using UnityEngine;
using System.Collections;

public class Fans : MonoBehaviour {

	public LayerMask forgotten;
	public float force = 7;
	private Transform effector;
	private Vector2 pos, center;

	// Use this for initialization
	void Start () {
		effector = gameObject.transform.GetChild (0);
		Debug.Log (effector);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.up, force, forgotten);
		if(hit.collider == null){
			pos = transform.position + transform.up * force;
		}else{
			pos = hit.point;
		}
		effector.transform.position = (Vector2)((Vector2)transform.position + pos) / 2;
		effector.transform.localScale = new Vector3(effector.transform.localScale.x, Vector2.Distance (transform.position, pos));
		Debug.DrawLine (transform.position, pos);
	}
}
