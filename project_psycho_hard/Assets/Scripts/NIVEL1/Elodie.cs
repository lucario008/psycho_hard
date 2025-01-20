using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elodie : MonoBehaviour
{
       public AudioSource Dialogo1; 
    private bool yaSono = false; 

        private void OnTriggerEnter(Collider other)
 {
         if (other.CompareTag("Player") && !yaSono) 
        {
            if (Dialogo1 != null && !Dialogo1.isPlaying)
            {
                Dialogo1.Play();
                yaSono = true;
        }

}
}
}