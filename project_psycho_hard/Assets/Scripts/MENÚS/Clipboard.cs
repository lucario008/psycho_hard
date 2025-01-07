using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using static UnityEditor.ShaderData;

public class Clipboard : MonoBehaviour
{

    private Animator anim;
    private bool subir;

    private void Start()
    {
        anim = GetComponent<Animator>();
        subir = anim.GetBool("Subir");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (subir)
            {
                subir = !subir;
                anim.SetBool("Subir", subir);
            } else
            {
                subir = true;
                anim.SetBool("Subir", subir);
;            }
        } 
        }
    }
