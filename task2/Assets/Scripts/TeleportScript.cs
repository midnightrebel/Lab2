using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;


public class TeleportScript : Intaract
{

    public GameObject Player;
    public GameObject Teleport;

    public override void Use()
    {
        Player.transform.position = Teleport.transform.position;
        Subject = "Teleported";
        base.Use();
    }

}