using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class changementScore : MonoBehaviour {

	public static int score;
	Text txt;

	void Start () {

		score = 0;
		txt = GetComponent<Text> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
		txt.text = "Score = " + score;
	}
}
