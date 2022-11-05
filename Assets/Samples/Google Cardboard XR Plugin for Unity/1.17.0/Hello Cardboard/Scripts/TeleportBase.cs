using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBase : MonoBehaviour
{
    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    /*
    private void OnMouseEnter()
    {
        renderer.material.color = Color.red;
    }

    private void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }*/

    private void OnGazeEnter()
    {
        renderer.material.color  = Color.white;
    }

    private void OnGazeExit()
    {
        renderer.material.color = Color.white;
    }
}
