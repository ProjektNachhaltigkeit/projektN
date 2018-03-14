using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour {

	public Transform  target;
	//public Interactable interactable;

	public Text info; 

	void Update () {
		//Icon wird auf die selbe Posoiton wie das getriggerte Objekt gesetzt
		Vector3 offset = new Vector3(target.position.x, target.position.y+1f, target.position.z);
		Vector3 targetPosition = Camera.main.WorldToScreenPoint (offset);
		//Vector3 targetPosition = Camera.main.WorldToScreenPoint (target.position);
		transform.position = targetPosition;

	}

	/*public void OnClick(){
		//Methode Interact des getriggerten Objektes wird aufgerufen
		info.text = "click";
		interactable.Interact ();
	}*/



}
