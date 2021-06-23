using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaAudioController : MonoBehaviour  
{

    AudioSource source; // Declaramos la única fuente de audio que tenemos. 

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        Renderer rend = GetComponent<Renderer>();
        Bounds bounds = rend.bounds;

        source.pitch = 1.5f / bounds.size.x; // Esta funcion declara que el pitch de la colisión, será más agudo o más grave en función del tamaño del bloque. Cuanto más grande más grave y cuanto más pequeño más agudo. 
    }

    // Update is called once per frame
    void Update()
    {

    }

       
    void OnCollisionEnter(Collision collision) // Declaramos que habrá una colisión con esta función OnCollisionEnter, y los siguientes pasos actuarán en función de esta matriz.
    {
        source.Play(); // Cuando ocurra esta colisión, sonará el sonido del coque contra un bloque. 
    }
}
