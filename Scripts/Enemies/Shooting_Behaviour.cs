//Nombre del desarrollador: Emiliano Hernandez
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
//Este script se utilizara para generar el comportamiento de un enemigo que dispare continuamente.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Behaviour : MonoBehaviour {

	//+++Declaración de variables+++
	[SerializeField] Rigidbody2D arrow;
	[SerializeField] Transform bow;
	[SerializeField] float speed;
	private Animator anim;
	private Transform target;
	//++++++++++++++++++++++++++++++

	void Start () 
	{
		//Se obtienen los componentes necesarios.
		anim = GetComponent<Animator>();
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		//Se invoca el metodo que se repetirá cada cierto tiempo.
		InvokeRepeating ("Shoot", 2, 2f); 
	}

    private void Update()
    {
		Vector3 rotation = transform.eulerAngles;
		if (transform.position.x > target.position.x) //El enemigo rotará en dirección al objetivo
		{
			rotation.y = 0f;
		}
		else
		{
			rotation.y = 180f;
		}
	}

    //Se define el metodo que se repetirá.
    void Shoot () {

		anim.SetTrigger("attack");
		
		var proyectilPos = Instantiate(arrow) as Rigidbody2D; //Instanciar crea un GameObj.

		proyectilPos.transform.position = bow.position; //La posición de donde saldrá el proyectil.

		proyectilPos.AddForce(bow.right * -speed); //Se le añade fuerza al disparo.
	}
	private void OnDisable() //Se desabilita cuando el GamoObj no está activo.
	{
		CancelInvoke();
	}
}
