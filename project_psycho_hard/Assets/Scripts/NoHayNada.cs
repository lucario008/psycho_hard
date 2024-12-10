using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoHayNada : MonoBehaviour, IOperable
{

   public string[] mensajes = {
      "Nada de nada", "No hay nada", "Pura basura", "¡Oh! ... Nada"
   }; 

   public TMPro.TextMeshProUGUI mensajeTexto;

   public float tiempoVisible = 2f; 

   private int contador = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   
       // Update is called once per frame
    public void Operate()
    {
      if (mensajes.Length == 0){
          ActualizarTexto("No hay más mensajes");
         return;
      }
         string mensaje = ObtenerMensajeSecuencial (); 
         ActualizarTexto(mensaje);
        //Debug.Log("Operación realizada: " + ObtenerMensajeSecuencial());
        StartCoroutine (DesaparecerTexto());
    }

     private string ObtenerMensajeSecuencial() {

      if (mensajes == null || mensajes.Length == 0){
          return "No hay mensajes disponibles.";
      }

      string mensaje = mensajes[contador];

      contador++;

      if (contador >= mensajes.Length){
         contador = 0;
      }
      return mensaje;
     }

     private void ActualizarTexto(string mensaje)  {
      if (mensajeTexto != null) {
         mensajeTexto.text = mensaje;
      } else {
      }
    }

    private IEnumerator DesaparecerTexto(){
      yield return new WaitForSeconds(tiempoVisible);
      if (mensajeTexto != null) {
      mensajeTexto.text = "";
      }
    }
}


