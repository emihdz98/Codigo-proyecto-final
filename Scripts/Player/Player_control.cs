//Nombre del desarrollador: Emiliano Hernandez Ortiz
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
/*
Este script se utilizara para generar el control del avatar jugador
y establecer algunas mecánicas como el sistema de salud y el almacenamiento
de items.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_control : MonoBehaviour
{

	//+++Declaración de variables+++

	//Componentes
	private Animator animator;
	private Rigidbody2D RB2D;

	//valores de fuerza
	[SerializeField] float playerSpeed;
	[SerializeField] float jumpForce;

	//Valores de salud
	public float currentHealth;
	public float maxHealth = 100f;

	//Contador de pociones
	public float potionCount;
	public Image[] potions;

	//Contador de llaves
	public int keyCount;

	//+++++++++++++++++++++++++++++

	void Start()
	{

		//Selección de componentes que utilizaremos del GameObj denominado player
		animator = GetComponent<Animator>();
		RB2D = GetComponent<Rigidbody2D>();

		//La salud inicial del jugador es igual a la su salud máxima.
		currentHealth = maxHealth;

		//Al iniciar, la cantidad de llaves acumuladas es 0.
		keyCount = 0;

	}

	private void Update()

    {

		#region jump
		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) //Si el jugador presiona la tecla "Space" y la variable "isGrounded" es verdadera...
		{
			RB2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //...el jugador obtiene un impulso vertical hacia arriba a modo de salto.
			animator.SetTrigger("jump"); //...se reproduce la animación de salto.
		}
		if (IsGrounded()) //Si el jugador aún no toca el suelo se reproducirá la animación de caida hasta que este aterrice.
			animator.SetBool("jumping", false);
		else
			animator.SetBool("jumping", true);
		#endregion

		#region walk

		if (Input.GetKey(KeyCode.RightArrow)) //Si el jugador preciona la tecla direccional derecha...
		{
			transform.localScale = new Vector2(1, transform.localScale.y);
			transform.localScale = new Vector2(1, transform.localScale.x); //...el objeto se escala en valores positivos para que parezca que está mirando a la derecha.
			RB2D.velocity = new Vector2(playerSpeed, RB2D.velocity.y); //...el jugador se desplaza a la derecha.
			if(IsGrounded())
				animator.SetBool("walk", true); //...y si el jugador se encuentra sobre el suelo, se reproduce la nimcación de caminar.
		}
		else if (Input.GetKey(KeyCode.LeftArrow)) //Si el jugador preciona la tecla direccional izquierda...
		{
			transform.localScale = new Vector2(1, transform.localScale.y);
			transform.localScale = new Vector2(-1, transform.localScale.x); //...el objeto se escala en valores negativos para que parezca que está mirando a la izquierda.
			RB2D.velocity = new Vector2(-playerSpeed, RB2D.velocity.y); //...el jugador se desplaza a la izquierda.
			if (IsGrounded())
				animator.SetBool("walk", true); //...y si el jugador se encuentra sobre el suelo, se reproduce la nimcación de caminar.

		}
		else
		{
			RB2D.velocity = new Vector2(0, RB2D.velocity.y); //Al dejar de presionar las teclas de desplazamiento la velocidad del jugador se vuelve 0.
			//Esto elimina el efecto de "derrape" en el movimiento.
			if (IsGrounded()) {
				animator.SetBool("walk", false); //Tambien deshabilita la animación de caminar.
			}
		}
        #endregion

        #region Health System
        
		if (currentHealth > maxHealth) //Esto evita que la salud del jugador rebase la salud máxima.
        {
			currentHealth = maxHealth;
        }

		if(currentHealth <= 0) //Si la salud del jugador llega a 0 se inicia el proceso de muerte del jugador.
        {
			Die();
        }

        //Se establece un arreglo para almacenar las pociones.
		for (int i = 0; i < potions.Length; i++)
        {
			if (i < potionCount) //Si el número de la poción dentro del arreglo es menor al de la cantidad de pociones recolectadas...
            {
				potions[i].enabled = true; //...su correspondiente ícono será habilitado.
            }
			else
            {
				potions[i].enabled = false; //De lo contrario su ícono estará deshabilitado.
			}
        }

		if (Input.GetKeyDown(KeyCode.Z))
        {
			Heal(); //Al presionar la tecla "Z" se inicia el proceso "Heal".
        }

		KeyText.keyAmount = keyCount; //Actualiza el número de llaves recolectadas, el cuál se muestra en la UI.

        #endregion 
    }

    void Heal()
	{
		if (potionCount > 0) //Si la cantidad de pociones es mayor a 0...
		{
			currentHealth += 30; //...el jugador recuperará 30 puntos de salud...
			potionCount -= 1; //...y perderá una poción.
		}
	}

	void Die()
	{
		SceneManager.LoadScene("Test1"); //Se reinicia la escena si el jugador muere.
	}


	#region GroundCheck
	private bool IsGrounded()
    {
		return transform.Find("GroundCheck").GetComponent<GrounCheck>().isGrounded; //Verifica el valor de la variable "isGrounded" del script "GroundCheck".
    }
    #endregion 

	public void Damage(int dmg) //Este proceso se inicia desde un script externo que sirve para que un enemigo aplique daño al jugador.
    {
		currentHealth -= dmg; //Se le resta la cantidad de daño a la salud del jugador.
		animator.SetTrigger("hit"); //Se reproduce la animación de daño.
	}

	public void PickUpPotion() //Este proceso se inicia desde un script externo que sirve para que el jugador recolecte las pociones.
	{
		potionCount++; //La cantidad de pociones aumenta en 1.
		if (potionCount >= 4) //Y esto evita que el jugador lleve más pociones del límite.
		{
			potionCount = 4;
		}
	}

	public void PickUpKey() //Este proceso se inicia desde un script externo que sirve para que el jugador recolecte las llaves.
	{
		keyCount++; //La cantidad de llaves aumenta en 1.
    }
}