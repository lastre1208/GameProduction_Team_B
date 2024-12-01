using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [Header("’e‚Ì“®‚­•ûŒü(0‚©1‚Ì‚Ý“ü—Í‚µ‚Ä‚­‚¾‚³‚¢)")]
    [SerializeField] Vector3 Direction;
    [Header("’e‚Ì“®‚­ƒXƒs[ƒh")]
    [SerializeField] float moveSpeed;
    [Header("”½“]‚·‚é‚©‚Ç‚¤‚©")]
    [SerializeField] bool directionTurn;
    [Header("”½“]‚·‚éƒ^ƒCƒ~ƒ“ƒO")]
    [SerializeField] float timingTurn;
    float countTime;
    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        if (directionTurn && countTime > timingTurn)
        {
            countTime = 0;
            Direction = -Direction;
        }
        transform.position += Direction * moveSpeed * Time.deltaTime;
    }
}
