using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {

	// Prefab for instantiating Apples
	public GameObject applePrefab;

	// AppleTree Speed
	public float speed = 1f;

	// Distance where AppleTree turns around
	public float leftAndRightEdge = 10f;

	// Chance that the apple tree will change direction
	public float chanceToChangeDirections = 0.1f;

	// Rate at which Apples will be instantiated
	public float secondsBetweenAppleDrops = 1f;

	// Use this for initialization
	void Start () {
		Invoke ("DropApple", 2f);
	}

	void DropApple() {
		GameObject apple = Instantiate<GameObject> (applePrefab);
		apple.transform.position = transform.position;
		Invoke ("DropApple", secondsBetweenAppleDrops);
	}
	
	// Update is called once per frame
	void Update () {
		// Basic Movements
		Vector3 pos = transform.position; // get position
		pos.x += speed * Time.deltaTime; // calculate new position
		transform.position = pos; 		// move the tree

		//Changing Direction
		if (pos.x < -leftAndRightEdge) { // if we moved all the way to the left
			speed = Mathf.Abs (speed);	// change direction
			}
		else if (pos.x > leftAndRightEdge){ // if we moved all the way to the right
			speed = -Mathf.Abs (speed);     // change direction
			}
		}

	void FixedUpdate() {
		//changing direction randomly is now time-based because of FixedUpdate()
		if (Random.value < chanceToChangeDirections){
			speed *= -1;    // change direction randomly
		}
}
}
