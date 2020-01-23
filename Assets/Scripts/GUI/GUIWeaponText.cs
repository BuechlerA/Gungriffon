using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIWeaponText : MonoBehaviour
{
    public Gun currentMG;
    public TextMeshProUGUI meshText;

    private void Start()
    {
        //currentMG = GetComponentInParent<Gun>();
        //meshText = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        meshText.text = "MG - " + currentMG.currentClipSize;
    }
}
