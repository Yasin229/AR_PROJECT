using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class NewBehaviourScript : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    bool isPressed = false;
    public AudioClip sound;
    public AudioSource source;
    
    void Update()
    {
        if (isPressed)
        {
            source.PlayOneShot(sound);

            isPressed = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
