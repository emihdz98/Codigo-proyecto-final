//Nombre del desarrollador: Emiliano Hernandez Ortiz
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
/*
Este script se utilizara para el sistema de salud de los enemigos.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_health : MonoBehaviour
{
    //+++Declaración de variables+++
    public float currentHealth;
    [SerializeField] float maxHealth;
    private Animator anim;
    //++++++++++++++++++++++++++++++

    void Awake()
    {
        currentHealth = maxHealth; //Se establece que la salud inicial del personaje es igual a su salud máxima.
        anim = GetComponentInParent<Animator>(); //Se obtiene el componente animator.
    }

    public void Damage(int dmg) //El proceso Damage se inicia desde un script externo (PlayerCombat).
    {
        currentHealth -= dmg; //Se le resta la cantidad de daño a la salud.

        //Animación de daño
        anim.SetTrigger("hit");

        if (currentHealth <= 0) //Si la cantidad de salud llega a 0 se inicia el proceso de muerte del enemigo.
        {
            Die();
        }
    }


    void Die()
    {
        //Desabilitar enemigo
        anim.SetBool("isDead", true); //Esta animación está configurada para que las funciones del enemigo se deshabiliten.
    }
}
