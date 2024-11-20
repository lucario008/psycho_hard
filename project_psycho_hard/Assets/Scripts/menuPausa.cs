using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuPausa : MonoBehaviour
{

    public GameObject ObjetoMenuPausa;

    public bool Pausa = false; 
    public GameObject cameraObjectX;
    public GameObject cameraObjectY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausa == false)
            {
                Pausar();
            } else {
                Resumir();
            }
    }
}

    void Pausar (){
        Pausa = true;

        ObjetoMenuPausa.SetActive(true);

            Time.timeScale = 0;
            Cursor.visible = true; 
            Cursor.lockState = CursorLockMode.None;

            if (cameraObjectX != null){
                cameraObjectX.GetComponent<MouseLook>().enabled = false;
                cameraObjectY.GetComponent<MouseLook>().enabled = false;

            }
    }

    public void Resumir()
    {
        Pausa = false; 

        ObjetoMenuPausa.SetActive(false);

        Time.timeScale = 1;  
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

         if (cameraObjectX != null) {
            cameraObjectX.GetComponent<MouseLook>().enabled = true;
            cameraObjectY.GetComponent<MouseLook>().enabled = true;
         }

    }
     public void SalirDelJuego(){
        Application.Quit();
        Debug.Log ("Saliendo");
    }

     public void Continuar (){
        Resumir();
    }
}
