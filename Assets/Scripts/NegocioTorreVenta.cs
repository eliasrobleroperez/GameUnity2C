using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NegocioTorreVenta: NegocioTorreScript
{
    
    public override void OnPointerClick(PointerEventData eventData)
    {
       /* //este el codigo para vender torre
        //checar existe una torre seleccionada para ser vendida
      // correcciones
     */
    

        if( torreActual == null){
            return;
        }

        

        //hay una torre seleccionada
        //consultar precio de venta de la torre

      int precioVenta= torreActual.costoVenta;
        //sumar dinero al medidor de azucar 
       

        medidorAzucar.AgregarAzucar(precioVenta);
        
        //destruir la torre actual que se acaba de vender
        torreActual.DestruirTorre();
    }

}
