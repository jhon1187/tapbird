using UnityEngine;
using System.Collections;

public class MoveChao : MonoBehaviour
{
		public float speed;
		private GameController gameController;


		// Use this for initialization
		void Start ()
		{
				gameController = FindObjectOfType (typeof(GameController)) as GameController;

		}
	
		// Update is called once per frame
		void Update ()
		{

				if (gameController.GetCurrentState () != GameStates.INGAME && 
						gameController.GetCurrentState () != GameStates.MAINMENU &&
						gameController.GetCurrentState () != GameStates.RANKING) {
						return;
				}

		        transform.position -= new Vector3 (0.1f * speed, 0, 0) * Time.deltaTime;
		
				if (transform.position.x <= -18) {
					Vector3 temp = transform.position;
					temp.x = 18 + (transform.position.x + 18);
					transform.position = temp;
				}
		}

}
