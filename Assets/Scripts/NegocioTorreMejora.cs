using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NegocioTorreMejora : NegocioTorreScript
{
    // Start is called before the first frame update
    public override void OnPointerClick(PointerEventData eventData)
  {          //para subir de nivel
        if(torreActual == null){
            return;
        }

        // hay torre seleccionada
        //solo podemps subirla de nivel si no esta en el nivel maximo y hay dinero
        int subirPrecio = torreActual.costoMejora;
        if(torreActual.seActualiza && subirPrecio <= medidorAzucar.getpuntajeAzucar())
        {
            // se descuenta a la medidor de azucar
            medidorAzucar.AgregarAzucar(- subirPrecio);
            // subir nivel de la torre
            torreActual.subirNivel();

        }
    }


        
  //  }
}
