using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : ButtonInteract
{
    public bool isActive = false;
    public override void Use()
    {
        if (!isActive)
        {
            foreach (Transform t in transform)
            {
                t.GetComponent<Collider2D>().enabled = true;
            }
            Subject = "Button activated.Door is open.";
            isActive = true;
        }
        else
        {
            foreach (Transform t in transform)
            {
                t.GetComponent<Collider2D>().enabled = false;
            }
            Subject = "Disactivated";
            isActive = false;
        }
        base.Use();
    }
}


