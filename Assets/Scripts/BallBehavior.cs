using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {
	private BallBehavior collidingBallBehavior;
	public AudioClip clack;
	
	[HideInInspector]
	public bool isBall;

	private float startHeight;
	// Use this for initialization
	void Awake () {
		startHeight = this.gameObject.transform.position.y;
		isBall = true;
	}
	
	// Update is called once per frame
	void Update () {
		//Clamp balls in the y direction to prevent them flying off the table
		if (this.gameObject.transform.position.y > (startHeight)) {
			this.gameObject.transform.position = new Vector3 (
			this.gameObject.transform.position.x,
			Mathf.Clamp (this.gameObject.transform.position.y, -5.0f, startHeight),
			this.gameObject.transform.position.z
			);
		}
	}

	//Call sound based on impact velocity
	void OnCollisionEnter(Collision coll ) {

		collidingBallBehavior = coll.collider.gameObject.GetComponent<BallBehavior> ();
		if (collidingBallBehavior != null) {
			bool isBall = coll.collider.gameObject.GetComponent<BallBehavior> ().isBall;
		
			if (isBall){
				float volume = coll.relativeVelocity.magnitude / 100;
				AudioSource.PlayClipAtPoint (clack, transform.position, volume);
			}
		}
	}

}
