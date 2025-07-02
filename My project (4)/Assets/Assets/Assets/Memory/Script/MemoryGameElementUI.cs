using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGameElementUI : MonoBehaviour
{
    public int id;
    public Image icon;
    public Button Button;

    public float animationVelocity = 0.01f;

    public bool isMatch = false;

    public Action OnClicked;
    public Action<MemoryGameElementUI> OnOpen;

    public static bool isShowing = false;

    [SerializeField]private MemorygameElement memorygameElement;
    public void Initialize(MemorygameElement memorygameElement)
    {
        this.id = memorygameElement.iD;

        this.memorygameElement = memorygameElement;
        isMatch = false;

        Button.onClick.AddListener(()=> ShowIcon());
    }

    [ContextMenu("SHOW")]
    public void ShowIcon()
    {
        if(isShowing) { return; }
        OnClicked.Invoke();
        StartCoroutine(ShowOrHideIcon(true));
    }

    [ContextMenu("HIDE")]
    public void HideIcon()
    {
        if (isMatch) { return; }
        StartCoroutine(ShowOrHideIcon(false));
    }

    private IEnumerator ShowOrHideIcon(bool show)
    {
        if(!show && icon.sprite == null) { yield break; }

        isShowing = true;
        while (icon.rectTransform.localScale.x>0)
        {
            icon.rectTransform.localScale = 
                new Vector3(icon.rectTransform.localScale.x- animationVelocity, 1, 1);

            yield return null;
        }

        icon.rectTransform.localScale = new Vector3(0, 1, 1);

        icon.sprite = memorygameElement.Sprite;

        icon.sprite = show ? memorygameElement.Sprite : null;

        

        while (icon.rectTransform.localScale.x <1 )
        {
            icon.rectTransform.localScale =
                new Vector3(icon.rectTransform.localScale.x + animationVelocity, 1, 1);

            yield return null;
        }

        icon.rectTransform.localScale = Vector3.one;
        if (show) OnOpen?.Invoke(this);

        isShowing = false;
    }

    public void SetIsMath()
    {
        isMatch = true;
        Button.onClick.RemoveAllListeners();
    }
}
