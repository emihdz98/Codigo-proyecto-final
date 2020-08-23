//Nombre del desarrollador: Emiliano Hernandez Ortiz
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
/*
Este script se utilizara reconocer cuando el jugador está sobre una plataforma.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrounCheck : MonoBehaviour 
{
    //+++Declaración de variables+++
    [SerializeField] LayerMask Ground;
    public bool isGrounded;
    //++++++++++++++++++++++++++++++

	private void OnTriggerStay2D(Collider2D collider)
    {
        isGrounded = collider != null && (((1 << collider.gameObject.layer) & Ground) !=0); //Si el objeto permanece en un collider de la capa "Ground", esta variable es true.
    }
    
    private void OnTriggerExit2D(Collider2D collider)
    {
        isGrounded = false; //Al salir del trigger la variable se vuelve false;
    }
}
