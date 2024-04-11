using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    [HideInInspector] public UnityEvent OnControlTriggered = new UnityEvent();

    [Header("Settings")]
    public int gameOverThreshold = 10;
    
    [Header("References")]
    public List<Control> controls;
    public GameCanvas canvas;


    // State for evaluating interactivity.
    public enum State { Playing, GameOver };
    public State state { private set; get; }

    private void Awake()
    {
        if(instance == null) instance = this;
        else
        {
            Destroy(instance.gameObject);
            instance = this;
        }

        OnControlTriggered.AddListener(EvaluateGameState);
    }

    private void Start()
    {
        state = State.Playing;
    }
    /// <summary>
    /// Total up all trigger counts on each control. If it passes the game's threshold, end game.
    /// </summary>
    private void EvaluateGameState()
    {
        int count = controls.Sum(x => x.Triggers);
        if (count >= gameOverThreshold) GameOver();
    }
    /// <summary>
    /// Triggers Game Over sequence
    /// </summary>
    private void GameOver()
    {
        StartCoroutine(CoGameOver());
    }
    private IEnumerator CoGameOver()
    {
        state = State.GameOver;
        canvas.gamePanel.blocksRaycasts = false;
        // Wait 1 second before popping up game over panel, just so player can see their trigger count reach the threshold value.
        yield return new WaitForSeconds(1.0f);
        canvas.PopupGameOverPanel();
    }
    /// <summary>
    /// Enable the game over panel.
    /// </summary>
    
    /// <summary>
    /// Reload the current scene.
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        canvas.Blackout();
    }
}
