//Nombre del desarrollador: Emiliano Hernandez Ortiz
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
/*
Este script se utilizara para que la cámara siga al jugador.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	//+++Declaración de variables+++
	
	//Variables de seguimiento al jugador.
	[SerializeField] GameObject followObject;
	[SerializeField] Vector2 followOffset;
	[SerializeField] float speed = 3f;

	//Variables de limites de la cámara.
	[SerializeField] float limitLeft;
	[SerializeField] float limitRight;
	[SerializeField] float limitUp;
	[SerializeField] float limitDown;
	public Vector3 startPos;

	//Variables privadas.
	private Vector2 threshold;
	private Rigidbody2D rb;
	//++++++++++++++++++++++++++++++

	void Start () 
	{
		startPos = transform.position; //Se establece la posición inicial de la cámara.
		threshold = CalculateThreshold(); //Se establece el límite que el jugador debe pasar para que la cámara lo siga.
		rb = followObject.GetComponent<Rigidbody2D>(); //Se obtiene el rigidbody el objeto que la cámara seguirá.

	}
	
	
	void FixedUpdate () {

		Vector2 follow = followObject.transform.position; //Se crea un vector que represente la posición del objeto a seguir.
		float xDist = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
		float yDist = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y); //Se establecen las distancias entre el jugador y la cámara.

		Vector3 newPos = transform.position; //Se crea un vector que representará la nueva posición de la cámara.
		if (Mathf.Abs(xDist) >= threshold.x) //Si la distancia entre la cámara y el objetivo en x supera el límite...
        {
			newPos.x = follow.x; //...la nueva posición será igual a la posición del objeto a seguir.
        }
		if (Mathf.Abs(yDist) >= threshold.y) //Y se repite el mismo proceso con la y.
		{
			newPos.y = follow.y;
		}
		//Este proceso hace que la cámara se mueva en dirección al jugador a la velocidad establecida.
		float moveSpeed = rb.velocity.magnitude > speed ? rb.velocity.magnitude : speed;
		transform.position = Vector3.MoveTowards(transform.position, newPos, moveSpeed * Time.deltaTime);
		//Esto evita que la cámara sobrepase los límites establecidos.
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, limitLeft, limitRight), Mathf.Clamp(transform.position.y, limitDown, limitUp), transform.position.z);

	}

	private Vector3 CalculateThreshold() //Este proceso crea un rectangulo que delimita hasta donde se puede mover el jugador sin que la cámara avance.
    {
		Rect aspect = Camera.main.pixelRect;
		Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
		t.x -= followOffset.x;
		t.y -= followOffset.y;
		return t;
    }

	public void RestartPos() //Este proceso devuelve la cámara a su posición inicial y es activado solo cuando el jugador es regresado a esta misma posición.
    {
		transform.position = startPos;
    }
}
