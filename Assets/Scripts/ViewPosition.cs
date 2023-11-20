using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPosition : MonoBehaviour {
    [SerializeField] private SkinsController _skinsController;
    [SerializeField] private CameraViewController _cameraViewController;
    [SerializeField] private SkinType _filteringSkinType;
        
    public void SetThisView() {
        _cameraViewController.MoveCamera(gameObject.transform);
        _skinsController.FilterSkins(_filteringSkinType);
    }
}
