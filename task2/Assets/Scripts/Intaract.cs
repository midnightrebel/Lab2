using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;

public class Intaract : MonoBehaviour
{
    // Start is called before the first frame update

    public Text InteractText;
    public UnityAction<GameObject> onInteract;
    public string BaseText;
    public string Subject;

    public GameObject Interactable;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == NewBehaviourScript.Instance.gameObject)
        {
            InteractText.text = "Press F to " + BaseText;
            NewBehaviourScript.Instance.onInteract += this.Use;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == NewBehaviourScript.Instance.gameObject)
        {
            InteractText.text = "";
            NewBehaviourScript.Instance.onInteract -= this.Use;
        }
    }
    public virtual void Use(GameObject interactItem)
    {
        InteractText.text = interactItem.name;
    }
}
