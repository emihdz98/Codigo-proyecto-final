//Nombre del desarrollador: Emiliano Hernandez Ortiz
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
/*
Este script se utilizara para generar el comprtamiento de un enemigo siga al jugador en cuanto este se acerque.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Behaviour : MonoBehaviour
{
    //+++Declaración de variables+++
    private Transform target;
    [SerializeField] float FollowDist;
    [SerializeField] float speed;
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
        float dist = Vector3.Distance(transform.position, target.position); //Se establece una variable que represente la distancia entre el enemigo y el jugador.

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

        if (dist <= FollowDist) //Si el jugador se acerca lo suficiente, el enemigo se moverá hacia él y activará su animación de movimiento.
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            anim.SetBool("isMoving", true);
        }

        else
        {
            anim.SetBool("isMoving", false);
        }
        

    }

}
