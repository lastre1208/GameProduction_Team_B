using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;
public class DelayTextDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text _text;
    [SerializeField] float _delay;
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
        foreach(char c in _delayText)
        {
            _text.text += c;
            yield return new WaitForSeconds(_delay);
        }
    }
   
}
