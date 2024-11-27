using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputName : MonoBehaviour
{
    [SerializeField] private bool isPlayer;
    [SerializeField] TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        inputField.onValueChanged.AddListener(UpdateName);
    }

    private void UpdateName(string name)
    {
        if (isPlayer)
            SaveController.instance.namePlayer = name;
        else
            SaveController.instance.nameEnemy = name;
    }
}
