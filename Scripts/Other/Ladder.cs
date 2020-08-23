//Nombre del desarrollador: Emiliano Hernandez Ortiz
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
/*
Este script se utilizara para crear una escalera vertical.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    //+++Declaración de variables+++
    public float speed;
    //++++++++++++++++++++++++++++++

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Si el jugador entra en la zona trigger y presiona alguna tecla de desplzamiento vertical
        //este podrá moverse libremente por dicha zona.
        if (collision.CompareTag("Player") && Input.GetKey(KeyCode.UpArrow))
        {
            collision.GetComponentInParent <Rigidbody2D>().velocity = new Vector2(0, speed);
        }
        else if (collision.CompareTag("Player") && Input.GetKey(KeyCode.DownArrow))
        {
            collision.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        }
    }
}
