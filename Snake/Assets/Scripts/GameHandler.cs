using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
using TMPro;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private Snake snake;
    private static GameHandler instance;
    private static int score;
    private LevelGrid levelGrid;

    private void Awake()
    {
        instance = this;
        InitializeStatic();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log("GameHandler.Start");
        levelGrid = new LevelGrid(20, 20);
        snake.Setup(levelGrid);
        levelGrid.Setup(snake);

        /*CMDebug.ButtonUI(Vector2.zero, "Reload Scene", () =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });*/
        
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (IsGamePaused())
            {
                GameHandler.ResumeGame();

            }
            else
            {
                GameHandler.PauseGame();
            }
            
        }
    }
    public static int GetScore()
    {
        return score;
    }
    public static void AddScore()
    {
        score += 100;
    }

    private static void InitializeStatic()
    {
        score = 0;

    }

    public static void SnakeDied()
    {
        GameOverWindow.ShowStatic();
    }

    public static void ResumeGame()
    {
        PauseWindow.HideStatic();
        Time.timeScale = 1f;


    }
    public static void PauseGame()
    {
        PauseWindow.ShowStatic();
        Time.timeScale = 0f;
    }
    public static bool IsGamePaused()
    {
        return Time.timeScale == 0f;
    }

}
