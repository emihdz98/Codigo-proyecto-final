//Nombre del desarrollador: Emiliano Hernandez
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
//Este script se utilizara para generar el movimiento vertical en loop de los murcielagos.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatYIA : MonoBehaviour {

	//+++Declaración de variables+++
	[SerializeField] Transform[] bat; //ID del Array.

	[SerializeField] Vector3[] InitialPos;

	public float speed;
	public float dist;
	//++++++++++++++++++++++++++++++

	void Start () {
		
		//Se toma la posicion inicial de cada elemento del Array.
		InitialPos = new Vector3[bat.Length];

		//Se usa el bucle for para realizar el mismo proceso en cada elemento.
		for (int i = 0; i < bat.Length; i++)
		{
			InitialPos[i] = bat[i].position;
		}
	}
	
	
	void Update () {

		Vector3 senoPos = new Vector3(0, Mathf.Sin(Time.time * speed) * dist, 0); //La funcion matematica seno otorga el movimiento oscilatorio a los murciélagos.
		
		for (int i = 0; i < bat.Length; i++)
		{
			bat[i].position = InitialPos[i] + senoPos;
		}
	}
}
