using UnityEngine;
using System.Collections;

public class keepSynced : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = GameObject.Find ("Player").transform.position;
	}
}
