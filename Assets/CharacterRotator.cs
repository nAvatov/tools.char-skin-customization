using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterRotator : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
    [SerializeField] private Transform _charactersTransform;
    [SerializeField] private float _rotationSpeedMultiplier = 2f;
    private Vector2 _dragStartPoint;
    public void OnBeginDrag(PointerEventData eventData) {
        _dragStartPoint = eventData.position;
    }

    public void OnDrag(PointerEventData eventData) {
        //ApplyRotation(eventData.position.x - _dragStartPoint.x);
        ApplyRotation(eventData.delta.x);
    }

    public void OnEndDrag(PointerEventData eventData) {
        
    }

    private void ApplyRotation(float value) {
        _charactersTransform.RotateAround(Vector3.up, -value * _rotationSpeedMultiplier * Time.deltaTime);
    }
}
