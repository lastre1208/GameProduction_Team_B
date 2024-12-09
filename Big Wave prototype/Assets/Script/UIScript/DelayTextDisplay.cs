using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DelayTextDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text _text;
    [SerializeField] float _delay;
    [SerializeField] AudioSource _audio;
    [SerializeField] AudioClip _clip;
    private string _delayText;
    // Start is called before the first frame update
    void Start()
    {
        _delayText = _text.text;
        _text.text = "";
        StartCoroutine(DelayDisplay());
    }

   IEnumerator DelayDisplay()
    {

        bool isInsideTag = false; // タグ部分をスキップするためのフラグ
        string currentText = "";

        foreach (char c in _delayText)
        {

            if (c == '<') // タグの開始
            {
                isInsideTag = true;
                currentText += c; // タグも一緒に蓄積
            }
            else if (c == '>') // タグの終了
            {
                isInsideTag = false;
                currentText += c; // タグを完成させる
            }
            else if (isInsideTag)
            {
                currentText += c; // タグ内の文字をそのまま蓄積
            }
            else
            {
                currentText += c; // 通常の文字を追加
                _text.text = currentText; // 表示を更新

                yield return new WaitForSeconds(_delay);
                if (c != ' ' && c != '!')
                {
                    if (_audio != null)
                    {
                        _audio.PlayOneShot(_clip);
                    }

                }

            }
        }
    }
   
}
