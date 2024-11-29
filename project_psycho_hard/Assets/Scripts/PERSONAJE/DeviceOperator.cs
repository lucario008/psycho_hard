using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceOperator : MonoBehaviour // corregimos el nombre
{
    public float radius = 1.5f;
    public LayerMask interactableLayer; // Agrega esto para usar el LayerMask

    void Update()
    {
        // Detectar clic izquierdo (Fire1)
        if (Input.GetButtonDown("Fire1")) {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactableLayer);
            foreach (Collider hitCollider in hitColliders) {
                Vector3 direction = hitCollider.transform.position - transform.position;
                if (Vector3.Dot(transform.forward, direction.normalized) > 0.5f) {
                    hitCollider.SendMessage("Operate", SendMessageOptions.DontRequireReceiver);
                     Debug.Log("Intentando enviar mensaje Operate al objeto: " + hitCollider.name);
                }
            }
        }
    }
}
