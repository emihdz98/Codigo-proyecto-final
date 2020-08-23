//Nombre del desarrollador: Emiliano Hernandez Ortiz
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
/*
Este script se utilizara para que el jugador pueda recoger y almacenar pociones.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPickUp : MonoBehaviour
{
    //+++Declaración de variables+++
    private Player_control player;
    //++++++++++++++++++++++++++++++

    private void Awake()
    {
        player = FindObjectOfType<Player_control>(); //Se accede al script del control del jugador
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //Si un gameobject etiquetado como "player" entra en el trigger...
        {
            player.PickUpPotion(); //...inicia el proceso llamado PickUpPotion del script de control del jugador.

            Destroy(this.gameObject); //También se destruye el gameobject dueño de este script.
        }
    }
}
