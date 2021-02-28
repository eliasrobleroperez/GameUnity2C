using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreScript : MonoBehaviour
{
    [Header("Variables de disparo")]
    [Tooltip("Distancia maxima de disparo de la torre")]
    public float radioRango;
    [Tooltip("Tiempo de recarga")]
    public float tiempoRecarga;
    [Tooltip("Prefab del proyectil")]
    public GameObject PrefabProyectil;
    [Tooltip("Tiempo pasado de la ultima recarga")]
    private float tiempoUltimoDisparo;

    [Header("Niveles de torre")]
    [Tooltip("Nivel actual de torre")]
    private int _nivelActual; //checar

//agregue 2 feb
    [Header("Comprar torre")]
    [Tooltip("Precio de la torre")]
    public int costoInicial;

    [Tooltip("Precio de mejora de la torre")]
    public int costoMejora;
    [Tooltip("Precio costo de venta de la torre")]
    public int costoVenta;

    [Tooltip("Precio incremento de mejora")]
    public int CostoMejoraInc;
    [Tooltip("Precio de incremento de venta")]
    public int CostoVentaInc;

    public int nivelActual{
        get{
            return _nivelActual;
        }
        set {
            _nivelActual=value;
        }
    }



    [Tooltip("Sprites de los niveles de la torre")]
    public Sprite[] nivelSprite;

    [Tooltip("Variable para verificar si la torre puede subir de nivel")]
    public bool seActualiza=true;
    
    [Tooltip("Game Object de los proyectiles")]
    public GameObject[] proyectilesPrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(tiempoUltimoDisparo >= tiempoRecarga)
        {
            
            //encontrar todos los Game Objects que tengan un collider dentro del rango
            //de disparo
            Collider2D[] disparoColision = Physics2D.OverlapCircleAll(transform.position, radioRango);

            if (disparoColision.Length != 0){

                //logica de los disparos con posibles blancos
                //panda mas cercano

                float distanciaMinima= int.MaxValue;
                int indice=-1;

                for(int i=0; i<disparoColision.Length;i++){

                    if(disparoColision[i].tag == "Enemigo"){
                        float distancia = Vector2.Distance(disparoColision[i].transform.position, this.transform.position);
                        if(distancia < distanciaMinima){
                            indice = i;
                            distanciaMinima = distancia;

                        }
                    }
                }
                if(indice < 0){
                    return;
                }
                //existe blanco a disparar
                Transform blanco= disparoColision[indice].transform;
                Vector2 direccion= (blanco.position - this.transform.position).normalized;

                //disparar
                //se  crea el proyectil con una intacia del prefab del proyectil
                GameObject proyectil= GameObject.Instantiate(PrefabProyectil, this.transform.position, Quaternion.identity) as GameObject;
                proyectil.GetComponent<proyectilScript>().direccion=direccion;
            
                tiempoUltimoDisparo=0;
            }

        }
        tiempoUltimoDisparo += Time.deltaTime; 

    }

    public void subirNivel(){
        if (!seActualiza){
            return;
        }

        this.nivelActual++;

        if(this.nivelActual == nivelSprite.Length ){
            seActualiza=false;
        }

        //Mejorar estado de torre
        radioRango += 1f;
        tiempoRecarga -= 0.5f;

        //5 de feb
        //sube los precios de mejora y venta
        costoVenta += CostoVentaInc;
        costoMejora += CostoMejoraInc;


        this.GetComponent<SpriteRenderer>().sprite = nivelSprite[nivelActual];
        this.PrefabProyectil= proyectilesPrefab[nivelActual];


    }

    void OnMouseDown(){
        NegocioTorreScript.setTorreActiva(this);
        Debug.Log("He seleccionado una torre");

    }

    public void DestruirTorre(){
            Destroy(gameObject);
    } 
}
