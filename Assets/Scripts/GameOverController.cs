using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour
{

		public TextMesh score;
		public TextMesh bestScore;
		public TextMesh shadowScore;
		public TextMesh shadowBestScore;
		public GameObject scoreGameOver;

		// Use this for initialization
		void Start ()
		{
			HideScoreGameOver ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void SetScoreGameOver (int scoreInGame)
		{
				if (scoreInGame > PlayerPrefs.GetInt ("BestScore")) {
						PlayerPrefs.SetInt ("BestScore", scoreInGame);
				}

				score.text = scoreInGame.ToString ();
				shadowScore.text = score.text;

				bestScore.text = PlayerPrefs.GetInt ("BestScore").ToString ();
				shadowBestScore.text = bestScore.text;

				scoreGameOver.SetActive (true);
		}

		public void HideScoreGameOver ()
		{
				scoreGameOver.SetActive (false);
		}
}
