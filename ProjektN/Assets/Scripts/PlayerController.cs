using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //Wichtig!
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {



	bool moving = false;
	bool ended = false;

	void Start(){
		//playerAgent = GetComponent<NavMeshAgent> ();
	}
	void Update(){

		//TOUCH:
		//if (Input.touchCount > 0) {
		//TOUCH:
		//	Touch touch = Input.GetTouch(0);
			
			//PC
		if (Input.GetMouseButtonDown (0)) {			
			//Handle finger movements based on touch phase
			//if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject ()) {

				//PC
				MoveToTouch ();		

				//TOUCH
				/*switch (touch.phase) {
				case TouchPhase.Began:
						MoveToTouch (); //Movement beim Tippen
						break;
					case TouchPhase.Moved:
						moving = true;
						MoveToTouch ();
						break;
					case TouchPhase.Stationary:
						MoveToTouch ();
						break;
					case TouchPhase.Ended:
						ended = true;
						if (moving == true) {
						//wurde der Character mit gedrücktem Finger bewegt und wird dieser
						//losgelassen, soll der Character anhalten:
							EndWalking ();
						}
						break;
				}*/

			}
		//}
	}
	void MoveToTouch(){

		//TOUCH
		//Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch(0).position); //Ray erstellen

		//PC
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); //Ray erstellen

		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 100)) { //Casts a ray, from point origin against all colliders in the scene und speichert den Kollision in "hit"

			GameObject touchedObject = hit.collider.gameObject; //Gibt uns das tatsächliche Object, auf das geklickt wurde

			//Debug.Log (touchedObject.name);
			if (touchedObject.name != "Player") { //TODO noch durch Objekt ersetzten, dient dazu, dass es keine komischen Effekte gibt
				//wenn der Finger auf dem Character ist oder über den Character fährt

				//TOUCH
				//float step = 4f * Time.deltaTime;

				//PC
				float step = 30f * Time.deltaTime;

				transform.position = Vector3.MoveTowards (transform.position, hit.point, step);
				hit.point = new Vector3 (hit.point.x, this.transform.position.y, hit.point.z);
				transform.LookAt (hit.point); 
			}
		}
	
	}


	void EndWalking (){
		//Damit der Charackter wenn der dem gedrückten Finger geführt wurde, nicht noch weiterläuft
		//wenn der Finger losgelassen wurde, wird hier die Bewegung gestoppt, sobald der Finger loslässt
		//ended = false;
		//moving = false;
//		playerAgent.isStopped = true;
//		playerAgent.ResetPath ();
	}
}