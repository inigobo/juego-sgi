using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : Interactable
{
    public string id;
    public override void Interact()
    {
        base.Interact();
        Destroy(gameObject);
    }
    public override string getId() => id; 
}
