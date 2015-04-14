using UnityEngine;
using System.Collections;

public class BallDestroyer : MonoBehaviour {
	private GameManager gameManager;
	public GameObject gameManagerObject;
	// Use this for initialization
	void Start () {
		gameManager = gameManagerObject.GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Destroy balls and call the according GameManager function
	void OnCollisionEnter(Collision coll ) {
		if (coll.collider.gameObject.tag == "eightBall")
			gameManager.EightBall ();
		else if (coll.collider.gameObject.tag == "cueBall")
			gameManager.CueBall ();
		else
			gameManager.BallDown ();
		Destroy (coll.collider.gameObject);

	}
}
