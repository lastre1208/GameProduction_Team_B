using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//登録したものの中から確率で返す(型指定可能)
[System.Serializable]
public partial class ProbabilityGet<T>
{
    [SerializeField] Element_ProbabilityGet[] elements;
    float probabilitySum=0;//登録された要素たちの確率合計
    const float errorProbabilitySum = 0;//確率合計がこの値以下だと何も設定されてない判定にする

    public T this[int i]
    {
        get { return elements[i].Element; }
    }

    public int ElementsNum { get { return elements.Length; } }//要素数を返す

    public ProbabilityGet()//コンストラクタ
    {

    }

    public void Start()//Get使用前に1回は必ず呼ぶ
    {
        //確率の合計を算出
        for(int i=0; i<elements.Length;i++)
        {
            probabilitySum += elements[i].Probability;
        }
    }

    //呼ばれると確率で返す
    public T Get()
    {
        if (elements == null||probabilitySum<= errorProbabilitySum)//何も登録されていなかった場合
        {
            Debug.Log("何も設定されていません");
            return default(T);
        }

        //選出方法
        //1...0～全ての要素の確率合計からランダムで値を出す
        //2...要素番号が0の要素から順に確率の値を足していき
        //3...その合計がランダムで出した値以上になったらついさっき確率の値を足した要素を返す
        
        float randomNum= Random.Range(0f, probabilitySum);//1番で説明したランダムの値

        float searchProbabilitySum = 0;//2番で確率の値を足していく変数

        //どの要素を返すかを決定する処理
        for(int i=0;i< elements.Length; i++)
        {
            searchProbabilitySum += elements[i].Probability;

            if(randomNum<=searchProbabilitySum)//3番で説明した通り
            {
                return elements[i].Element;
            }
        }

        //想定外の時用(普通は起こらないので以下の処理が呼ばれることはないはず)
        Debug.Log("エラー");
        return default(T);

    }
}
