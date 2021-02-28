using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MedidorAzucarScript : MonoBehaviour
{
    //indicador de puntos que se mostraran
    private Text MedidorAzucar;
    //variable donde se guarda el puntaje
    private int puntajeAzucar=50;

    public int getpuntajeAzucar(){
        return puntajeAzucar;
    }

    void Start()
    { 
        MedidorAzucar= GetComponent<Text>();
        ActualizarMedidorAzucar();       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AgregarAzucar(int azucar){
        puntajeAzucar += azucar;

        if (puntajeAzucar < 0){
            puntajeAzucar=0;
        }
        ActualizarMedidorAzucar();
    }

    void ActualizarMedidorAzucar(){

        MedidorAzucar.text= getpuntajeAzucar().ToString();
    }
}
