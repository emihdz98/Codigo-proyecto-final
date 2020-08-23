//Nombre del desarrollador: Emiliano Hernandez Ortiz
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
/*
Este script se utilizara para delimitar el área que en la que el enemigo perseguirá al jugador.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_hotzone : MonoBehaviour
{
    //+++Declaración de variables+++
    private Patrol_behaviour parent;
    private bool inRange;
    private Animator anim;
    //++++++++++++++++++++++++++++++

    private void Awake()
    {
        //Se obtienen los componentes necesarios.
        parent = GetComponentInParent<Patrol_behaviour>();
        anim = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if(inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Skelleton_Attack")) //Si el enemigo no está atacando pero el jugador está en su rango, se inicia el proceso Flip.
        {
            parent.Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //Si el jugador está dentro del área trigger, estará en el rango del enemigo
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //Si el jugador sale del área se desactiva este trigger y se activa otro.
        {
            inRange = false;
            gameObject.SetActive(false);
            parent.triggerArea.SetActive(true);
            parent.inRange = false;
            parent.SelectTarget();
        }
    }
}
