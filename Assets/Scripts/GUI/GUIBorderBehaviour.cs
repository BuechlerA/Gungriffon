﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIBorderBehaviour : MonoBehaviour
{
    private RectTransform reticle;
    private Image borderSprite;

    public Vector2 rectSize;
    public Vector2 rectPos;

    private void Start()
    {
        reticle = GetComponent<RectTransform>();
        borderSprite = GetComponent<Image>();
    }

    public void SetTransform(Vector3 pos)
    {
        reticle.sizeDelta = rectSize;
        reticle.position = pos;

        if (pos.z <= 0f)
        {
            borderSprite.enabled = false;
        }
        else
        {
            borderSprite.enabled = true;
        }
    }
}
