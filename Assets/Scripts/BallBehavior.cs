using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {
	private float startHeight;
	// Use this for initialization
	void Awake () {
		startHeight = this.gameObject.transform.position.y;
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
}
