using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoMensaje : MonoBehaviour
{
    // Start is called before the first frame update
        private void OnTriggerEnter(Collider other){
            Debug.Log("Player ha entrado en el trigger.");
           
        }
    

    private void OnTriggerExit(Collider other){
        
            Debug.Log("Player ha salido del trigger.");
  
            gameObject.SetActive(false); // Desactiva el objeto
                   
        
    }
}
