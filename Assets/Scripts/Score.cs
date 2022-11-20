using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    [SerializeField] Text scoreText;
    public int score;

    public bool canPickScore = true;

    void Start()
    {
        score = 0;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ScoreTrigger" && canPickScore == true)
        {
            score++;
            scoreText.text = score.ToString();
        }
    }
}
