//Nombre del desarrollador: Emiliano Hernandez Ortiz
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
/*
Este script se utilizara para que el jugador reaparezca en el punto de respawn
cuando este caiga en una zona específica.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

	//+++Declaración de variables+++
    [SerializeField] Transform SpawnPoint;
    private Player_control player;
    private CameraFollow cam;
    //++++++++++++++++++++++++++++++

    private void Start()
    {
        //Se obtienen los componentes necesarios
        player = FindObjectOfType<Player_control>();
        cam = FindObjectOfType<CameraFollow>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.CompareTag("Player")) //Si un gameobject etiquetado como jugador colisiona con este objeto...
        {
            col.transform.position = SpawnPoint.position; //...se mueve al jugador al punto de respawn.
            cam.RestartPos(); //...se reinicia la posición de la cámara.
            player.Damage(10); //...se le aplican 10 puntos de daño al jugador.
        }
    }
}
