using UnityEngine;
using System.Collections;

public class MoveGround : MonoBehaviour
{

		public MeshRenderer groundTop;
		public MeshRenderer groundDown;

        private GameController gameController;
		private Vector2 offset_x;
		public float speed;


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

			offset_x += new Vector2 (0.1f * speed, 0) * Time.deltaTime;

            groundTop.material.SetTextureOffset("_MainTex", offset_x);
			groundDown.material.SetTextureOffset("_MainTex", groundTop.material.GetTextureOffset("_MainTex"));

    }
}
