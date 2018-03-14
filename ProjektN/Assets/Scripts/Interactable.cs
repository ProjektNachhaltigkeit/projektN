using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 
using UnityEngine.UI;



public class Interactable : MonoBehaviour {


	public Text textausgabe; //Textausgabe, zeigt den Namen des Objektes an, dessen Triggerbox wir betreten

	//Buttons:
	//Erscheinen über einem Objekt, mit dem interagiert werden kann 


	public virtual void OnTriggerEnter(){
		Debug.Log ("OnTriggerEnter base class");
		//Methode wird in Unterklasse überschrieben
	}

	public virtual void OnTriggerStay(){
		Debug.Log ("OnTriggerStay base class");
		//Methode wird in Unterklasse überschrieben
	}

	public virtual void OnTriggerExit(){
		Debug.Log ("OnTriggerExit base class");
		//Methode wird in Unterklasse überschrieben
	}

	public virtual void Interact(){
		Debug.Log ("Interaktion mit base class");
		//Methode wird in Unterklasse überschrieben
	}
		


}
