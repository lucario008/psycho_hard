using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarreCarrito : MonoBehaviour
{
    private SpringJoint springJoint;
    public float rangoInteraccion = 3f;
    public float fuerzaDeEmpuje = 10f;
    void Start()
    {
        springJoint = GetComponent<SpringJoint>();
        springJoint.connectedBody = null;  // No conectado al iniciar
        FixedUpdate();
    }

      void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            Interactuar();
           // Debug.Log ("Carrito agarrado");
        }
        else if (Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(1))
        {
            SoltarObjeto();
          //  Debug.Log ("Carrito soltado");
        }
    }


void Interactuar()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, rangoInteraccion))
        {
            if (hit.collider.CompareTag("Carrito"))
            {
                Rigidbody carritoRB = hit.collider.GetComponentInParent<Rigidbody>();
                if (carritoRB != null)
                {
                    springJoint.connectedBody = carritoRB;
                    Debug.Log("Carrito agarrado");
                }
            }
        }
    }

    void SoltarObjeto()
    {
        if (springJoint.connectedBody != null)
        {
            Debug.Log("Carrito soltado");
            springJoint.connectedBody = null;
        }
    }

     void FixedUpdate()
    {
        if (springJoint.connectedBody != null) // Si hay un carrito agarrado
        {
            // Empuja el carrito en la dirección hacia adelante del personaje
            Vector3 direccion = transform.forward;  // Dirección en la que está mirando el personaje
            springJoint.connectedBody.AddForce(direccion * fuerzaDeEmpuje);  // Aplica la fuerza de empuje
        }
    }

  }
