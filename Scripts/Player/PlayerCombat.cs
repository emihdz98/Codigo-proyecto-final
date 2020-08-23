//Nombre del desarrollador: Emiliano Hernandez Ortiz
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
/*
Este script se utilizara para generar la mecánica de combate del avatar jugador
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //+++Declaración de variables+++
    private Animator anim;
    [SerializeField] Transform aP;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] int damageA;
    [SerializeField] float attackRateA = 1.5f;
    private float nextAttack = 0f;
    //++++++++++++++++++++++++++++++

    private void Start()
    {
        anim = GetComponent<Animator>(); //Se obtiene el componente Animator.
    }
    void Update()
    {
        if (Time.time >= nextAttack) //Si el tiempo actual es mayor al del tiempo establecido entre ataques...
        {
            if (Input.GetKeyDown(KeyCode.X)) //...y se presiona la tecla X...
            {
                AttackA(); //...inicia el proceso de ataque...
                nextAttack = Time.time + 1f / attackRateA; //...y establece el tiempo de espera entre ataques.
            }

        }

    }

    void AttackA()
    {
        //Se reproduce la animación de ataque.
        anim.SetTrigger("attackA");
        //Se detectan los enemigos en el rango de ataque.
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(aP.position, attackRange, enemyLayer);
        //Se aplica daño a los enemigos.
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy_health>().Damage(damageA);
        }
    }


    private void OnDrawGizmosSelected() //Este proceso dibuja una esfera que indica el rango del ataque en la ventana de escena en Unity.
    {
        if(aP == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(aP.position, attackRange);
    }
}
