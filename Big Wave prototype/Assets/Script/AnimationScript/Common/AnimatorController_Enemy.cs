using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AnimatorController_Enemy : MonoBehaviour
{
    [SerializeField] Animator anim;

    public void AnimControl_Trigger(string animName)//triggerタイプのアニメーション変更
    {
        if(!(animName==""))
        {
            anim?.SetTrigger(animName);
        }
    }

    public void AnimControl_Bool(string animName,bool animBool)//boolタイプのアニメーション変更
    {
        if (!(animName == ""))
        {
            anim?.SetBool(animName, animBool);
        }
    }
}
