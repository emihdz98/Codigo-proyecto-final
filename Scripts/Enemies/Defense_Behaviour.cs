//Nombre del desarrollador: Emiliano Hernandez Ortiz
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
/*
Este script se utilizara para generar el comportamiento de un enemigo inmovil que ataque al jugador si este se acerca.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense_Behaviour : MonoBehaviour
{
    //+++Declaración de variables+++
    private Transform target;
    [SerializeField] float AttackDist;
    private Animator anim;
    //++++++++++++++++++++++++++++++

    void Start()
    {
        //Se obtienen los componentes necesarios.
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, target.position); //Se establece una variable que representa la distancia entre el enemigo y el jugador.

        Vector3 rotation = transform.eulerAngles; //El enemigo rotará en dirección al jugador.
        if (transform.position.x > target.position.x)
        {
            rotation.y = 0f;
        }
        else
        {
            rotation.y = 180f;
        }

        transform.eulerAngles = rotation;

        if (dist <= AttackDist) //Si el jugador se acerca lo suficiente el enemigo atacará.
        {
            anim.SetTrigger("attack");
        }
     
    }

}
