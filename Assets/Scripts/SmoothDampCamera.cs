using UnityEngine;
using System.Collections;

public class SmoothDampCamera : MonoBehaviour
{

		public Transform personagem;
		public float valorSuavizacao;
		private Vector2 velocidade;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{

				Vector3 temp = transform.position;
				//temp.x = Mathf.SmoothDamp(transform.position.x, personagem.position.x, ref velocidade.x, valorSuavizacao);
				temp.y = Mathf.SmoothDamp (transform.position.y, personagem.position.y, ref velocidade.y, valorSuavizacao);

				if (temp.y > 0.5f) {
						temp.y = 0.5f;
				} else if (temp.y < -0.5f) {
						temp.y = -0.5f;
				}

				transform.position = temp;

		}
}
