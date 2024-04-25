using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    [Header("Temporizador")]
    public float tiempoInicial;
    public float tiempoActual;

    public float tiempoSuena = 0.5f;
    public bool inicio = true;

    // Start is called before the first frame update
    void Start()
    {
        tiempoActual = tiempoInicial;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoActual -= Time.deltaTime;
        tiempoSuena -= Time.deltaTime;
        if (tiempoActual <= 0f) 
        { 
        tiempoActual = tiempoInicial;
        tiempoSuena = 0.5f;

        if (tiempoSuena >= 0.8f) 
            {
                Debug.Log("entro");
                inicio = true;
            }
        else if (tiempoSuena <= 0) 
            {
                Debug.Log("saliooo");
                inicio = false;
            }     
           
        }
    }

}
