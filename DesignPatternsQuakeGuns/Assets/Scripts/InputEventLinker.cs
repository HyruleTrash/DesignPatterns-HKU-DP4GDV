using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Simple Input event handler component, used when you need to connect a input to a function temporarily or quick
/// </summary>
public class InputEventLinker : MonoBehaviour
{
    public KeyCode keyCode;
    public bool onUp = false;
    public bool onHold = false;
    public UnityEvent onInputEvent = new UnityEvent();
    private void Update()
    {
        if (onHold && Input.GetKey(keyCode))
        {
            onInputEvent.Invoke();
            return;
        }
        
        if (!onUp)
        {
            if (Input.GetKeyDown(keyCode))
            {
                onInputEvent.Invoke();
            }
        }
        else
        {
            if (Input.GetKeyUp(keyCode))
            {
                onInputEvent.Invoke();
            }
        }
    }
}
