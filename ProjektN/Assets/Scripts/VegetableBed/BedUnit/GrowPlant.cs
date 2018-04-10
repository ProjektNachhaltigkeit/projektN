using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowPlant : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Plant(){
		Debug.Log ("In GrowPlant: Plant");
	}

	public void Water(){
		Debug.Log ("In GrowPlant: Water");
	}

	public void Grow(){
		Debug.Log ("In GrowPlant: Grow");
	}
	public void waitUntilGrown(){
		Debug.Log ("In GrowPlant: waitUntilGrown");
	}

	public void Fertilise(){
		Debug.Log ("In GrowPlant: Fertilise");
	}
}
