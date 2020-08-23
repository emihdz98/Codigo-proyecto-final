//Nombre del desarrollador: Emiliano Hernandez Ortiz
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
/*
Este script se utilizara para que al acercarse a un NPC aparezca un mensaje de
"misión cumplida" y el jugador tenga la opción de repetir el nivel.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{
    //+++Declaración de variables+++
    private Player_control player;
    private int keys;
    [SerializeField] Image dialog;
    [SerializeField] Text textA;
    [SerializeField] Text textB;
    //++++++++++++++++++++++++++++++

    private void Start()
    {
        //Deshabilita todos los cuadros de dialogo en el UI.
        dialog.enabled = false;
        textA.enabled = false;
        textB.enabled = false;
        player = FindObjectOfType<Player_control>(); //Se obtiene el script de control del jugador.
    }

    private void Update()
    {
        keys = player.keyCount; //Toma el número de llaves que el jugador lleva.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //Si el jugador entra en la zona de trigger...
        {
            if (keys == 3) //...dependiendo del número de llaves que tiene se muestra un mensaje diferente.
            {
                dialog.enabled = true;
                textA.enabled = true;
            }
            else
            {
                dialog.enabled = true;
                textB.enabled = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //Si el jugador permanece en la zona de trigger...
        {
            if (keys == 3) //...y tiene las llaves necesarias para terminar el nivel...
            {
                if (Input.GetKeyDown(KeyCode.Return)) //...puede presionar la tecla "Enter" para reiniciarlo.
                {
                    SceneManager.LoadScene("Test1");
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //Si el jugador sale de la zona de trigger...
        {
            dialog.enabled = false; //..todos los cuadros de dialogo se deshabilitan.
            textA.enabled = false;
            textB.enabled = false;
        }
    }
}
