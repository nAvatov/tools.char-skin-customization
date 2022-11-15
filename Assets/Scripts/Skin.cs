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
    [SerializeField] GameObject[] my3DReferences;
    [SerializeField] UnityEngine.UI.Image activityImage;
    [SerializeField] string skinTypeName;

    private SkinType mySkinType;

    public SkinType MyType {
        get {
            return mySkinType;
        }
    }

    #region Unity Methods

    private void Awake() {
        mySkinType = DetermineSkinType(skinTypeName);
    }

    public void OnPointerClick(PointerEventData eventData) {
        //HandleMy3DReference();
        SkinsController.HandleChosenSkins(this, IsAnyReferenceIsInactive());
    }
        
    #endregion


    #region Public Methods

    /// <summary>
    /// Handle 3D reference on signature image click
    /// </summary>
    public void HandleMy3DReference() { 
        ChangeSignatureActivity(HandleReferencesActivity(IsAnyReferenceIsInactive()));
    }

    public void DisableSkin() {
        ChangeSignatureActivity(HandleReferencesActivity(false));
        Debug.Log("Some skin disabled");
    }

    public void EnableSkin() {
        ChangeSignatureActivity(HandleReferencesActivity(true));
        Debug.Log("Some skin enabled");
    }
        
    #endregion

    #region Private Methods

    private bool IsAnyReferenceIsInactive() {
        foreach(GameObject reference in my3DReferences) {
            if (!reference.activeSelf) {
                return true;
            }
        }

        return false;
    }

    private bool HandleReferencesActivity(bool state) {
        foreach (GameObject reference in my3DReferences) {
            reference.SetActive(state);
        }

        return state;
    }

    private void ChangeSignatureActivity(bool isActive) {
        activityImage.color = isActive ? Color.green : Color.yellow;
    }

    /// <summary>
    /// Creates connection from serializible string type to the unserializible custom type
    /// </summary>
    /// <param name="skinTypeSignature"></param>
    /// <returns></returns>
    public static SkinType DetermineSkinType(string skinTypeSignature) {
        switch(skinTypeSignature) {
            case "head" : {
                return SkinType.head;
            }

            case "body" : {
                return SkinType.body;
            }

            case "hands" : {
                return SkinType.hands;
            }

            case "legs" : {
                return SkinType.legs;
            }

            case "foots" : {
                return SkinType.foots;
            }
            
            default: {
                return SkinType.ungroupedSkin;
            }

        }
    }
        
    #endregion
}
