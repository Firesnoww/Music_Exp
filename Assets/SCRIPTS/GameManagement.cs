using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    [Header("Temporizador")]
    public float tiempoInicial;
    public float tiempoActual;

    // Start is called before the first frame update
    void Start()
    {
        tiempoActual = tiempoInicial;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoActual -= Time.deltaTime;
        if (tiempoActual <= 0f) 
        { 
        tiempoActual = tiempoInicial;
 
        }
    }

}
