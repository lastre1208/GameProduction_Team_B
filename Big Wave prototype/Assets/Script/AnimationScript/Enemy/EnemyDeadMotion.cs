using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//敵の死亡モーション
//数秒モーションさせた後、爆発させてモデルの方を非表示にする
public class EnemyDeadMotion : MonoBehaviour
{
    [SerializeField] Animator _enemy_animator;
    [SerializeField] string _deadTriggerName;
    [Header("敵のモデル")]
    [SerializeField] HideObject _enemy;
    [Header("水しぶき")]
    [SerializeField] HideObject _waterSplash;
    [Header("撃破時に生成するエフェクト")]
    [SerializeField] DefeatEffect _defeatEffect;
    bool _startMotion = false;

    public void Trigger()
    {
        _defeatEffect.DefeatStart();
        _enemy_animator.SetTrigger(_deadTriggerName);
        _startMotion = true;
       
    }

    void Update()
    { 
        _defeatEffect.GenerateDefeatEffect();
        _enemy.UpdateDeleteTime(_startMotion);
        _waterSplash.UpdateDeleteTime(_startMotion);

    }



    [System.Serializable]
    class HideObject
    {
        [SerializeField] GameObject _hideObject;
        [Header("何秒後に消すか")]
        [SerializeField] float _hideTime;
        float _currentDeleteTime = 0;

        public void UpdateDeleteTime(bool start)
        {
            if (!start) return;

            _currentDeleteTime += Time.deltaTime;

            if (_currentDeleteTime >= _hideTime)
            {
                _hideObject.SetActive(false);
            }
        }
    } 
   
    [System.Serializable]
    class DefeatEffect
    {
        [Header("煙を発生させる位置")]
        [SerializeField] Transform _defeatObject;
        [Header("爆発を発生させる位置")]
        [SerializeField] Transform _expObject;
        [Header("生成するエフェクト(煙)")]
        [SerializeField] GameObject _defeatSmoke;
        [Header("煙の生成間隔")]
        [SerializeField] float _smokeInterval;
        [Header("煙を生成する範囲")]
        [SerializeField] Limit Smoke;
        [Header("生成するエフェクト(爆発)")]
        [SerializeField] GameObject _defeatBoom;
        [Header("何秒後に爆発するか")]
        [SerializeField] float _boomTime;
        [Header("Y座標のズレ")]
        [SerializeField] float _boomOffset;
        bool judgeDefeat = false;
        bool boomed=false;
        float countTime;
        int countSmoke = 1;
        private List<GameObject> Effects=new();
        [System.Serializable]
        public struct Limit
        {
            public float Max_x;
            public float Max_y;
            public float Min_x;
            public float Min_y;
        }
        public void GenerateDefeatEffect()
        {
            if (!judgeDefeat) return;
            
                countTime += Time.deltaTime;
                if (countTime > _smokeInterval * countSmoke )
                {
                    countSmoke += 1;
                    Vector3 randomPosition = new Vector3(_defeatObject.transform.position.x+(Random.Range(Smoke.Min_x, Smoke.Max_x)),_defeatObject.transform.position.y+( Random.Range(Smoke.Min_y, Smoke.Max_y)), _defeatObject.transform.position.z);

                    GameObject Effect = Instantiate(_defeatSmoke, randomPosition, Quaternion.Euler(-90f, 0f, 0f), _defeatObject.transform);
                Effects.Add(Effect);
                }
                else if (countTime>_boomTime&&!boomed)//一回だけ呼ぶ
                {
                DestroySmoke();
                Vector3 expPosition = new Vector3(_expObject.transform.position.x, _expObject.transform.position.y + _boomOffset, _expObject.transform.position.z);
                Instantiate(_defeatBoom, expPosition,Quaternion.identity,_expObject.transform);
                   boomed = true;
                }
            
        }
      public void DefeatStart()
        {
            judgeDefeat = true;
        }
        public void DestroySmoke()
        {
            foreach (var Smoke in Effects)
            {
                if (Smoke != null)
                {
                    Destroy(Smoke);
                }
              
            }
            Effects.Clear();
        }
    }
   
}


