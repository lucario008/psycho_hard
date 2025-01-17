using UnityEngine;
using UnityEngine.UI;

public class BasuraInteraction : MonoBehaviour, IOperable
{
    public GameObject notePanel; // Asigna el Panel de la UI en el inspector
    public Image noteImage;      // Asigna la imagen de la nota en el inspector
    public Sprite noteSprite;    // Asigna el sprite de la nota en el inspector
    public AudioSource audioSource; // Asigna el AudioSource en el inspector
    private bool isPlayerNear = false;

    void Start()
    {
        // Aseg�rate de que el panel est� desactivado al inicio
        if (notePanel != null)
            notePanel.SetActive(false);
    }

    public void Operate()
    {
        // Si el jugador est� cerca y presiona la tecla "E"
       // if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (notePanel != null && isPlayerNear)
            {
                // Alterna entre activar y desactivar el panel
                bool isOpening = !notePanel.activeSelf;
                notePanel.SetActive(isOpening);

   
                // Si se activa, asigna la imagen y reproduce el sonido
                if (isOpening)
                {
                    if (noteImage != null && noteSprite != null)
                    {
                        noteImage.sprite = noteSprite;
                    }

                    // Reproduce el sonido si hay un AudioSource asignado
                    if (audioSource != null)
                    {
                        audioSource.Play();
                    }
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Aseg�rate de que el jugador tenga el tag "Player"
        {
            isPlayerNear = true;
            Debug.Log("Presiona 'E' para interactuar con la basura");
        }
    } 

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;

            // Cierra el panel autom�ticamente si el jugador se aleja
            if (notePanel != null && notePanel.activeSelf)
            {
                notePanel.SetActive(false);
            }

            Debug.Log("Te alejaste de la basura");
        }
    }
}
