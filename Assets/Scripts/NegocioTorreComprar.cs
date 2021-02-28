using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NegocioTorreComprar : NegocioTorreScript {

   // [Tooltip("Variable para identificar prefab de la torre a elegit con este boton")]
    public GameObject  torrePrefab;


/*void Start()
    {
        
    }
*/
void Update(){}
    public override void OnPointerClick (PointerEventData eventData){
        // cuando hacemos click
        int precio = torrePrefab.GetComponent<TorreScript>().costoInicial;
        
        //comprobar si el usuario tiene dinero para comprar esta torre
        if (precio <= medidorAzucar.getpuntajeAzucar()){
            // tengo sufieciente dinero y puedo comprar la torre
         medidorAzucar.AgregarAzucar(-precio);
            //instaciar el prefab en pantalla
            GameObject nuevaTorre= Instantiate(torrePrefab);
            //el prefab se asigna ala torre actual
            torreActual= nuevaTorre.GetComponent<TorreScript>();

        }
    
    }
}
