using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPlayer : MonoBehaviour
{
    public float interactionDistance;
    private float? startTimer;
    public float deltaTime = 2f;
    private GameObject lastHit;
    private Color color;
    private HashSet<string> cards;
    // Start is called before the first frame update
    void Start()
    {
        cards = new HashSet<string>();
    }

    // Update is called once per frame
    void Update()
    {
        SelectObject();   
    }

    private void SelectObject()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {     
            if (hitInfo.collider.gameObject.GetComponent<Interactable>() != null)
            {
                lastHit = hitInfo.collider.gameObject;
                if (color == Color.clear)
                {
                    color = hitInfo.collider.gameObject.GetComponent<Renderer>().material.color;
                    Debug.Log(cards.Contains("Red"));
                }
                if (Time.time - startTimer >= deltaTime)
                {
                    cards.Add(hitInfo.transform.GetComponent<Interactable>().getId());
                    hitInfo.transform.GetComponent<Interactable>().Interact();
                    Debug.Log(cards.Contains("Red"));
                }else
                {
                    if(startTimer == null)
                    {
                        startTimer = Time.time;
                    }
                    HighlightObject(hitInfo);
                    
                }
            }else
            {
                startTimer = null;
                if (lastHit != null)
                {
                    lastHit.GetComponent<Renderer>().material.color = color;
                    lastHit = null;
                    color = Color.clear;
                }
            }
        }else
        {
            startTimer = null;
        }
    }
    private void HighlightObject(RaycastHit hitInfo)
    {
        hitInfo.collider.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }
    public HashSet<string> getCards() => cards;
}
