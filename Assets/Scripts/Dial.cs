using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple togglable rotating image script.
/// </summary>
public class Dial : MonoBehaviour
{
    [Header("Settings")]
    public float rotationSpeed = 5;
    [Header("References")]
    public Transform dialPivot;

    private int direction = -1;
    private bool rotating = false;

    public void ToggleRotation()
    {
        SetRotationState(!rotating);
    }
    public void ToggleRotationDirection()
    {
        direction *= -1;
    }

    private void SetRotationState(bool cond)
    {
        rotating = cond;
    }

    private void Update()
    {
        if(rotating)
        {
            dialPivot.localEulerAngles += new Vector3(0, 0, direction * rotationSpeed * Time.deltaTime);
        }
    }

}
