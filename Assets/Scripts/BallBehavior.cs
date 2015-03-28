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
		if (this.gameObject.transform.position.y > (startHeight + .01)) {
			this.gameObject.transform.position = new Vector3 (
			this.gameObject.transform.position.x,
			Mathf.Clamp (this.gameObject.transform.position.y, -5.0f, startHeight),
			this.gameObject.transform.position.z
			);
		}
	}
	void OnCollisionEnter(Collision coll ) {
		float volume = coll.relativeVelocity.magnitude / 100;
		collidingBallBehavior = coll.collider.gameObject.GetComponent<BallBehavior> ();
		if (collidingBallBehavior != null) {
			bool isBall = coll.collider.gameObject.GetComponent<BallBehavior> ().isBall;
		
			if (isBall)
				AudioSource.PlayClipAtPoint (clack, transform.position, volume);
		}
		Debug.Log (volume);
	}

}
