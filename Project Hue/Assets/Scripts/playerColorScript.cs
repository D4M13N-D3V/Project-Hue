using UnityEngine;
using System.Collections;

public class playerColorScript : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Color color = player.GetComponent<Renderer>().material.color;
		color.r = player.GetComponent<playercontroller> ().colorPercent/255;
		color.g = player.GetComponent<playercontroller> ().colorPercent/255;
		color.b = player.GetComponent<playercontroller> ().colorPercent/255;
		


		player.GetComponent<Renderer> ().material.color = color;

	}
}
