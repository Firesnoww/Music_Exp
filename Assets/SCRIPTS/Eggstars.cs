using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggstars : MonoBehaviour
{
    public Animator anim;
    public AudioSource sonido;

    public AudioClip[] clip;

    public bool Agarrar = false;

    public int SonidosPista;
    public bool Esta = false;

    public  float velocidad;

    public GameObject HuevitoGrande;

    public GameManagement management;

    // Start is called before the first frame update

    private void Awake()
    {
       anim = GetComponentInChildren<Animator>();
       sonido = GetComponent<AudioSource>();
       sonido.clip = clip[SonidosPista];
       management= FindObjectOfType<GameManagement>();
    }
    void Start()
    {

        Debug.Log("hola, soy "+gameObject.name );
       
    }

    // Update is called once per frame
    void Update()
    {
        velocidad = management.tiempoInicial;
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
            Esta = true;              
            StartCoroutine(CSonido());       
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
            Esta = false;
        }
        //Salir de caja
        if (other.CompareTag("Caja"))
        {
            anim.SetBool("Fuera", true);
        }
    }

    IEnumerator CSonido()
    {
        if (management.inicio)
        {
            sonido.clip = clip[SonidosPista];
            sonido.Play();
            yield return new WaitForSeconds(velocidad);
            if (Esta == true)
            {
                StartCoroutine(CSonido());
            }
        }
      
    }

}
