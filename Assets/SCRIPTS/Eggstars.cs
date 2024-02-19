using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggstars : MonoBehaviour
{
    public Animator anim;
    public AudioSource sonido;

    public AudioClip clip;

    public bool Agarrar = false;

    // Start is called before the first frame update

    private void Awake()
    {
       anim = GetComponentInChildren<Animator>();
       sonido = GetComponent<AudioSource>();
       sonido.clip = clip;
    }
    void Start()
    {

        Debug.Log("hola, soy "+gameObject.name );
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Agarrar)
        {
            anim.SetBool("Take", true);
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        //Entrar en base
        Debug.Log("entro");
        if (other.CompareTag("base"))
        {
            anim.SetBool("Dance", true);
            SonidoOn();
            Agarrar= false;
            anim.SetBool("Take", false);
        }

        //Entrar en Caja
        if (other.CompareTag("Caja"))
        {
            anim.SetBool("Fuera", false);
            Agarrar = false;
            anim.SetBool("Take", false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Salir de basee
        Debug.Log("salio");
        if (other.CompareTag("base")) 
        {
            anim.SetBool("Dance", false);
            SonidoOff();
        }
        //Salir de caja
        if (other.CompareTag("Caja"))
        {
            anim.SetBool("Fuera", true);

        }
    }

    public void SonidoOn()
    {
        sonido.Play();
    }

    public void SonidoOff()
    {
        sonido.Stop();
    }

}
