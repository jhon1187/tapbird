using UnityEngine;
using System.Collections;

public enum GameStates
{
		START,
		WAITGAME,
		MAINMENU,
		INGAME,
		GAMEOVER,
		RANKING
}

public class GameController : MonoBehaviour
{

		public Transform player;
		private Vector3 startPositionPlayer;
		private GameStates currentState = GameStates.START;
		public TextMesh numberScore;
		public TextMesh shadowScore;
		private int score;
		public float timeToRestart;
		private float currentTimeToRestart;
		private bool canPlay;
		public GameObject mainMenu;
		public GameObject fadeObject;
		private GameOverController gameOverController;



		// Use this for initialization
		void Start ()
		{
				startPositionPlayer = player.position;
				gameOverController = FindObjectOfType (typeof(GameOverController)) as GameOverController;
		}
	
		// Update is called once per frame
		void Update ()
		{
				switch (currentState) {
				case GameStates.START:
						{
								player.position = startPositionPlayer;
								currentState = GameStates.MAINMENU;
								mainMenu.SetActive (true);
								
						}
						break;
				case GameStates.MAINMENU:
						{
								player.position = startPositionPlayer;

								numberScore.GetComponent<Renderer>().enabled = false;
								shadowScore.GetComponent<Renderer>().enabled = false;
								
								mainMenu.SetActive (true);

								canPlay = true;
						}
						break;
				case GameStates.WAITGAME:
						{
								player.position = startPositionPlayer;
			
						}
						break;
				case GameStates.INGAME:
						{
								numberScore.text = score.ToString ();
								shadowScore.text = score.ToString ();
								mainMenu.SetActive (false);

						}
						break;
				case GameStates.GAMEOVER:
						{
								currentTimeToRestart += Time.deltaTime;
								if (currentTimeToRestart > timeToRestart) {
										currentTimeToRestart = 0;
										currentState = GameStates.RANKING;
										gameOverController.SetScoreGameOver (score);

										ResetGame ();
										
										canPlay = false;
								}


						}
						break;
				case GameStates.RANKING:
						{
								//player.renderer.enabled = false;
								numberScore.GetComponent<Renderer>().enabled = false;
								shadowScore.GetComponent<Renderer>().enabled = false;
						}
						break;
				}
		}

		public void StartGame ()
		{
				currentState = GameStates.INGAME;
				numberScore.GetComponent<Renderer>().enabled = true;
				shadowScore.GetComponent<Renderer>().enabled = true;
				score = 0;

				gameOverController.HideScoreGameOver ();
		}

		public void CallGameOver ()
		{
				if (currentState != GameStates.GAMEOVER) {
						SoundController.PlaySound (soundsGame.hit);
						showFade ();
				}
				
				currentState = GameStates.GAMEOVER;
		}

		public GameStates GetCurrentState ()
		{
				return currentState;
		}

		public void ResetGame ()
		{
				player.position = startPositionPlayer;

				ObstBehaviour[] obsts = FindObjectsOfType (typeof(ObstBehaviour)) as ObstBehaviour[];

				for (int i = 0, size = obsts.Length; i < size; i++) {
					obsts[i].gameObject.SetActive (false);
				}

				hideFade ();
		}

		public void AddScore ()
		{
				score++;
				SoundController.PlaySound (soundsGame.point);
		}

		public void showFade ()
		{
				//fadeObject.SetActive (true);
				fadeObject.GetComponent<Animator> ().SetBool ("StartFade", true);
		}

		public void hideFade ()
		{
				//if(fadeObject.activeSelf){
					fadeObject.GetComponent<Animator> ().SetBool ("StartFade", false);
				//}
				//fadeObject.SetActive (false);
		}

		public bool CanPlay ()
		{
				return canPlay;
		}

}
