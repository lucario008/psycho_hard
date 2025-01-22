using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuInicial : MonoBehaviour
{
    public GameObject menuInicio;
    public GameObject menuOpciones;
    public GameObject menuControles; 
   // public GameObject menuAudio; 
    public GameObject menuCreditos; 
   

    // Update is called once per frame
    void Start()
    {
        menuInicio.SetActive(true);
        menuOpciones.SetActive(false); 
        menuControles.SetActive(false);
      //  menuAudio.SetActive(false);
        menuCreditos.SetActive(false);
    }

     public void Jugar (){
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
        TransitionManager.Instance.LoadScene(TransitionManager.SCENE_NAME_GAME);
    }

    public void Salir (){
        Debug.Log("Salir..."); 
        Application.Quit ();

    }

    public void Opciones (){
        menuOpciones.SetActive (true);
        menuInicio.SetActive (false);
    }

    public void Controles (){
       // menuOpciones.SetActive (false);
        menuOpciones.SetActive (false);
        menuControles.SetActive (true);
    }

   /* public void Audio (){
       // menuOpciones.SetActive (false);
        menuOpciones.SetActive (false);
        menuAudio.SetActive (true);
    }*/

    public void Creditos (){
       // menuOpciones.SetActive (false);
        menuOpciones.SetActive (false);
        menuCreditos.SetActive (true);
    }

    public void CerrarOtros(){
        menuOpciones.SetActive(true);
        menuControles.SetActive (false);
      //  menuAudio.SetActive(false);
        menuCreditos.SetActive(false);

       // menuInicio.SetActive(true);
    }

    public void CerrarOpciones (){
        menuOpciones.SetActive(false);
        menuInicio.SetActive(true);
    }
}
