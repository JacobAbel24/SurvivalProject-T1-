using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Vector2 lastPointerPosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        lastPointerPosition = eventData.position;
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pointerDelta = eventData.position - lastPointerPosition;
        rectTransform.anchoredPosition += pointerDelta;
        lastPointerPosition = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Handle end drag if needed
    }
}
