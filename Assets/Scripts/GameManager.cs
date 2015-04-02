using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public int Shots;
	private bool cueBall;
	private bool eightBall;
	private int ballCount;
	public Text shotsText;
	public Canvas pauseMenu;
	public Canvas gameUI;
	// Use this for initialization
	void Start () {
		cueBall = true;
		eightBall = true;
		ballCount = 14;
	}
	
	// Update is called once per frame
	void Update () {
		shotsText.text = "Shots: " + Shots;
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Pause();
		}
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

	//Taken from http://unity3d.com/learn/tutorials/modules/beginner/live-training-archive/using-the-ui-tools
	public void Pause()
	{
		pauseMenu.enabled = !pauseMenu.enabled;
		gameUI.enabled = !gameUI.enabled;
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}

	public void TakeShot() {
		Shots++;
		Debug.Log ("shot taken");
	}
}
