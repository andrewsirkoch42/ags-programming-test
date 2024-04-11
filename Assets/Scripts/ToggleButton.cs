using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// A special button that can be toggled on or off.
/// </summary>
[RequireComponent(typeof(Button))]
public class ToggleButton : Control
{
    [Header("References")]
    public Sprite normalGraphic;
    public Sprite pressedGraphic;
    public TextMeshProUGUI triggerCounter;

    private bool pressed = false;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Press()
    {
        SetToggleState(!pressed);
        Trigger();
    }
    private void SetToggleState(bool cond)
    {
        pressed = cond;

        if (pressed == true) image.sprite = pressedGraphic;
        else image.sprite = normalGraphic;
    }

    protected override void OnTriggered()
    {
        triggerCounter.text = Triggers.ToString();
    }

}
