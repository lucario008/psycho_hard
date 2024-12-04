using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mensajes : MonoBehaviour, IOperable
{
    public string mensajeFijo;
    public TMPro.TextMeshProUGUI mensajeTexto;

    public float tiempoVisible = 2f;

    public void Operate()
    {
        mensajeTexto.text = mensajeFijo; // Muestra el mensaje fijo
        StartCoroutine(DesaparecerTexto()); // Borra el texto después de un tiempo
    }

    private IEnumerator DesaparecerTexto()
    {
        yield return new WaitForSeconds(tiempoVisible);
        if (mensajeTexto != null)
        {
            mensajeTexto.text = "";
        }
    }
}
