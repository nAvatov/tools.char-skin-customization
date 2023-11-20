using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraViewController : MonoBehaviour {
    [SerializeField] private float _cameraViewChangeDuration = 1f;
    
    public void MoveCamera(Transform newCameraViewPos) {
        Camera.main.transform.DOMove(newCameraViewPos.position, _cameraViewChangeDuration);
    }
}
