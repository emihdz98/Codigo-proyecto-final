//Nombre del desarrollador: Emiliano Hernandez Ortiz
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
/*
Este script se utilizara para que el jugador recoja y almacene las llaves.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    //+++Declaración de variables
    private Player_control player;
    //+++++++++++++++++++++++++++

    private void Awake()
    {
        player = FindObjectOfType<Player_control>(); //Se busca el script de control del jugador.
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //Si un objeto etiquetado como Player entra en este trigger...
        {
            player.PickUpKey(); //...inicia el proceso PickUpKey en el script del jugador.
            Destroy(this.gameObject); //... destruye este objeto.
        }
    }
}
