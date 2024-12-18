using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventoPuerta : MonoBehaviour
{

     private Animator animator;
     private bool close;
     
     [SerializeField] private Puerta puerta;

    [SerializeField] private GameObject objetoAMover; // Objeto que se moverá
    [SerializeField] private Vector3 nuevaPosicion;  // Nueva posición deseada


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        close = animator.GetBool("Open");
    }

    private void OnTriggerEnter(Collider other){
            Debug.Log("Player ha entrado en el trigger.");
    
                puerta.CerrarPuerta(); // Asegúrate de que este método abra la puerta
            
        }
    

    private void OnTriggerExit(Collider other){
        
            Debug.Log("Player ha salido del trigger.");

            if (objetoAMover != null)
        {
            objetoAMover.transform.position = nuevaPosicion;
            Debug.Log("Objeto movido a la nueva posición.");
        }
  
            gameObject.SetActive(false); // Desactiva el objeto
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
            
        
    }
}
