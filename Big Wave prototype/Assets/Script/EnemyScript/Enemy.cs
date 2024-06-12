using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

//™‰–‚ª‘‚¢‚½

class Enemy : MonoBehaviour
{
    [Header("¥“G‚ÌHP")]
    private float hp = 4000f;//“G‚ÌHP
    [Header("¥“G‚ÌÅ‘åHP")]
    [SerializeField] float hpMax = 4000f;//“G‚ÌÅ‘åHP
    SceneControlManager sceneControlManager;

    // Start is called before the first frame update
    void Start()
    {
        hp = hpMax;
        sceneControlManager= GameObject.FindWithTag("SceneManager").GetComponent<SceneControlManager>();
    }

    public float Hp
    {
        get { return  hp; }
        set { hp = value; }
    }

    public float HpMax
    {
        get { return hpMax; }
        set { hpMax = value; }
    }

    // Update is called once per frame
    void Update()
    {
        Dead();//“G€–SƒNƒŠƒAƒV[ƒ“‚ÉˆÚs
    }

    void Dead()//“G€–SƒNƒŠƒAƒV[ƒ“‚ÉˆÚs
    {
        if (hp <= 0)
        {
            sceneControlManager.ChangeClearScene();
        }
    }
    

    

    
}
