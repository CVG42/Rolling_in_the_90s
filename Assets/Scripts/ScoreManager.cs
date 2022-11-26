using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int _score;
    public TextMeshProUGUI scoreDisplay;
    void Start()
    {
        _score = 42;
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = _score.ToString();
    }
}
