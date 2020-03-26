using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : Intaract
{
    public GameObject CheckpointItem;
    public GameObject Object;

    public override void Use()
    {
        CheckpointItem.transform.position = this.transform.position;
        Subject = "Checkpoint done";
        base.Use();

    }
}
