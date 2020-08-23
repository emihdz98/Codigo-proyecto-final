//Nombre del desarrollador: Emiliano Hernandez Ortiz
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
/*
Este script se utilizara para mostrar un área oculta por un tilemap en cuanto el jugador
cruce una zona específica.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretArea : MonoBehaviour
{
    //+++Declaración de variables+++
    public GameObject wall;
    //++++++++++++++++++++++++++++++

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //Si el jugador entra en la zona del trigger...
        {
            wall.SetActive(false); //...el tilemap desaparece.
        }
    }
}
