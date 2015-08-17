using UnityEngine;
using System.Collections;

public class RainbowDickAnimator : MonoBehaviour {

	public Texture[] frames;
	public int framesPerSecond = 6;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	int index  = Mathf.RoundToInt((Time.time * framesPerSecond) % frames.Length);
		
		GetComponent<Renderer>().material.mainTexture = frames[index];

	}
}
