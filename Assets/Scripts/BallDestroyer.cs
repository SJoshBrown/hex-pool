using UnityEngine;
using System.Collections;

public class BallDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision coll ) {
		Debug.Log ("collide");
		Destroy (coll.collider.gameObject);
	}
}
