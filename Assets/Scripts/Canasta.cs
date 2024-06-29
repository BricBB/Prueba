using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Canasta : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento de la canasta
    public float limiteIzquierdo = -8f; // L�mite izquierdo de la pantalla
    public float limiteDerecho = 8f; // L�mite derecho de la pantalla

    private void Update()
    {
        // Obtener la entrada horizontal del usuario
        float movimientoHorizontal = Input.GetAxis("Horizontal");

        // Calcular el desplazamiento
        float desplazamiento = movimientoHorizontal * velocidad * Time.deltaTime;

        // Obtener la posici�n actual
        Vector3 posicionActual = transform.position;

        // Calcular la nueva posici�n
        float nuevaPosicionX = Mathf.Clamp(posicionActual.x + desplazamiento, limiteIzquierdo, limiteDerecho);

        // Aplicar el movimiento
        transform.position = new Vector3(nuevaPosicionX, posicionActual.y, posicionActual.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ObjetoCaida"))
        {
            PuntuacionActual.Instancia.AumentarPuntuacion(1);
            Destroy(other.gameObject);
        }
    }

}