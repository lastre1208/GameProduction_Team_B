using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [Header("表示させるテキスト")]
    [SerializeField] TMP_Text Score_UI;//表示させるテキスト
    [Header("表示したいスコア")]
    [SerializeField] Score score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score_UI.text = score.Score_.ToString("0");
    }
}
