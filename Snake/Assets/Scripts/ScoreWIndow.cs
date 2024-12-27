using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    private Text scoreText;
    // Start is called before the first frame update
    private void Awake()
    {
        scoreText = transform.Find("scoreText").GetComponent<Text>();
    }
    private void Update()
    {
        scoreText.text = GameHandler.GetScore().ToString();
    }
}
