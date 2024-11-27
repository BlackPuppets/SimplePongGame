using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectionButton : MonoBehaviour
{
    [SerializeField] private Button uiButton;
    [SerializeField] private Image paddleRefernce;

    [SerializeField] private bool isColorPlayer = false;

    public void OnButtonClick()
    {
        paddleRefernce.color = uiButton.colors.normalColor;

        if(isColorPlayer )
            SaveController.instance.colorPlayer = paddleRefernce.color;
        else
            SaveController.instance.colorEnemy = paddleRefernce.color;
    }
}
