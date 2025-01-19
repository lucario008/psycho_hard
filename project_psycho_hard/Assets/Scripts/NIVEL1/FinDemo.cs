using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinDemo : MonoBehaviour, IOperable
{

    public GameObject pantallaFin;
    // Start is called before the first frame update

    void Start()
    {
        pantallaFin.SetActive(false);
    }
   public void Operate()
    {
        pantallaFin.SetActive(true);
        AudioListener.pause = true;

        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void SalirDelJuego()
    {
        Application.Quit();
        Debug.Log("Saliendo");
    }
}
