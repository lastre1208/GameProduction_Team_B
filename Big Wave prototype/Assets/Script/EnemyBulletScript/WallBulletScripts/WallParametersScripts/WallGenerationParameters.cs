using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WallGenerationParameters
{
    [Header("¶¬‚·‚é•Ç‚Ì‰¡‚Ì•ªŠ„”")]
    [SerializeField] int width = 3;
    [Header("¶¬‚·‚é•Ç‚Ìc‚Ì•ªŠ„”")]
    [SerializeField] int height = 3;
    [Header("•Ç‚ÌÅ‘å¶¬–‡”")]
    [SerializeField] int generateWallsNum = 6;
    [Header("‚»‚ê‚¼‚ê‚Ì•Ç‚ª¶¬‚³‚ê‚éŠm—¦")]
    [SerializeField] float generationProbability = 0.8f;
    [Header("•Çˆê–‡‚²‚Æ‚ÌoŒ»ŠÔŠu")]
    [SerializeField] float intervalActiveTime = 0.2f;
    [Header("¶¬”ÍˆÍ‚ğƒQ[ƒ€‰æ–Ê‚É‡‚í‚¹‚é‚©‚Ç‚¤‚©")]
    [SerializeField] bool matchCameraSize = true;

    public int Width { get { return width; } }
    public int Height { get { return height; } }
    public int GenerateWallsNum { get { return generateWallsNum; } }
    public float GenerationProbability { get { return generationProbability; } }
    public float IntervalActiveTime { get { return intervalActiveTime; } }
    public bool MatchCameraSize { get { return matchCameraSize; } }
}