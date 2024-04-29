using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCaja : MonoBehaviour
{

    public GameObject[] puntosRef;
    public GameObject[] Prefabs;
    private Vector3 posActual;

    // Start is called before the first frame update
    void Start()
    {
        Organizar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Organizar()
    {
        for (int i = 0; i < Prefabs.Length; i++)
        {   posActual= puntosRef[i].transform.position;
            Instantiate(Prefabs[i], posActual, Quaternion.identity);
        }
    
    }
}
