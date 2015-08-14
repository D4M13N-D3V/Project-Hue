using UnityEngine;
using System.Collections;

public class placeholderProjectile : MonoBehaviour {

	public string dir;
	public Vector3 vel;
	public float damage = 0;
	// Use this for initialization
	void Start () {
		StartCoroutine (selfDestruct ());
		
		GameObject player = GameObject.Find ("Player");
		dir = player.GetComponent<playercontroller> ().currentDirection;
		if (dir == "Left") {
			vel =  (player.transform.right/4);
		}
		else if (dir == "Right") {
			vel = (-player.transform.right/4);
		}
		else if (dir == "Up") {
			vel = (-player.transform.up/4);
		}
		else if (dir == "Down") {
			vel = (player.transform.up/4);
		}
		else if (dir == "LeftUp") {
			vel = ((player.transform.right+-player.transform.up)/4);
		}
		else if (dir == "RightUp") {
			vel = ((-player.transform.right+-player.transform.up)/4);
		}
		else if (dir == "LeftDown") {
			vel = ((player.transform.right+player.transform.up)/4);
		}
		else if (dir == "RightDown") {
			vel = ((-player.transform.right+player.transform.up)/4);
		}
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.Find ("Player");
		if (dir == "Left") {
			transform.position = transform.position + vel;
		}
		else if (dir == "Right") {
			transform.position = transform.position + vel;
		}
		else if (dir == "Up") {
			transform.position = transform.position + vel;
		}
		else if (dir == "Down") {
			transform.position = transform.position + vel;
		}
		else if (dir == "LeftUp") {
			transform.position = transform.position + vel;
		}
		else if (dir == "RightUp") {
			transform.position = transform.position + vel;
		}
		else if (dir == "LeftDown") {
			transform.position = transform.position + vel;
		}
		else if (dir == "RightDown") {
			transform.position = transform.position + vel;
		}
	}
	IEnumerator selfDestruct(){
		yield return new WaitForSeconds(3);
		Destroy (gameObject);
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Enemy") {
			col.gameObject.GetComponent<enemyHealth>().Damage(damage);
			Destroy (gameObject);
		}
	}
}
