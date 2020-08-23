//Nombre del desarrollador: Emiliano Hernandez Ortiz
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
/*
Este script se utilizara para que el UI muestre la cantidad de llaves que el jugador lleva.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyText : MonoBehaviour
{
    //+++Declaración de variables+++
    Text text;
    public static int keyAmount;
    //++++++++++++++++++++++++++++++

    void Start()
    {
        text = GetComponent<Text>(); //Se obtiene el componente texto.
    }

    void Update()
    {
        text.text = keyAmount.ToString(); //El texto que se muestra es igual al número de llaves que el jugador lleva
    }
}
