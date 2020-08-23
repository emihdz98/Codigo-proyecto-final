//Nombre del desarrollador: Emiliano Hernandez Ortiz
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
/*
Este script se utilizara para la mecánica de la barra de salud del jugador.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //+++Declaración de variables+++
    private Image HealthB;
    public float CurrentH;
    private float MaxH = 100f;
    Player_control player;
    //++++++++++++++++++++++++++++++

    private void Start()
    {
        //Se obtiene el script de control del jugador y la imagen de UI que representa la barra de salud.
        HealthB = GetComponent<Image>();
        player = FindObjectOfType<Player_control>();
    }

    private void Update()
    {
        CurrentH = player.currentHealth; //Se toma la variable del jugador que representa su salud actual.
        HealthB.fillAmount = CurrentH / MaxH; //La imagen aparecerá en un porcentaje directamente proporcional a la salud del jugador.
    }
}
