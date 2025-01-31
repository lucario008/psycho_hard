using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(CharacterController))] // obliga a que el GameObject tenga cierto componente

public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;
    private CharacterController _charController;

    public AudioSource pasos;
    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal"); 
        float deltaZ = Input.GetAxis("Vertical");  
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, 1.0f) * speed;    
        movement.y = gravity;

        movement = transform.TransformDirection(movement);
        _charController.Move(movement * Time.deltaTime); 

        if (deltaX != 0 || deltaZ != 0){
            if (!pasos.isPlaying){
                pasos.Play(); 
            }
        } else {
            if (pasos.isPlaying){
                pasos.Stop();
            }
        }
            
        }
        
    }
