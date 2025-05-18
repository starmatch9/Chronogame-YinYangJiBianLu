using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    public enum FadeType
    {
        FadeIn,
        FadeOut,
        FadeInOut
    }

    [Header("���뵭������")]
    public FadeType fadeType = FadeType.FadeIn;
    public float duration = 1.0f;
    public float delay = 0f;
    public bool playOnStart = true;
    public bool disableAfterFadeOut = false;

    [Header("��ɫ����")]
    public Color targetColor = Color.white;
    private Graphic uiGraphic; // UI Text��Image
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

}
