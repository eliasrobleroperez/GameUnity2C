using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonerTorre : MonoBehaviour
{
    //variable para referenciar el Game Manager
    private GameManager gameManager;

    
    void Start()
    {
        //una referencia al Game Manager de la escena
        gameManager=FindObjectOfType<GameManager>();
        GetComponent<TorreScript>().enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        //para conoccer las coordenadas del raton
        float x= Input.mousePosition.x;
        float y= Input.mousePosition.y;
        float z= 7.0f; 

        transform.position= Camera.main.ScreenToWorldPoint(new Vector3(x,y,z));

        //si el jugador haclick esa posicion se pone una torre
        if(Input.GetMouseButtonDown(0) && gameManager.isPointerOnAllowedArea()){
            //hablitar script  de la torre
            GetComponent<TorreScript>().enabled=true;
            //agregar un collider para evitar que se ponga una torre encima de otra
            gameObject.AddComponent<BoxCollider2D>();
            Destroy(this);
        }

    }
}
