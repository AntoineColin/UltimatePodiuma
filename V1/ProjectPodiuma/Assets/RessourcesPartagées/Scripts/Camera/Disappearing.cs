using UnityEngine;
using System.Collections;

public class Disappearing : MonoBehaviour {

	void OnEnable(){RespawnPlayer.OnDeath += Disappear;}
	void OnDisable(){RespawnPlayer.OnDeath -= Disappear;}


	public void Disappear(int c, int d){
		Destroy (gameObject);
	}
}
