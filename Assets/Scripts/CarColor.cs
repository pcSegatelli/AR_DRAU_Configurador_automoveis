using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CarColor : MonoBehaviour
{
    public Material CarMaterial;
    public Button[] ColorButtons;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var button in ColorButtons)
        {
            button.onClick.AddListener(ChangeCarColor);
        }
    }

    private void ChangeCarColor()
    {
        GameObject buttonObj = EventSystem.current.currentSelectedGameObject;
        Color buttonColor = buttonObj.GetComponent<Image>().color;
        CarMaterial.color = buttonColor;
    }
}
