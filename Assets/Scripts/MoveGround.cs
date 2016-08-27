using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveGround : MonoBehaviour
{
	public List<Material> grounds;

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

		foreach(Material ground in grounds){
			ground.SetTextureOffset("_MainTex", offset_x);
		}

	}

}
