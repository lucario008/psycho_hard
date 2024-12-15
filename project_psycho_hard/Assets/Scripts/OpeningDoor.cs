using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OpeningDoor : MonoBehaviour, IOperable
{
    private Animator anim;
    private bool open;
    public AudioSource puerta;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        open = anim.GetBool("Open");
    }

    // Update is called once per frame
    public void Operate()
    {
        Debug.Log ("Ejecutando puerta");
        open = !open;
        anim.SetBool("Open", open);
        puerta.Play();
    }
}