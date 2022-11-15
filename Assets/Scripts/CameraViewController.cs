using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraViewController : MonoBehaviour
{
    static float cameraViewChangeSpeed = 1f;
    

    #region Public Methods

    public static void MoveCamera(Transform newCameraViewPos) {
        Camera.main.transform.DOMove(newCameraViewPos.position, cameraViewChangeSpeed);
    }
        
    #endregion
}
