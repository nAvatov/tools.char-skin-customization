using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsController : MonoBehaviour {
    [SerializeField] private RectTransform contentPlacementRT;
    [SerializeField] private List<Skin> _avaiableSkins;
    private List<Skin> _enabledSkins;

    private void Start() {
        _enabledSkins = new List<Skin>();
        SetChoiceHanlder();
    }

    // Skin filtering method based on chosen skin type transmitted as arg
    public void FilterSkins(SkinType chosenSkinType) {
        // If general view - show all the skins without filter
        if (chosenSkinType == SkinType.general) { 
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
            _enabledSkins.Add(skin);
        } else {
            _enabledSkins.Remove(skin);
            skin.DisableSkin();
        }
    }

    private void DisableDuplicateTypeOfSkins(SkinType typeToCheck) {
        foreach(Skin skin in _enabledSkins) {
            if (skin.MySkinType == typeToCheck) {
                skin.DisableSkin();
            }
        }
    }

    private void SetChoiceHanlder() {
        foreach(Skin enabledSkin in _avaiableSkins) {
            enabledSkin.Construct(HandleChosenSkins);
        }
    }
}
