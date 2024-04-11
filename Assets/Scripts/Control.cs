using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract base class for all interactive controls in the game. Contains functionality for tallying up the number of times this control has been triggered.
/// </summary>
public abstract class Control : MonoBehaviour
{
    public int Triggers => triggers;
    private int triggers = 0;

    protected void Trigger()
    {
        if (GameManager.instance.state != GameManager.State.Playing) return;
        triggers++;
        OnTriggered();
        GameManager.instance.OnControlTriggered.Invoke();
    }

    /// <summary>
    /// Callback for when a control is triggered. Most of the times this will just update a text display.
    /// </summary>
    protected abstract void OnTriggered();
}
