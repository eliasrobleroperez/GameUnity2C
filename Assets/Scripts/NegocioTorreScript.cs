using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //detecta interaccion conla UI

public abstract class NegocioTorreScript : MonoBehaviour, IPointerClickHandler {
    //Puntos del Medidor de azucar
    protected static MedidorAzucarScript medidorAzucar;

    //Torre seleccionada para ser vedida o mejorada
    protected static TorreScript torreActual;

void Start()
    {
        if (medidorAzucar == null)
        {
            
            // si no ha sido inicializado
            medidorAzucar = FindObjectOfType<MedidorAzucarScript>();

        }
                
    }



    public static void setTorreActiva(TorreScript nuevaTorre){
      torreActual= nuevaTorre;
    }

//metodo abstracta llamada cuando uno de los tres botones se pulse y cada uno implementara
//una logica diferente
    public abstract void OnPointerClick(PointerEventData eventData);

    
}
