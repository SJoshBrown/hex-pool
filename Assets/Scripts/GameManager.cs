using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public int Shots;
	private bool cueBall;
	private bool eightBall;
	private int ballCount;
	public Text shotsText;
	// Use this for initialization
	void Start () {
		cueBall = true;
		eightBall = true;
		ballCount = 14;
	}
	
	// Update is called once per frame
	void Update () {
		shotsText.text = "Shots: " + Shots;
	}

	void KillPlayer(){
	}

	public void EightBall(){
		Debug.Log ("eightball down");
		eightBall = false;
	}

	public void CueBall(){
		Debug.Log ("cueball down");
		GameOver ();
		cueBall = false;
	}
	public void BallDown(){
		Debug.Log ("ball down");
		ballCount--;
	}

	public void CheckState() {
		Debug.Log ("check");
		if (!(cueBall)) {
			GameOver ();
		} else if (!(eightBall) && (ballCount > 0)) {
			GameOver ();
		} else if (!(eightBall) && (ballCount == 0)) {
			Debug.Log ("win");
		}
	}
	void GameOver() {
		Debug.Log ("game over");
	}

	public void TakeShot() {
		Shots++;
		Debug.Log ("shot taken");
	}
}
