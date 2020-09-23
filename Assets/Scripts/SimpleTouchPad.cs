using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class SimpleTouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {

    public float smoothing;

    
    private bool touched;
    private int pointerID;
    private Vector2 smoothDirection;
    private Vector2 origin;
    private Vector2 direction;

    public void Awake()
    {
        direction = Vector2.zero;
        touched = false;
    }

    public void OnPointerDown (PointerEventData data)
    {
        if (!touched)
        {
            touched = true;
            pointerID = data.pointerId;
            origin = data.position;
        }
    }

    public void OnDrag(PointerEventData data)
    {
        Vector2 currentPosition = data.position;
        Vector2 directionRaw = currentPosition - origin;
        Vector2 direction = directionRaw.normalized;
    }

    public void OnPointerUp(PointerEventData data)
    {
        if(data.pointerId == pointerID)
        {
            direction = Vector3.zero;
            touched = false;
        }
    }

    public Vector2 GetDirection()
    {
        smoothDirection = Vector2.MoveTowards(smoothDirection, direction, smoothing);
        return smoothDirection;
    }
}
