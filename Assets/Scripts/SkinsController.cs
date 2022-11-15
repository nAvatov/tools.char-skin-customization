using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsController : MonoBehaviour
{
    [SerializeField] RectTransform contentPlacementRT;
    private static List<Skin> currentEnabledSkins;

    #region UnityMethods

    private void Awake() {
        currentEnabledSkins = new List<Skin>();
    }
        
    #endregion


    /// <summary>
    /// Skin filtering method based on chosen skin type transmitted as arg
    /// </summary>
    /// <param name="chosenSkinType"></param>
    public void FilterSkins(SkinType chosenSkinType) {
        if (chosenSkinType == SkinType.ungroupedSkin) { // If general view - show all the skins without filter
            for(int i = 0; i < contentPlacementRT.childCount; i++) {
                contentPlacementRT.GetChild(i).gameObject.SetActive(true);
            }
        } else { // Filter skins by view position
            for(int i = 0; i < contentPlacementRT.childCount; i++) {
                contentPlacementRT.GetChild(i).gameObject.SetActive(contentPlacementRT.GetChild(i).gameObject.GetComponent<Skin>().MyType == chosenSkinType);
            }
        }
    
        UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(contentPlacementRT);
    }

    public static void HandleChosenSkins(Skin skin, bool add) {
        if (add) {
            DisableDuplicateTypeOfSkins(skin.MyType);
            skin.EnableSkin();
            currentEnabledSkins.Add(skin);
            Debug.Log("New skin added");
        } else {
            currentEnabledSkins.Remove(skin);
            skin.DisableSkin();
            Debug.Log("Removing skin from enabled list");
        }
    }

    private static void DisableDuplicateTypeOfSkins(SkinType typeToCheck) {
        foreach(Skin skin in currentEnabledSkins) {
            if (skin.MyType == typeToCheck) {
                skin.DisableSkin();
            }
        }
    }
}
