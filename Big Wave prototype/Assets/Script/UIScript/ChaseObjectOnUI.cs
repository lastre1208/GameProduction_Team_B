using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseObjectOnUI : MonoBehaviour
{
    [Header("UI‚ª’Ç‚¢‚©‚¯‚é‘ÎÛ")]
    [SerializeField] Transform targetTfm;//UI‚ª’Ç‚¢‚©‚¯‚é‘ÎÛ
    private RectTransform myRectTfm;

    // Start is called before the first frame update
    void Start()
    {
        myRectTfm = GetComponent<RectTransform>();
    }

    void Update()
    {
        myRectTfm.position = RectTransformUtility.WorldToScreenPoint(Camera.main, targetTfm.position);
    }
}
