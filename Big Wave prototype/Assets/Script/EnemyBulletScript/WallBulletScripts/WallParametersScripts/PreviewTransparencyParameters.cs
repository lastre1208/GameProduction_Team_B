using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PreviewTransparencyParameters
{
    [Header("透明度が変化するサイクルの時間")]
    [SerializeField] float transparencyCycleDuration = 0.5f;

    public float TransparencyCycleDuration { get { return transparencyCycleDuration; } }
}