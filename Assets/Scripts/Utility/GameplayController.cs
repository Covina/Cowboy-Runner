using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {


	[SerializeField] private GameObject pausePanel;

	[SerializeField] private Button restartGameButton;

	[SerializeField] private Text scoreText, pauseText;

	private int score = 0;



	// Use this for initialization
	void Start () {

		// score distance
		scoreText.text = score + "M";
		StartCoroutine (CountScore());
	}
	
	// increment distance every .6f seconds
	IEnumerator CountScore ()
	{
		
		yield return new WaitForSeconds(0.6f);
		score++;
		scoreText.text = score + "M";

		StartCoroutine (CountScore());
	}


	void OnEnable ()
	{
		// Register as a delegate
		PlayerDied.endGame += PlayerDiedEndTheGame;
	}

	void OnDisable ()
	{
		// Unregister as a delegate
		PlayerDied.endGame -= PlayerDiedEndTheGame;
	}

	// Function to run when player dies
	void PlayerDiedEndTheGame ()
	{

		// check if no score key exists
		if (!PlayerPrefs.HasKey ("Score")) {

			// init score to zero on first run.
			PlayerPrefs.SetInt ("Score", 0);

		} else {

			int highscore = PlayerPrefs.GetInt ("Score");
			if (score > highscore) {
				// Set new high score
				PlayerPrefs.SetInt ("Score", score);
			}

		}

		// display game over text
		pauseText.text = "Game Over";

		// activate and display the pause panel
		pausePanel.SetActive(true);

		// clear listeners
		restartGameButton.onClick.RemoveAllListeners();

		// Add restart game function
		restartGameButton.onClick.AddListener( () => RestartGame() );

		// freeze game
		Time.timeScale = 0f;


	}

	// Restart function
	public void RestartGame ()
	{
		// Unfreeze game
		Time.timeScale = 1f;

		// Reload level
		SceneManager.LoadScene( SceneManager.GetActiveScene().name );

	}


	public void PauseButton ()
	{
		// freeze game
		Time.timeScale = 0f;

		// activate and display the pause panel
		pausePanel.SetActive(true);

		// clear listeners
		restartGameButton.onClick.RemoveAllListeners();

		// Add restart game function
		restartGameButton.onClick.AddListener( () => ResumeGame() );

	}



	public void ResumeGame() 
	{
		// freeze game
		Time.timeScale = 1f;

		// activate and display the pause panel
		pausePanel.SetActive(false);
	}


	public void GoToMenu() 
	{

		// Unfreeze game
		Time.timeScale = 1f;

		// Load the Main Menu
		SceneManager.LoadScene("Main Menu");

	}


}
