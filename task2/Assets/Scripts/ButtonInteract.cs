using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteract : MonoBehaviour
{
    // Start is called before the first frame update
    public Text InteractText;
    public string BaseText;
    public string Subject;

    bool Check()
    {
        if (NewBehaviourScript.Instance.ItemToIntaract.tag == "Button")
            return true;
        else
            return false;

    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.V) && Check())
            Use();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == NewBehaviourScript.Instance.gameObject)
        {
            InteractText.text = "Press V to " + BaseText;
            NewBehaviourScript.Instance.ItemToIntaract = this.gameObject;
        }
    }


    public virtual void Use()
    {
        InteractText.text = Subject;
    }
}