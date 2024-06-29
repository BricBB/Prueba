using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntuacionActual : MonoBehaviour
{
    public static PuntuacionActual Instancia { get; private set; }

    public TMP_Text textoPuntuacion;
    private int puntuacionActual;

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ActualizarUI();
    }

    public void AumentarPuntuacion(int cantidad)
    {
        puntuacionActual += cantidad;
        ActualizarUI();
        MejorPuntuacion.Instancia.ComprobarMejorPuntuacion(puntuacionActual);
    }

    private void ActualizarUI()
    {
        if (textoPuntuacion != null)
        {
            textoPuntuacion.text = "Puntuación: " + puntuacionActual;
        }
    }

    public void ReiniciarPuntuacion()
    {
        puntuacionActual = 0;
        ActualizarUI();
    }

    public int ObtenerPuntuacionActual()
    {
        return puntuacionActual;
    }
}
