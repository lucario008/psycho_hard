using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public Light flashlight; // Referencia a la luz Spotlight
    public KeyCode toggleKey = KeyCode.F; // Encender/apagar la linterna


    void Start()
    {
        flashlight.enabled = false;
    }
    void Update()
    {
        
        if (Input.GetKeyDown(toggleKey))
        {
            
            flashlight.enabled = !flashlight.enabled;
        }
    }
}
