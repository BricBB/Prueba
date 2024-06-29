using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class MejorPuntuacion : MonoBehaviour
{
    public static MejorPuntuacion Instancia { get; private set; }

    public TMP_Text textoMejorPuntuacion;
    private int mejorPuntuacion;

    private const string NOMBRE_ARCHIVO = "mejor_puntuacion.json";

    [System.Serializable]
    private class DatosMejorPuntuacion
    {
        public int mejorPuntuacion;
    }

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
            CargarMejorPuntuacion();
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

    public void ComprobarMejorPuntuacion(int puntuacionActual)
    {
        if (puntuacionActual > mejorPuntuacion)
        {
            mejorPuntuacion = puntuacionActual;
            GuardarMejorPuntuacion();
            ActualizarUI();
        }
    }

    private void ActualizarUI()
    {
        if (textoMejorPuntuacion != null)
        {
            textoMejorPuntuacion.text = "Mejor: " + mejorPuntuacion;
        }
    }

    private void CargarMejorPuntuacion()
    {
        string ruta = Path.Combine(Application.persistentDataPath, NOMBRE_ARCHIVO);
        if (File.Exists(ruta))
        {
            string jsonString = File.ReadAllText(ruta);
            DatosMejorPuntuacion datos = JsonUtility.FromJson<DatosMejorPuntuacion>(jsonString);
            mejorPuntuacion = datos.mejorPuntuacion;
        }
        else
        {
            mejorPuntuacion = 0;
        }
    }

    private void GuardarMejorPuntuacion()
    {
        DatosMejorPuntuacion datos = new DatosMejorPuntuacion
        {
            mejorPuntuacion = mejorPuntuacion
        };
        string jsonString = JsonUtility.ToJson(datos);
        string ruta = Path.Combine(Application.persistentDataPath, NOMBRE_ARCHIVO);
        File.WriteAllText(ruta, jsonString);
    }

    public void ReiniciarMejorPuntuacion()
    {
        mejorPuntuacion = 0;
        GuardarMejorPuntuacion();
        ActualizarUI();
    }
}