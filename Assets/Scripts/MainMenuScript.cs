using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    //private Button botonSalir;
    /*void Start(){

        //botonSalir= GetComponent<Button>();
        //botonSalir.onClick.AddListener(QuitGame);
    }*/
    public void NewGame(){
        SceneManager.LoadScene(1);
    }
    public void Settings(){
        //SceneManager.LoadScene(2);
    }
    public void QuitGame(){
        Application.Quit();
    }
}
