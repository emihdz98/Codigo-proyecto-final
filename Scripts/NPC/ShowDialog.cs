//Nombre del desarrollador: Emiliano Hernandez Ortiz
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
/*
Este script se utilizara para que al acercarse a un NPC aparezca un cuadro de diálogo.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDialog : MonoBehaviour
{
    //+++Declaración de variables+++
    [SerializeField] Image dialog;
    [SerializeField] Text text;
    //++++++++++++++++++++++++++++++

    private void Start()
    {
        //Deshabilita todos los cuadros de dialogo en el UI.
        dialog.enabled = false;
        text.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //Si el jugador entra en la zona de trigger...
        {
            //..se habilita el cuadro de diálogo.
            dialog.enabled = true; 
            text.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //Si el jugador sale de la zona de trigger...
        {
            //..todos los cuadros de dialogo se deshabilitan.
            dialog.enabled = false;
            text.enabled = false;
        }
    }
}
