//Nombre del desarrollador: Emiliano Hernandez Ortiz
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
/*
Este script se utilizara para que el fondo de la escena tenga el efecto "Parallax",
así como que este aparezca como un "loop" frente a la cámara.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    //+++Declaración de variables+++
    private float length, startPos;
    public GameObject cam;
    public float effect;
    //++++++++++++++++++++++++++++++

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - effect));
        float dist = (cam.transform.position.x * effect);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if(temp > startPos + length)
        {
            startPos += length;
        }
        else if (temp < startPos - length)
        {
            startPos -= length;
        }
    }
}
