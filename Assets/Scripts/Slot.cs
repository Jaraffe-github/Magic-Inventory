using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(GraphicRaycaster))]
public class Slot : MonoBehaviour, IPointerClickHandler
{
    public enum State
    {
        Available,
        Extendable,
    };
    [SerializeField]
    private State _state = State.Available;
    public State state 
    { 
        get { return _state; } 
        private set 
        { 
            _state = value;

            var image = GetComponent<Image>();
            switch (state)
            {
                case State.Available:
                    image.sprite = slotImage;
                    break;
                case State.Extendable:
                    image.sprite = extendImage;
                    break;
            }
        } 
    }

    public Sprite slotImage;
    public Sprite extendImage;

    private void OnValidate()
    {
        state = _state;
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        // toggle.
        if (state == State.Extendable)
        {
            state = State.Available;
        }
        else if (state == State.Available)
        {
            state = State.Extendable;
        }
    }
}
