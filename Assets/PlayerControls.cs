using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	public GameObject shapeToSpawn; //which prefab instantiated
	private float timeUntilSpawn=0; //
	
	public GUIStyle style; //style for score GUI
	public GUIStyle style2;//style for you lose GUI

	public int score= 20;//start score will count down
	public bool playerwins = false;
	

	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*player controls arrow keys and space bar*/
		if (Input.GetKey ("up")) 
		{
			transform.Rotate(-100*Time.deltaTime, 0, 0);		
		}
		if (Input.GetKey ("down")) 
		{
			transform.Rotate(100*Time.deltaTime, 0 , 0);
		}
		if (Input.GetKey ("left")) 
		{
			transform.position= transform.position + new Vector3( 0, 0, -50*Time.deltaTime);
		}
		if (Input.GetKey ("right")) 
		{
			transform.position= transform.position + new Vector3(0, 0, 50*Time.deltaTime);
		}

		timeUntilSpawn -=Time.deltaTime;
		if (timeUntilSpawn <0)//prevents constant stream of spheres
		{
			if (Input.GetKey ("space")) 
			{
				GameObject sphere = (GameObject) Instantiate(shapeToSpawn, transform.position, Quaternion.identity);//makes new sphere
				sphere.AddComponent<Rigidbody>();
				((Rigidbody)sphere.GetComponent("Rigidbody")).AddForce (transform.forward*3000);//gives speed and force
				timeUntilSpawn = 1f;
				score -=1;// lowers score from initial value
				Destroy(sphere, 3);
			}
		}
	}
	void OnGUI(){

		if (!playerwins) {
			GUI.Label (new Rect (0, 0, 400, 200), ("Score:" + score), style); //displays score
			if (score<=0){
				GUI.Label (new Rect (0, 0, 400, 200), ("You Lose!!!!"), style2); //tells user they sucks
				Destroy(GameObject.Find("Target Cube"),0);//destroys target
			}
		}
		else{
			GUI.Label (new Rect (0, 0, 400, 200), ("You Win!!!!"), style2);
		}
	}
}
