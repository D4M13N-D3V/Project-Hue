using UnityEngine;
using System.Collections;

public class placeholderProjectile : MonoBehaviour {

	public string dir;
	// Use this for initialization
	void Start () {
		StartCoroutine (selfDestruct ());
		
		GameObject player = GameObject.Find ("Player");
		dir = player.GetComponent<playercontroller> ().currentDirection;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.Find ("Player");
		if (dir == "Left") {
			transform.position = transform.position + (player.transform.right/4);
		}
		if (dir == "Right") {
			transform.position = transform.position + (-player.transform.right/4);
		}
		if (dir == "Up") {
			transform.position = transform.position + (-player.transform.up/4);
		}
		if (dir == "Down") {
			transform.position = transform.position + (player.transform.up/4);
		}
	}
	IEnumerator selfDestruct(){
		yield return new WaitForSeconds(3);
		Destroy (gameObject);
	}
}
