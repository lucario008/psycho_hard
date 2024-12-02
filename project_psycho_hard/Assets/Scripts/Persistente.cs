using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistente : MonoBehaviour
{
      private void Awake()
    {
        // Evitar duplicados si ya existe otro objeto igual
         DontDestroyOnLoad(gameObject); // Mantiene el objeto al cambiar escenas

    }
}
