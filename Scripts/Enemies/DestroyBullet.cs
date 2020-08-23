//Nombre del desarrollador: Emiliano Hernandez
//Asignatura: Estructura de datos
//Descripcion de usos de este codigo:
//Este script se utilizara para destruir los proyectiles.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    [SerializeField] float duration;

    private void OnEnable() //Se abilita cuando el GameObj está activo.
    {
        Invoke("Destroy", duration);
    }

    private void Destroy() //Desactiva al objeto.
    {
        this.gameObject.SetActive(false);
    }

    private void OnDisable() //Se desabilita cuando el GamoObj no está activo.
    {
        CancelInvoke();
    }

    
}
