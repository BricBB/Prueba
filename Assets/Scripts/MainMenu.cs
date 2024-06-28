using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Dropdown colorDropdown;

    // Llamado al presionar el botón de iniciar juego
    public void StartGame()
    {
        // Guarda el color seleccionado
        int selectedColor = colorDropdown.value;
        PlayerPrefs.SetInt("SelectedColor", selectedColor);

        // Carga la escena del juego
        SceneManager.LoadScene("GameScene");
    }

    // Llamado al iniciar el menú principal
    void Start()
    {
        // Configura las opciones del dropdown de colores
        colorDropdown.ClearOptions();
        List<string> colors = new List<string> { "Rojo", "Verde", "Azul" };
        colorDropdown.AddOptions(colors);
    }
}
