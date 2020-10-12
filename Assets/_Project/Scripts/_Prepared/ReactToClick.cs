using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class ReactToClick : MonoBehaviour, IPointerClickHandler
{
    [Serializable]
    public class ClickEvent : UnityEvent { }

    [SerializeField]
    private ClickEvent OnClickEvent;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickEvent?.Invoke();
    }
}