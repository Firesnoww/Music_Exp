using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    [Header("Temporizador")]
    public float tiempoInicial;
    public float tiempoActual;
    public float IniActual;
    public float tiempoSuena;

    public bool inicio = false;

	public GameObject[] interfaz;
        
	// Start is called before the first frame update
	void Start()
    {
        tiempoActual = tiempoInicial;
        tiempoSuena = IniActual;
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempoActual -= Time.deltaTime;
        tiempoSuena -= Time.deltaTime;

        if (tiempoSuena > 0.8f)
        {
            Debug.Log("entro");
            inicio = true;
        }
        else
        {
            Debug.Log("saliooo");
            inicio = false;
        }

        if (tiempoActual <= 0f)
        {
            tiempoActual = tiempoInicial;
            tiempoSuena = IniActual;

        }
    }

}
