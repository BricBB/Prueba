using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    void Start()
    {
        int selectedColor = PlayerPrefs.GetInt("SelectedColor", 0);
        Color playerColor = Color.white;

        switch (selectedColor)
        {
            case 0: playerColor = Color.red; break;
            case 1: playerColor = Color.green; break;
            case 2: playerColor = Color.blue; break;
        }
        GetComponent<Renderer>().material.color = playerColor;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
