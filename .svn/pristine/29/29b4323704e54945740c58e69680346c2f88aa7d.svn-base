using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour
{

		public float maxHeight;
		public float minHeight;
		public float rateSpawn;
		private float currentRateSpawn;
		public GameObject obstPrefab;
		public int maxSpawnObst;
		public List<GameObject> obsts;
		private GameController gameController;



		// Use this for initialization
		void Start ()
		{
				for (int i=0; i<maxSpawnObst; i++) {
						GameObject tempObst = Instantiate (obstPrefab, new Vector3(0,0,0), Quaternion.identity) as GameObject;
						obsts.Add (tempObst);
						tempObst.SetActive (false);
				}

				currentRateSpawn = rateSpawn;

				gameController = FindObjectOfType (typeof(GameController)) as GameController;

		}
	
		// Update is called once per frame
		void Update ()
		{

				if (gameController.GetCurrentState () != GameStates.INGAME) {
						return;
				}

				currentRateSpawn += Time.deltaTime;
				if (currentRateSpawn > rateSpawn) {
						currentRateSpawn = 0;
						Spawn ();
				}
		}

		private void Spawn ()
		{
				float randHeight = Random.Range (minHeight, maxHeight);
				GameObject tempObst = null;

				for (int i=0; i<maxSpawnObst; i++) {
						if (obsts [i].activeSelf == false) {
								tempObst = obsts [i];
								break;
						}
				}

				if (tempObst != null) {
						tempObst.transform.position = new Vector3 (transform.position.x, randHeight, transform.position.z);
						tempObst.SetActive (true);
				}
		}
}
