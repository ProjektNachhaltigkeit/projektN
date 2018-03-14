using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Vegetable : MonoBehaviour {
	

	public GameObject seedling;
	public GameObject fullyGrown;

	private VegetableBed vegetableBed;
	private Patch patch;
	public HarvestStates currentState; //verschiedene Zustände des Gemüses s.u.

	public float timeToGrow; //Zeit, die die Pflanze benötigt, vom Gießen bis zum Ausgewachsen-Sein
	public string typeOfVegetable;

	//Verschiedene Zustände des Gemüses:
	public enum HarvestStates{
		None,
		Seedling,
		Growing,
		FullyGrown,
	}

	public virtual void Start(){

		//Pflanzen zunächst ausblenen
		seedling.SetActive (false); //Sätzling 
		fullyGrown.SetActive (false); //ausgewachsende Pflanze 

		if (timeToGrow == 0) { //Wenn timeToGrow nicht im Inspector festgelegt wird
			timeToGrow = 10f;
		}

		patch = transform.parent.GetComponent<Patch> ();
		vegetableBed = transform.parent.GetComponentInParent<VegetableBed> (); //TODO

		currentState = HarvestStates.None; 

	}


	public virtual void PlantSeedling(){
		Debug.Log ("Plant seedling from " + typeOfVegetable);
		seedling.SetActive (true); //Sätzling wird dargestellt
		currentState = HarvestStates.Seedling; //akt. Status aktualiesiert
	}

	public virtual void WaterPlant(){
		Debug.Log ("Water seedling from " + typeOfVegetable);

		currentState = HarvestStates.Growing;
	}

	public virtual void GrowFully(){
		Debug.Log ("GrowFully from " + typeOfVegetable);

		seedling.SetActive (false);
		fullyGrown.SetActive (true); //ausgewachsende Pflanze wird dargestellt
		currentState = HarvestStates.FullyGrown;

	}

	public virtual void HarvestPlant(){
		Debug.Log ("Harvest plant from " + typeOfVegetable);

		//Pflanze wird geerntet und Beet ist wieder unbepflanzt:
		seedling.SetActive (false); 
		fullyGrown.SetActive (false);
		currentState = HarvestStates.None; 

		vegetableBed = transform.parent.GetComponent<VegetableBed> ();
		//vegetableBed = transform.parent.GetComponent <VegetableBed> ();
		//vegetableBed.amountHarvested++;
		//Debug.Log ("AmountHarvested: " + vegetableBed.amountHarvested);
	}






}
