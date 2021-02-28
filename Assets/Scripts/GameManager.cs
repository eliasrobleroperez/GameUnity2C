using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //El arreglo de waypoint son las posiciones en el mapa
    public Vector3[] waypoints; 
    private bool _isPointerOnAllowedArea = true;

    public bool isPointerOnAllowedArea(){
        return _isPointerOnAllowedArea;
    }

    // se llama automaticamente cuando el raton dentro de uno
    //de los colaides del GameManager
    void OnMouseEnter(){
        _isPointerOnAllowedArea=true;

    }
    // se llama cuando el raton sale del colaider del GameManager
    void OnMouseExit(){
        _isPointerOnAllowedArea=false;
    }

    
    

    /////////////
    //Gama Over//
    /////////////

   //se agrego
    public GameObject PantallaPerder;
    public GameObject PantallaGanar;

    private BarraVidaScript vidaJugador;
    //variable para saber cuantos pandas hay que derrotar
    private int numPandasOleadaParaDerrotar;
    private Transform puntoInicial;

    //Refencia al medidor de azucar para sumar puntos cuando matamos al panda
        private static MedidorAzucarScript medidorAzucar;    
    
    public GameObject pandaPrefab;// Objeto del punto de inicio
        public int numeroOleadas;
        public int numPandasOleadas;
    

    void Start(){

        PantallaGanar.SetActive(false);
        PantallaPerder.SetActive(false);

        if(medidorAzucar == null){
            medidorAzucar= FindObjectOfType<MedidorAzucarScript>();

        }

        //Recuperamos una referencia a la barra de vida del jugador
        vidaJugador= FindObjectOfType <BarraVidaScript>();

        puntoInicial = GameObject.Find("PuntoInicio").transform;

        StartCoroutine(OleadaEnemigos());
                

    
    }
 

    private void GameOver(bool JugadorGano){
        if(JugadorGano){
            PantallaGanar.SetActive(true);
            Debug.Log("Estoy en pantalla Ganar "+PantallaGanar); 
        }
        else 
        {
            PantallaPerder.SetActive(true);
            
            Debug.Log("Estoy en pantalla perder "); 
        }
        // congela el tiempo
        Time.timeScale=0;

    }

    public void PandaDerrotado(){
        numPandasOleadaParaDerrotar --;
        medidorAzucar.AgregarAzucar(5);
    }

    public void PandaDerrotado2(bool comioPastel){
        numPandasOleadaParaDerrotar--;
        //medidorAzucar.AgregarAzucar(5);
    } 
    //funcion de daño de vida del jugador cuando el panda come el pastel
    public void ComerPastel(int herida){
        bool seComioPastel= vidaJugador.aplicarHerida(herida);
        if (seComioPastel){
            GameOver(false);
        }

        //como hay un panda menos se notifica al Game Manager
        PandaDerrotado2(seComioPastel);


    }

    //corutina que crea oleadas de enemigos
    private IEnumerator OleadaEnemigos (){
        //para cada oleada
        for (int i=0; i < numeroOleadas; i++)
        {
            //llamamos a  la rutina PandaOleadas para que gestione
            //la oleada y esperar cuando ha concluido
            yield return PandaOleada();

            //cuando la corrutina acaba, se puede incrementar el numero de pandas
            numPandasOleadas += 3;             

        }
        //si se acabaron las hordas, se llama a Game Over 
        GameOver(true);

    }

    //corutina que crea una oleada simple y espera hasta que se acabe los enemigod
    private IEnumerator PandaOleada(){
        //tengo que derrotar tantos pandas como indique la oleada
        numPandasOleadaParaDerrotar=numPandasOleadas;

        //se genera progresivamente los pandas de la oleada
        for(int i=0; i<numPandasOleadas; i++){
            //instanciamos el panda, en la posicion de InicioOleada
            Instantiate(pandaPrefab, puntoInicial.position, Quaternion.identity );

            //Se detiene la rutina unos segundos aleatorios
            float ratio= (i*1.0f)/(numPandasOleadas-1);
            //Elijo un tiempo aleatorio basado en la formula mostrada a continuacion
            float timeToWait = Mathf.Lerp(3f,5f,ratio)+ Random.Range(0f, 2f);
            //Le digo a la corutina que duerma
            yield return new WaitForSeconds(timeToWait);
        }

        //si se puede derrotar los pandas
        yield return new WaitUntil(()=> numPandasOleadaParaDerrotar <= 0);
        



    }

}
