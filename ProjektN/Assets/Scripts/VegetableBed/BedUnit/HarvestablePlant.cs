using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HarvestablePlant : MonoBehaviour {
	

	public int id;
	public string species; //Pflanzen-Sorte (z.B. Carrot, Apple, ...)
	public string name; //Deutscher Name
	public string type; //Pflanzen-Typ (z.B. Frucht, Gemüse, Baum, Früchtebaum)
	public float timeToGrow; //Zeit, die die Pflanze nach dem Gießen benötigt, um in den nächsten Zustand zu gelangen
	public int energyPoints; //Energie-Punkte, die die geerntete Pflanze gibt, wenn man sie isst
	public GameObject seedModel; //Saat-Asset
	public GameObject seedlingModel; //Setzling-Asset
	public GameObject harvestablePlantModel; //ErntbarePflanze-Asset
	public GameObject plantModel; //Pflanzen-Asset (ohne Ertrag)
	public int cycles; //Anzahl der Zyklen, die eine Pflanze weiterhin Ernte gibt, bevor sie komplett erneutert werden muss. Bei nicht nachwachsenden Pflanzen ist cycles = 0.

	//public Dictionary<int,string> harvestStates; //Enthält die verschiedenen Zustände, die eine Pflanze haben kann

	//Übergangslösung Enum:
	public HarvestStates harvestStates;
	public enum HarvestStates{
		None,
		Seed,
		Seedling,
		HarvestablePlant,
		Plant
	}

	public HarvestStates currentState; //Wachs-Zustand, in dem sich die Pflanze gerade befindet


	public virtual void Start(){

		currentState = HarvestStates.None;

	}

	public void sendCurrentState(){
		Debug.Log ("In: HarvestablePlant - SendCurrentState");
	}

	public void halfTimeToGrow(){
		Debug.Log ("In: HarvestablePlant - halfTimeToGrow");
	}

	public void OnClickSuccessfull() {
		Debug.Log ("Yeah - OnClick successfull!");
		//OnClick Methode muss aber nicht diese Funktion aufrufen, sondern eine Funktion im Script GrowPlant, hier nur zur Testzwecken
	}









	/*
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


*/



}
