using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activo_Desactivo : MonoBehaviour
{
	public string Nombretag;
	public bool suena = false;
	public int Numero = 0;
	// Start is called before the first frame update
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(Nombretag))
		{
			suena = true;
			Activador_Enumerador activador = other.GetComponent<Activador_Enumerador>();
			Numero = activador.Nsonido;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag(Nombretag))
		{
			suena = false;
			Numero = 0;
		}
	}
}

