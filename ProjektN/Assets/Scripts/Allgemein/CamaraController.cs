using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour {


	public Transform target; 
	public Vector3 offset; //Offset, damit wir nicht genau im Player sitzen

	public float playerHeight = 2f; //Höhe des Spielers


	void LateUpdate () { //Same as update, but called right after update
		transform.position = target.position - offset;
		transform.LookAt (target.position + Vector3.up * playerHeight); 
		//Rotates the transform so the forward vector points at /target/'s current position.
		//*Vector3.up * playerHeight weil unser Pivot am unteren Teil des Charackters ist und der Character 3 Units groß ist

	}
}
