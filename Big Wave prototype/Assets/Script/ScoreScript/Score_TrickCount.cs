using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_TrickCount : MonoBehaviour
{
    [Header("トリック一回ごとのスコア量")]
    [SerializeField] float scorePerOneTrick;//トリック一回ごとのスコア量
    private static float score;//トリック回数のスコア
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void AddScore()//スコア加算(1回トリックをするごとに呼ぶ)
    {
        score += scorePerOneTrick;
    }
}
