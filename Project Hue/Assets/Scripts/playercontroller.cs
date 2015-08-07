using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour {

	public string currentDirection = "Forward";
	public float colorPercent = 100.00F;
	public int health;
	public int speed;


	public Transform camera;
	//PLACE HOLDER VARIABLES
	
	public bool usePlaceHolders = true;
	
	public Texture frontStill;
	public Texture backStill;
	public Texture leftStill;
	public Texture rightStill;

	public Renderer renderer;
	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {


		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
			if(usePlaceHolders){
				renderer.material.mainTexture=leftStill;
				transform.position += (Vector3.left*speed) * Time.deltaTime;
			}
		}

		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
			if(usePlaceHolders){
				renderer.material.mainTexture=rightStill;
				transform.position += (-Vector3.left*speed) * Time.deltaTime;
			}
		}

		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
			if(usePlaceHolders){
				renderer.material.mainTexture=backStill;
				transform.position += (-Vector3.back*speed) * Time.deltaTime;
			}
		}

		if( Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
			if(usePlaceHolders){
				renderer.material.mainTexture=frontStill;
				transform.position += (Vector3.back*speed) * Time.deltaTime;
			}
		}



	}




}
