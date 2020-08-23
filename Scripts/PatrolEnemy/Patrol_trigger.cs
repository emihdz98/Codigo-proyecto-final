//Nombre del desarrollador: Emiliano Hernandez Ortiz
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
/*
Este script se utilizara para establecer el rango en que el enemigo puede detectar al jugador.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_trigger : MonoBehaviour
{
    //+++Declaración de variables+++
    private Patrol_behaviour parent;
    //++++++++++++++++++++++++++++++

    private void Awake()
    {
        parent = GetComponentInParent<Patrol_behaviour>(); //Se obtiene el script del objeto padre.
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player")) //Si el jugador entra en el trigger, este se desactiva y se activa otro trigger.
        {
            gameObject.SetActive(false);
            parent.target = collider.transform;
            parent.inRange = true;
            parent.hotZone.SetActive(true);
        }
    }
}
