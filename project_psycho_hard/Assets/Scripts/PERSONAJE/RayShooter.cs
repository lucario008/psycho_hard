using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
       _camera = GetComponent<Camera>(); 

       Cursor.lockState = CursorLockMode.Locked;
       Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)) {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
               // Debug.Log("Hit " + hit.point + " (" + hit.transform.gameObject.name + ")");

                IOperable operable = hit.transform.GetComponent<IOperable>();
                if (operable != null){
                    operable.Operate();
                } else {
                    Debug.Log("El objeto golpeado no tiene un script que implemente IOperable.");
                }
         }
    }
    }

    void OnGUI() { 
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
}
