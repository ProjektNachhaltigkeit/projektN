using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Patch : Interactable {


	//Verschiedene Interaktionsmöglichkeiten mit dem Beet:
	private Button button_Plant;
	private Button button_Water;
	private Button button_Harvest;
	private Button button_Time; //dient nicht zur Interaktion sondern zeigt nur an, dass das Gemüse gerade wächst

	public Vegetable vegetable; //Konkretes Gemüse im Inspektor per Drag&Drop zuweisen
	private Icon icon; //IconScript (für button, s.u.)

	public Vegetable.HarvestStates oldState;

	public void Start(){

		//Benötigte Buttons holen
		button_Plant = GameObject.Find ("UI/HarvestButtons/Button_Plant").GetComponent<Button>();
		button_Water = GameObject.Find ("UI/HarvestButtons/Button_Water").GetComponent<Button>();
		button_Harvest = GameObject.Find ("UI/HarvestButtons/Button_Harvest").GetComponent<Button>();
		button_Time = GameObject.Find ("UI/HarvestButtons/Button_Time").GetComponent<Button>();

		button_Plant.gameObject.SetActive (false);
		button_Water.gameObject.SetActive (false);
		button_Harvest.gameObject.SetActive (false);
		button_Time.gameObject.SetActive (false);

	
		//Close Iventory Button
		/*button_Plant.GetComponent<Button>().onClick.AddListener(()=> {
			Debug.Log("Moin");

			vegetable.PlantSeedling();
			Debug.Log(vegetable.name);

		});*/
	}

	public override void OnTriggerEnter(){
		//Je nach Status wird der jeweilige Button angezeigt und die jeweilige Funktion zugewiesen

		//Debug.Log ("TEST: " + vegetable.name);

		oldState = vegetable.currentState; //Zur Überpüfung für OnTriggerStay
		ButtonsRemoveOldListeners (); //Alte Listeners der Buttons werden entfernt (sonst würden die wieder mitaufgerufen werden beim Klicken)


		switch (vegetable.currentState) {

		case Vegetable.HarvestStates.None: 
			//Es ist nichts angepflanzt -> Button_Plant wird dargstellt

			ActivateButton (button_Plant);
			button_Plant.onClick.AddListener (vegetable.PlantSeedling);

			break;
		case Vegetable.HarvestStates.Seedling: 
			//Sätzling ist eingepflanzt -> Button_Water wird dargestellt

			ActivateButton (button_Water);
			button_Water.onClick.AddListener (vegetable.WaterPlant);
			break;
		case Vegetable.HarvestStates.Growing: 
			//Sätzling wurde gewässert -> Button_Time wird für eine gesetzte Zeit dargestellt

			StartCoroutine(ActivateButtonWithDelay(button_Time));
			icon = button_Time.GetComponent<Icon> (); 
			icon.target = transform; //Target des Buttons wird auf dieses Beetstück gesetzt
			StartCoroutine (WaitUntilFullyGrown (vegetable.timeToGrow)); //Es wird eine gewisse Zeit gewartet, bevor die Plfanze ausgewachsen ist
			break;
		case Vegetable.HarvestStates.FullyGrown: 
			//Pflanze ist ausgewachsen und bereit geernet zu werden -> Button_Harvest wird dargestellt

			ActivateButton (button_Harvest);
			button_Harvest.onClick.AddListener (vegetable.HarvestPlant);
			break;
		}


	}

	public override void OnTriggerStay(){
		//Bleibt der Spieler in der TriggerBox stehen, so wird OnTriggerEnter erneut aufgerufen, wenn sich der currentState geändert hat.
		//Wenn sich der aktuelle Status nicht geändert hat, passiert nichts.

		if (oldState != vegetable.currentState){ 
			this.OnTriggerEnter (); 
		}
	}

	public override void OnTriggerExit(){ 
		//Buttons ausblenden, wenn die TriggerBox verlassen wird
		button_Plant.gameObject.SetActive (false);  
		button_Water.gameObject.SetActive (false); 
		button_Harvest.gameObject.SetActive (false);
		button_Time.gameObject.SetActive(false);
	}


		
	public void ActivateButton(Button button){
		StartCoroutine (ActivateButtonWithDelay (button));
		icon = button.GetComponent<Icon> ();
		icon.target = transform; //Target des Buttons wird auf dieses Beetstück gesetzt
		button.onClick.AddListener (delegate{DeactivateButton(button);});

	}
		


	public void DeactivateButton(Button button){
		button.gameObject.SetActive (false);
	}

	public void ButtonsRemoveOldListeners(){
		button_Plant.onClick.RemoveAllListeners();
		button_Water.onClick.RemoveAllListeners ();
		button_Time.onClick.RemoveAllListeners ();
		button_Harvest.onClick.RemoveAllListeners ();
	}


	IEnumerator WaitUntilFullyGrown(float time){
		yield return new WaitForSeconds (time); //time-Sekunden wird gewartet
		button_Time.gameObject.SetActive (false); //Wartezeit-Icon wird wieder ausgeblendet
		vegetable.GrowFully();
	}

	IEnumerator ActivateButtonWithDelay(Button button){
		//Button wird nicht direkt, sondern mit einer Verzögerung von 1 Sek angezeigt
		yield return new WaitForSeconds (1f);
		button.gameObject.SetActive (true);
	}



}
