﻿using UnityEngine;
using System.Collections;

public class MoveBG : MonoBehaviour
{

		private Material currentMaterial;
		private GameController gameController;
		private float offset;
		public float speed;


		// Use this for initialization
		void Start ()
		{
				gameController = FindObjectOfType (typeof(GameController)) as GameController;
				currentMaterial = GetComponent<Renderer>().material;

		}
	
		// Update is called once per frame
		void Update ()
		{

		if (gameController.GetCurrentState () != GameStates.INGAME && 
		    gameController.GetCurrentState () != GameStates.MAINMENU &&
		    gameController.GetCurrentState () != GameStates.RANKING) {
						return;
				}

			offset += 0.001f;

			currentMaterial.SetTextureOffset("_MainTex", new Vector2 (offset * speed, 0));

		}
}
