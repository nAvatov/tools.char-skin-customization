using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsController : MonoBehaviour
{
    [SerializeField] RectTransform contentPlacementRT;
    [SerializeField] List<Skin> _avaiableSkins;
    private static List<Skin> currentEnabledSkins;

    private void Start() {
        currentEnabledSkins = new List<Skin>();
        InitializeSkins();
    }

    // Skin filtering method based on chosen skin type transmitted as arg
    public void FilterSkins(SkinType chosenSkinType) {
        // If general view - show all the skins without filter
        if (chosenSkinType == SkinType.ungroupedSkin) { 
            for(int i = 0; i < contentPlacementRT.childCount; i++) {
                contentPlacementRT.GetChild(i).gameObject.SetActive(true);
            }
        // Filter skins by view position
        } else { 
            for(int i = 0; i < contentPlacementRT.childCount; i++) {
                contentPlacementRT.GetChild(i).gameObject.SetActive(contentPlacementRT.GetChild(i).gameObject.GetComponent<Skin>().MySkinType == chosenSkinType);
            }
        }
    
        UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(contentPlacementRT);
    }

    private void HandleChosenSkins(Skin skin, bool add) {
        if (add) {
            DisableDuplicateTypeOfSkins(skin.MySkinType);
            skin.EnableSkin();
            currentEnabledSkins.Add(skin);
        } else {
            currentEnabledSkins.Remove(skin);
            skin.DisableSkin();
        }
    }

    private static void DisableDuplicateTypeOfSkins(SkinType typeToCheck) {
        foreach(Skin skin in currentEnabledSkins) {
            if (skin.MySkinType == typeToCheck) {
                skin.DisableSkin();
            }
        }
    }

    private void InitializeSkins() {
        foreach(Skin enabledSkin in _avaiableSkins) {
            enabledSkin.Construct(HandleChosenSkins);
        }

        Debug.Log("Skins initialized");
    }
}
