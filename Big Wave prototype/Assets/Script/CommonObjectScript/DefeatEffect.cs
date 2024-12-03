using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:福島
//
[System.Serializable]
public class DefeatEffect : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [Header("●爆発(小)の設定項目")]
    [SerializeField] Explosion _shortExp;
    [Header("爆発(小)の生成間隔")]
    [SerializeField] float _boom_s_Interval;
    [Header("爆発(小)を生成する範囲")]
    [SerializeField] Limit Boom;
    [Header("Z座標のズレ(小爆発)")]
    [SerializeField] float _boom_s_Offset;
    [Header("●爆発(大)の設定項目")]
    [SerializeField] Explosion _largeExp;
    [Header("何秒後に大爆発するか")]
    [SerializeField] float _boomTime;
    [Header("Y座標のズレ(大爆発)")]
    [SerializeField] float _boom_l_Offset;
    bool boomed = false;
    float countTime;
    int countSmoke = 1;
    private List<GameObject> Effects = new();
   
    public void GenerateDefeatEffect()
    {

        countTime += Time.deltaTime;
        if (countTime > _boom_s_Interval * countSmoke && !boomed)
        {
            countSmoke += 1;
            Vector3 randomPosition = new Vector3(_shortExp._genePos.position.x
                + (Random.Range(Boom.Min_x, Boom.Max_x)), _shortExp._genePos.position.y
                + (Random.Range(Boom.Min_y, Boom.Max_y)), _shortExp._genePos.position.z + _boom_s_Offset);

            GameObject Effect = Instantiate(_shortExp._expObj, randomPosition, Quaternion.identity, _shortExp._genePos);
            _audioSource.PlayOneShot(_shortExp._boomSE);
            Effects.Add(Effect);
        }
        else if (countTime > _boomTime && !boomed)//一回だけ呼ぶ
        {
            DestroySmoke();
            Vector3 expPosition = new Vector3(_largeExp._genePos.position.x, _largeExp._genePos.position.y + _boom_l_Offset, _largeExp._genePos.position.z);
            Instantiate(_largeExp._expObj, expPosition, Quaternion.identity, _largeExp._genePos);
            _audioSource.PlayOneShot(_largeExp._boomSE);
            boomed = true;
        }
    }

    void DestroySmoke()
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

    //生成範囲
    [System.Serializable]
    struct Limit
    {
        public float Max_x;
        public float Max_y;
        public float Min_x;
        public float Min_y;
    }

    //爆発の設定項目
    [System.Serializable]
    struct Explosion
    {
        public Transform _genePos;//発生位置
        public GameObject _expObj;//生成するエフェクト
        public AudioClip _boomSE;//再生させる音
    }

}
