using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using UnityEngine;

public class Eggstars : MonoBehaviour
{
    public AudioSource sonido;
    public AudioClip[] clip;

    public int SonidosPista;
    public bool Esta = false;

    public float velocidad;

    public GameObject HuevitoGrande;

    public GameManagement management;

    public Activo_Desactivo[] PlataformasSonido;

    public InputActionProperty accion;

    public bool tempo = true;


    // Start is called before the first frame update

    private void Awake()
    {
        
        sonido = GetComponent<AudioSource>();
        sonido.clip = clip[SonidosPista];
        management = FindObjectOfType<GameManagement>();
    }
    void Start()
    {

        Debug.Log("hola, soy " + gameObject.name);
        
        accion.action.performed += Presionado;

    }

    public void Presionado(InputAction.CallbackContext p) 
    {
        tempo = !tempo;
    }
    // Update is called once per frame
    void Update()
    {
        velocidad = management.tiempoInicial;

        if (accion.action.ReadValue<float>() > 0.9f)
        {
            print("accion update");
        }

        if (management.inicio && Esta )
        {
            StartCoroutine(CSonido());
        }

        }
    public void ActivadorSonido()
    {
       
            
        
    }

    private void OnTriggerEnter(Collider other)
    {
      
        //Entrar en base

        if (other.CompareTag("base"))
        {
            Debug.Log("entro_Huevo "+ gameObject.name);
            Esta = true;         
            DetectorDeHuevo detect = other.GetComponent<DetectorDeHuevo>();
            Transform lugar = detect.LugarHuevo;
            Instantiate(HuevitoGrande, lugar.position, lugar.rotation);
        }

        //Entrar en Caja

    }
	private void OnTriggerStay(Collider other)
    {

    }


	private void OnTriggerExit(Collider other)
    {
     
        //Salir de basee

        if (other.CompareTag("base"))
        {
            Debug.Log("salio");
            Esta = false;
            //Destroy(HuevitoGrande);
        }

    }

    IEnumerator CSonido()
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
