using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Intaract : MonoBehaviour
{
    // Start is called before the first frame update

    public Text InteractText;
    public string BaseText;
    public string Subject;

    bool Check()
    {
        if (NewBehaviourScript.Instance.ItemToIntaract.tag == "Teleport")
            return true;
        else
            return false;

    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F) && Check())
            Use();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == NewBehaviourScript.Instance.gameObject)
        {
            InteractText.text = "Press F to " + BaseText;
            NewBehaviourScript.Instance.ItemToIntaract = this.gameObject;
        }
    }


    public virtual void Use()
    {
        InteractText.text = Subject;
    }
}
