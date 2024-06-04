using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandTrick : MonoBehaviour
{
    public List<string> commandBuffer = new List<string>();
    public float bufferDuration = 1.0f;
    private float countTimer = 0;
    public List<CommandPatterns> commandPatterns; // インスペクターで設定するパターンのリスト
    private JumpControl jumpControl;
    // Update is called once per frame

    private void Start()
    {
        jumpControl = GetComponent<JumpControl>();
    }
    void Update()
    {
        // 入力を記録
        if (Input.GetButtonDown("Fire1")) AddInput("A");
        if (Input.GetButtonDown("Fire2")) AddInput("X");
        if (Input.GetButtonDown("Fire3")) AddInput("Y");
        if (Input.GetButtonDown("Fire4")) AddInput("B");

        // バッファの時間を更新
        countTimer += Time.deltaTime;
        if (countTimer > bufferDuration)
        {
            commandBuffer.Clear();
            countTimer = 0;
        }

        if (jumpControl.jumpNow)
        {
            CheckInputPatterns();
        }
        else
        {
            commandBuffer.Clear();
        }

                
       
    }

    void AddInput(string input)
    {
        commandBuffer.Add(input);
        countTimer = 0; // 新しい入力があったらタイマーをリセット
        Debug.Log(input);
    }

    void CheckInputPatterns()
    {

        string inputSequence = string.Join("", commandBuffer.ToArray());

        foreach (var pattern in commandPatterns)
        {
            string patternSequence = string.Join("", pattern.sequence.ToArray());
            if (inputSequence.Contains(patternSequence))
            {
                ExecutePattern(pattern.patternName);
                commandBuffer.Clear();
                break;
            }
        }
    }

    void ExecutePattern(string patternName)
    {
        switch (patternName)
        {
            case "UltimateAttack":
                PerformAttackCombo();
                break;
            case "SpeedUp":
                PerformDefenseCombo();
                break;
            case "PowerCharge":
                PerformSpecialMove();
                break;
            default:
                Debug.LogWarning("Unknown pattern: " + patternName);
                break;
        }
    }

    void PerformAttackCombo()
    {
        // AttackComboの処理をここに記述
        Debug.Log("なんかすっげぇダメージ与えるやつ～");
    }

    void PerformDefenseCombo()
    {
        // DefenseComboの処理をここに記述
        Debug.Log("一定時間スピートクソ早くなるやつ～");
    }

    void PerformSpecialMove()
    {
        // SpecialMoveの処理をここに記述
        Debug.Log("次の攻撃超強化～");
    }
}
