using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class succes : MonoBehaviour {

	public string nextLevelName;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D coll){
		StartCoroutine (Succes ());
		anim.SetTrigger ("succes");

	}

	IEnumerator Succes(){
		yield return new WaitForSeconds (1.5f);
		SceneManager.LoadScene (nextLevelName);
	}
}
