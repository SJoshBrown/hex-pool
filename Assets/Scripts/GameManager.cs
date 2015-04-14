using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public int Shots;
	private bool cueBall;
	private bool eightBall;
	private bool win;
	private int ballCount;
	public Text shotsText;
	public Canvas pauseMenu;
	public Canvas gameUI;
	public Canvas gameOverUI;
	public Canvas winUI;
	// Use this for initialization
	void Start () {
		cueBall = true;
		eightBall = true;
		ballCount = 14;
		Time.timeScale = 1.0f;
		win = false;
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
		eightBall = false;
	}

	public void CueBall(){
		GameOver ();
		cueBall = false;
	}
	public void BallDown(){
		ballCount--;
	}

	public void CheckState() {
		if (!cueBall) {
			GameOver ();
		} else if (!(eightBall) && (ballCount > 0)) {
			GameOver ();
		} else if (!(eightBall) && (ballCount == 0)) {
			win = true;
			GameOver ();
		}
	}
	void GameOver() {
		if (!win) {
			gameOverUI.enabled = true;
		} else {
			winUI.enabled = true;
		}
		Time.timeScale = 0.0f;
	}

	//Taken from http://unity3d.com/learn/tutorials/modules/beginner/live-training-archive/using-the-ui-tools
	public void Pause()
	{
		gameUI.enabled = !gameUI.enabled;
		pauseMenu.enabled = !pauseMenu.enabled;
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}

	public void TakeShot() {
		Shots++;
	}

	public void Restart(){
		Application.LoadLevel(Application.loadedLevel);

	}
	
	public void QuitGame(){
		Application.Quit ();
	}
}
