using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour
{

		public Transform mesh;
		public float forceFly;
		private Animator animatorPlayer;
		private float timeToAnimetion;
		private bool inAnim;
		private GameController gameController;


		// Use this for initialization
		void Start ()
		{
				animatorPlayer = mesh.GetComponent<Animator> ();
				gameController = FindObjectOfType (typeof(GameController)) as GameController;
				
		}
	
		// Update is called once per frame
		void Update ()
		{

				if (gameController.GetCurrentState () == GameStates.MAINMENU || 
						gameController.GetCurrentState () == GameStates.RANKING) {

						inAnim = true;
				
				}

				if (Input.GetMouseButtonDown (0) && gameController.GetCurrentState () == GameStates.INGAME) {
						inAnim = true;
                        GetComponent<Rigidbody2D>().velocity = new Vector2 (0, forceFly);
						//rigidbody2D.AddForce (new Vector2 (0, 1) * forceFly);
						SoundController.PlaySound (soundsGame.wing);
				} else if (Input.GetMouseButtonDown (0) && gameController.GetCurrentState () != GameStates.GAMEOVER) {
						gameController.StartGame ();
				}

				animatorPlayer.SetBool ("callFly", inAnim);

				Vector3 positionPlayer = transform.position;

				if (positionPlayer.y > 5.5f) {
						positionPlayer.y = 5.5f;
						transform.position = positionPlayer;
				}

				if (gameController.GetCurrentState () != GameStates.INGAME && gameController.GetCurrentState () != GameStates.GAMEOVER) {
                        GetComponent<Rigidbody2D>().gravityScale = 0;
						mesh.eulerAngles = new Vector3 (0, 0, 2f);
						return;
				} else {
                        GetComponent<Rigidbody2D>().gravityScale = 1;
				}

				if (inAnim) {
						timeToAnimetion += Time.deltaTime;
						if (timeToAnimetion > 0.4f) {
								timeToAnimetion = 0;
								inAnim = false;
						}
				}

				if (gameController.GetCurrentState () == GameStates.INGAME) {
						if (GetComponent<Rigidbody2D>().velocity.y < 0) {
								mesh.eulerAngles -= new Vector3 (0, 0, 2f);
								if (mesh.eulerAngles.z < 330 && mesh.eulerAngles.z > 30) {
										mesh.eulerAngles = new Vector3 (0, 0, 330);
								}
						} else if (GetComponent<Rigidbody2D>().velocity.y > 0) {
								mesh.eulerAngles += new Vector3 (0, 0, 2f);
								if (mesh.eulerAngles.z > 30) {
										mesh.eulerAngles = new Vector3 (0, 0, 30);
								}
						}
				}
		}

		void OnCollisionEnter2D (Collision2D coll)
		{
				if (coll.collider.tag == "Chao") {
						mesh.eulerAngles = new Vector3 (0, 0, -60);
						gameController.CallGameOver ();
				}
		}

		void OnTriggerEnter2D (Collider2D coll)
		{
				if (coll.tag == "Obst") {
						mesh.eulerAngles = new Vector3 (0, 0, -60);
						gameController.CallGameOver ();
				}
		}
}
