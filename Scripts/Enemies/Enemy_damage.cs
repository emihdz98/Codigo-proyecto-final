//Nombre del desarrollador: Emiliano Hernandez Ortiz
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
/*
Este script se utilizara para que un trigger en los enemigos aplique daño al jugador.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_damage : MonoBehaviour
{
    //+++Declaración de variables+++
    [SerializeField] int damagePoints;
    private Player_control player;
    //++++++++++++++++++++++++++++++

    private void Start()
    {
        player = FindObjectOfType<Player_control>(); //Se obtiene el script de control del jugador.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //Si el jugador entra en el trigger, se inicia el proceso de recibir daño en su script.
        {
            player.Damage(damagePoints);
        }
    }
}
