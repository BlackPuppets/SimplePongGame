using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiWinnerText;

    void Start()
    {
        SaveController.instance.Reset();
        string lastWinner = SaveController.instance.GetLastWinner();

        if (lastWinner != "")
            uiWinnerText.text = "Last Winner: " + lastWinner;
        else
            uiWinnerText.text = "";
    }

}
