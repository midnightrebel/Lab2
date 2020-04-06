using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterractCoin :  Intaract
{
    public override void Use(GameObject gameObject)
    {
        base.Use(this.gameObject);
        Destroy(this.gameObject);
    }
}
