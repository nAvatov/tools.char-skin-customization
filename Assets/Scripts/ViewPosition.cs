using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPosition : MonoBehaviour
{
    [SerializeField] SkinsController skinsController;
    [SerializeField] string skinsTypeName;


    #region Public Methods
        
    public void SetThisView() {
        CameraViewController.MoveCamera(gameObject.transform);
        skinsController.FilterSkins(Skin.DetermineSkinType(skinsTypeName));
    }

    #endregion
}
