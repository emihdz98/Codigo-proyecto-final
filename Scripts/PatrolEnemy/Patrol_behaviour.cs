//Nombre del desarrollador: Emiliano Hernandez Ortiz
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
/*
Este script se utilizara para generar el comprtamiento de un enemigo para que
este patrulle una zona específica y ataque al jugador si se acerca.
*/

using UnityEngine;

public class Patrol_behaviour : MonoBehaviour
{
    //+++Declaración de variables+++

    //Variables serializadas
    [SerializeField] float attackDistance; //Distancia mínima para atacar
    [SerializeField] float moveSpeed; //Velocidad de movimiento
    [SerializeField] float timer; //Contador de descanso entre ataques
    public Transform leftLimit; //Limite izquierdo de movimiento
    public Transform rightLimit; //Limite derecho de movimiento
    [HideInInspector] public Transform target; //Objetivo que el enemigo seguirá
    [HideInInspector] public bool inRange; //Revisa si el jugador está en el rango de distancia
    public GameObject hotZone;
    public GameObject triggerArea;

    //Variables privadas
    private Animator anim;
    private float distance; //Almacena la distancia entre el enemigo y el jugador
    private bool attackMode;
    private bool cooling; //Revisa si el enemigo ha cumplido con el tiempo de descanso o "cooldown" antes de volver a atacar
    private float inTimer;

    //+++++++++++++++++++++++++++++

    private void Awake()
    {
        SelectTarget();
        inTimer = timer; //Se guarda el valor inical del timer
        anim = GetComponent<Animator>(); //Se obtiene el componente animator.
    }
    void Update()
    {
        if (!attackMode) //Si el enemigo no está en modo de ataque entonces se moverá.
        {
            Move();
        }

        if(!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Skelleton_Attack")) //Si el enemigo no está dentro de su área ni se encuentra atacando el jugador, entonces se buscará un objetivo.
        {
            SelectTarget();
        }


        if (inRange) //Si el jugador está en el rango del enemigo este activara su lógica.
        {
            EnemyLogic();
        }
    }



    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position); //Se obtiene la distancia entre el enemigo y su objetivo.

        if (distance > attackDistance) //Si la distancia es mayor al rango de ataque, el enemigo dejará de atacar.
        {
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false) //Si la distancia es menor o igual al rango de ataque y el ataque enemigo no se está recargando, entonces puede atacar. 
        {
            Attack();
        }

        if (cooling) //Si el ataque enemigo se está recargando, se inicia el proceso de recarga y se deja de atacar.
        {
            Cooldown();
            anim.SetBool("attack", false);
        }
    }

    void Move()
    {
        anim.SetBool("canWalk", true); //Se activa la animación de caminata.

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Skelleton_Attack")) //Si el enemigo no está atacando entonces se moverá a su siguiente objetivo.
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = inTimer; //Reinicia el timer cuando el jugador entra en el rango de ataque
        attackMode = true; //Verifica si el enemigo puede atacar

        anim.SetBool("canWalk", false); //Desactiva la animación de caminata y activa la animación de ataque.
        anim.SetBool("attack", true);
    }

    void Cooldown()
    {
        timer -= Time.deltaTime; //El timer empieza a disminuir
        if(timer <= 0 && cooling && attackMode) //Si el timer llega a 0 y el enemigo está en modo ataque...
        {
            cooling = false; //...se desactiva el proceso de recarga.
            timer = inTimer; //...el timer se reinicia.
        }
    }

    void StopAttack() //Desactiva las variables relacionadas al ataque del enemigo.
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("attack", false);
    }



    public void TriggerCooling() //Este proceso se activa mediante un frame de la animación de ataque.
    {
        cooling = true;
    }

    private bool InsideofLimits() //Este proceso verifica que el enemigo se encuentra dentro de su área.
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    public void SelectTarget() //Este proceso selecciona el siguiente objetivo a seguir por el enemigo.
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        if (distanceToLeft > distanceToRight)
        {
            target = leftLimit;
        }
        else
        {
            target = rightLimit;
        }

        Flip();
    }

    public void Flip() //Este proceso hace que el enemigo se voltee en dirección hacia donde está avanzando.
    {
        Vector3 rotation = transform.eulerAngles;
        if(transform.position.x > target.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }

        transform.eulerAngles = rotation;
    }
}
