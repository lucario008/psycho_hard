using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basura : MonoBehaviour
{
   
    public AudioSource Dialogo1;   
    public AudioSource PostVieja; 
    private bool yaSono = false;

    private void OnTriggerEnter(Collider other)
    {
        
     if (other.CompareTag("Player") && PostVieja != null && PostVieja.isPlaying && !yaSono)
        {
            if (Dialogo1 != null && !Dialogo1.isPlaying)
            {
                Dialogo1.Play(); 
                yaSono = true; 
            }
        }
    }

}


