using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public enum SkinType { 
    head,
    body,
    hands,
    legs,
    foots,
    ungroupedSkin
}

public class Skin : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject[] _my3DReferences;
    [SerializeField] private UnityEngine.UI.Image _stateImage;
    [SerializeField] private SkinType _mySkinType;
    private System.Action<Skin, bool> _skinClickHandler;
    public SkinType MySkinType => _mySkinType;

    public void Construct(System.Action<Skin, bool> skinClickHandler) {
        _skinClickHandler = new System.Action<Skin, bool>(skinClickHandler);
    }

    public void OnPointerClick(PointerEventData eventData) {
        //HandleMy3DReference();
        _skinClickHandler(this, IsAnyReferenceIsInactive());
    }

    /// <summary>
    /// Handle 3D reference on signature image click
    /// </summary>
    public void HandleMy3DReference() { 
        ChangeSignatureActivity(HandleReferencesActivity(IsAnyReferenceIsInactive()));
    }

    public void DisableSkin() {
        ChangeSignatureActivity(HandleReferencesActivity(false));
    }

    public void EnableSkin() {
        ChangeSignatureActivity(HandleReferencesActivity(true));
    }

    private bool IsAnyReferenceIsInactive() {
        foreach(GameObject reference in _my3DReferences) {
            if (!reference.activeSelf) {
                return true;
            }
        }

        return false;
    }

    private bool HandleReferencesActivity(bool state) {
        foreach (GameObject reference in _my3DReferences) {
            reference.SetActive(state);
        }

        return state;
    }

    private void ChangeSignatureActivity(bool isActive) {
        _stateImage.color = isActive ? Color.green : Color.yellow;
    }
}
