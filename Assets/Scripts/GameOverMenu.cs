using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject engine;
    [SerializeField] TextMeshProUGUI TimerTextGO;
    [SerializeField] TextMeshProUGUI TimerText;

    void Start()
    {
        
    }

    void Update()
    {
        scoreText.text = engine.GetComponent<Engine>().score.ToString();
        TimerTextGO.text = TimerText.text;
    }
}
