using UnityEngine;
using UnityEngine.UI;

public class BasuraInteraction : MonoBehaviour
{
    public GameObject notePanel; // Asigna el Panel de la UI en el inspector
    public Image noteImage;      // Asigna la imagen de la nota en el inspector
    public Sprite noteSprite;    // Asigna el sprite de la nota en el inspector
    public AudioSource audioSource; // Asigna el AudioSource en el inspector
    private bool isPlayerNear = false;

    void Start()
    {
        // Asegúrate de que el panel esté desactivado al inicio
        if (notePanel != null)
            notePanel.SetActive(false);
    }

    void Update()
    {
        // Si el jugador está cerca y presiona la tecla "E"
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (notePanel != null)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tenga el tag "Player"
        {
            isPlayerNear = true;
            Debug.Log("Presiona 'E' para interactuar con la basura");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;

            // Cierra el panel automáticamente si el jugador se aleja
            if (notePanel != null && notePanel.activeSelf)
            {
                notePanel.SetActive(false);
            }

            Debug.Log("Te alejaste de la basura");
        }
    }
}
