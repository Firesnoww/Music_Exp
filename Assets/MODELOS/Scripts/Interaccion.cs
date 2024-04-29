using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaccion : MonoBehaviour
{
    public Acciones accion;
	public GameObject[] objetosDesactivar;
	public GameObject[] objetosActivar;
	public float escalaSeleccionada;
	public AudioSource audio;


	Vector3 escala;

	private void Start()
	{
		escala = transform.localScale;
		if (audio == null)
		{
			audio = GetComponent<AudioSource>();
		}
	}
	public void ActivarAccion()
	{
		switch (accion)
		{
			case Acciones.desactivador:
				for (int i = 0; i < objetosDesactivar.Length; i++)
				{
					objetosDesactivar[i].SetActive(false);
				}
				for (int i = 0; i < objetosActivar.Length; i++)
				{
					objetosActivar[i].SetActive(true);
				}
				break;
			case Acciones.cambioColor:

				break;
			default:
				break;
		}
	}

	private void OnMouseDown()
	{
		ActivarAccion();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			ActivarAccion();
			transform.localScale = escala * escalaSeleccionada;
			if (audio != null)
			{
				audio.Play();
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			transform.localScale = escala;
		}
	}
}

public enum Acciones
{
    desactivador    = 0,
    cambioColor     = 1
}