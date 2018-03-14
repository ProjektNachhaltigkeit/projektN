using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Vegetable {

	// Use this for initialization
	public override void Start () {
		base.Start ();
		Debug.Log ("Carrot Start");
		typeOfVegetable = "Carrot";
		timeToGrow = 5;
	}



	public override void PlantSeedling(){
		base.PlantSeedling ();
	}

	public override void WaterPlant(){
		base.WaterPlant ();
	}

	public override void GrowFully(){
		base.GrowFully ();

	}

	public override void HarvestPlant(){
		base.HarvestPlant();
	}

}