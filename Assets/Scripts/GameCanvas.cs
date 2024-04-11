using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    [Header("References")]
    public CanvasGroup gamePanel;
    public GameObject gameOverPanel;
    public GameObject blackout;
    public void PopupGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    public void Blackout()
    {
        blackout.gameObject.SetActive(true);
    }
}
