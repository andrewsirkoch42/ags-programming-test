using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// A switch that essentially behaves like a button with a cooldown.
/// </summary>
[RequireComponent(typeof(Image))]
public class Switch : Control, IPointerDownHandler, IPointerUpHandler
{
    // Unity Fields

    [Header("Settings")]
    public UnityEvent OnSwitched = new UnityEvent();
    [Tooltip("Time before switch automatically switches back to default position")]
    public float switchDelay = 0.5f;
    [Tooltip("Vertical distance in pixels the mouse must move to trigger the switch.")]
    public float switchDistance = 10;

    [Header("References")]
    public Sprite switchUpGraphic;
    public Sprite switchDownGraphic;
    public TextMeshProUGUI triggerCounter;

    // Private Fields

    private float pointerDownPos;
    private bool switched = false;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    /// <summary>
    /// Use this when a user interacts with the switch. Switches up, waits for switchDelay, then switches down.
    /// </summary>
    /// <returns></returns>
    public IEnumerator ActivateSwitch()
    {
        SwitchUp();
        yield return new WaitForSeconds(switchDelay);
        SwitchDown();
    }

    private void SwitchUp()
    {
        switched = true;
        // Trigger event, set graphic.
        Trigger();
        OnSwitched.Invoke();
        image.sprite = switchUpGraphic;

    }
    private void SwitchDown()
    {
        switched = false;
        image.sprite = switchDownGraphic;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDownPos = eventData.position.y;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        float pointerUpPos = eventData.position.y;

        if (pointerUpPos - pointerDownPos > switchDistance && !switched)
        {
            StartCoroutine(ActivateSwitch());
        }
    }

    protected override void OnTriggered()
    {
        triggerCounter.text = Triggers.ToString();
    }
}
