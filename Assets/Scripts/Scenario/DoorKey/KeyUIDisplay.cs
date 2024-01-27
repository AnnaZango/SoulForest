using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUIDisplay : MonoBehaviour
{
    [SerializeField] GameObject[] keyImagesUI;

   
    void Start()
    {
        foreach (GameObject keyImage in keyImagesUI)
        {
            keyImage.SetActive(false);
        }
    }
    

    public void UpdateKeysUI(Key.KeyType keyType, bool show)
    {
        switch (keyType) //display key of the color picked in HUD
        {
            case Key.KeyType.Red:
                keyImagesUI[0].SetActive(show);
                break;
            case Key.KeyType.Green:
                keyImagesUI[1].SetActive(show);
                break;
            case Key.KeyType.Blue:
                keyImagesUI[2].SetActive(show);
                break;
            default:
                break;
        }
    }
}
