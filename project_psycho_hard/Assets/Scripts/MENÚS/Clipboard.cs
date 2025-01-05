using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderData;

public class Clipboard : MonoBehaviour
{

    public GameObject ObjetoMenuClipboard;

    public GameObject cameraObjectX;
    public GameObject cameraObjectY;

    public bool Pausa = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Pausa == false)
            {
                Pausar();
            }
            else
            {
                Resumir();
            }
        }
    }

    void Pausar()
    {
        Pausa = true;

        ObjetoMenuClipboard.SetActive(true);

        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (cameraObjectX != null)
        {
            cameraObjectX.GetComponent<MouseLook>().enabled = false;
            cameraObjectY.GetComponent<MouseLook>().enabled = false;

        }
    }

    public void Resumir()
    {
        Pausa = false;

        ObjetoMenuClipboard.SetActive(false);

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (cameraObjectX != null)
        {
            cameraObjectX.GetComponent<MouseLook>().enabled = true;
            cameraObjectY.GetComponent<MouseLook>().enabled = true;
        }
    }

}
