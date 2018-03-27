using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {
	[Header("Set Dynamically")]
	public Text scoreGT; 

	// Use this for initialization
	void Start () {
		GameObject scoreGO = GameObject.Find ("ScoreCounter");
		scoreGT = scoreGO.GetComponent<Text>();
		scoreGT.text = "0";  // initialize the score
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos2D = Input.mousePosition; // Gets the pos of the mouse

		mousePos2D.z = -Camera.main.transform.position.z;
		// convert the point from a 2D screen to a 3D Game World
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);

		// Move the basket
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}

	// Gets called when another object
	// collides with the basket
	void OnCollisionEnter(Collision coll){
		GameObject collidedWith = coll.gameObject;  // what object collided

		if (collidedWith.tag == "Apple") {
			Destroy (collidedWith);
		}

		int score = int.Parse (scoreGT.text); // get current score
		score += 100; // add 100 points to the score
		scoreGT.text = score.ToString();

		if (score>HighScore.score){
			HighScore.score = score;

	}
}
}
