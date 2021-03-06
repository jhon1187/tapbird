﻿using UnityEngine;
using System.Collections;

public class ObstBehaviour : MonoBehaviour
{

		public float speed;
		private GameController gameController;
		private bool passed;


		// Use this for initialization
		void Start ()
		{
				gameController = FindObjectOfType (typeof(GameController)) as GameController;

		}

		void OnEnable ()
		{
				passed = false;
		}
	
		// Update is called once per frame
		void Update ()
		{

				if (gameController.GetCurrentState () != GameStates.INGAME) {
						return;
				}

				transform.position += new Vector3 (speed, 0, 0) * Time.deltaTime;

				if (transform.position.x < -10) {
						gameObject.SetActive (false);		
				}

				if (transform.position.x < gameController.player.position.x -1 && !passed) {
						passed = true;	
						gameController.AddScore ();
				}
					
		}
}
