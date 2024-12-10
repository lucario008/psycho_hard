using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
   public GameObject menuInicio;
   public GameObject menuOpciones;
   

    // Update is called once per frame
    void Start()
    {
        menuInicio.SetActive(true);
        menuOpciones.SetActive(false); 
    }

     public void Jugar (){
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir (){
        Debug.Log("Salir..."); 
        Application.Quit ();

    }

    public void Opciones (){
        menuOpciones.SetActive (true);
        menuInicio.SetActive (false);
    }

    public void Cerrar (){
        menuOpciones.SetActive(false);
        menuInicio.SetActive(true);
    }
}
