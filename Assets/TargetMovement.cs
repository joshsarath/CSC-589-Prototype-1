using UnityEngine;
using System.Collections;

public class TargetMovement : MonoBehaviour {
	
	public float xspeed = 0f;
	public float yspeed = 5f;
	public float zspeed = 0f;

	public Material StartColor;
	public Material FirstHitColor;
	public Material SecondHitColor;
	private int hitCount = 0;


	// Use this for initialization
	void Start () {
		renderer.material = StartColor;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + new Vector3 (xspeed*Time.deltaTime, yspeed*Time.deltaTime,zspeed * Time.deltaTime);
	}
 

	void OnTriggerEnter(Collider other){
		if (other.name== "ShootingBall(Clone)") {
			hitCount += 1;
			if (hitCount == 1) {
				renderer.material = FirstHitColor;
				xspeed*=2;
				yspeed*=2;
				zspeed*=2;
				GameObject.Find("Main Camera").GetComponent<PlayerControls>().score +=3;
			}
			if (hitCount == 2) {
				renderer.material = SecondHitColor;
				xspeed*=2;
				yspeed*=2;
				zspeed*=2;
				GameObject.Find("Main Camera").GetComponent<PlayerControls>().score +=6;
			}
			if (hitCount == 3) {
				GameObject.Find("Main Camera").GetComponent<PlayerControls>().score +=9;
				Destroy (GameObject.Find ("Target Cube"));
				GameObject.Find("Main Camera").GetComponent<PlayerControls>().playerwins=true;
			}
		}
	}
}
