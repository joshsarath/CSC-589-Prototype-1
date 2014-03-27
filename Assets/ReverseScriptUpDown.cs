using UnityEngine;
using System.Collections;

public class ReverseScriptUpDown : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		TargetMovement moveComp = (TargetMovement)other.gameObject.GetComponent ("TargetMovement");
		if (moveComp != null) {
			moveComp.yspeed *= -1;	
		}
	}
}
