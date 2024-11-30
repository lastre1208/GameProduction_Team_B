using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ì¬ŽÒ:™ŽR
//“G‚ÌŽ€–Sƒ‚[ƒVƒ‡ƒ“
//”•bƒ‚[ƒVƒ‡ƒ“‚³‚¹‚½ŒãA”š”­‚³‚¹‚Äƒ‚ƒfƒ‹‚Ì•û‚ð”ñ•\Ž¦‚É‚·‚é
public class EnemyDeadMotion : MonoBehaviour
{
    [SerializeField] Animator _enemy_animator;
    [SerializeField] string _deadTriggerName;
    [Header("“G‚Ìƒ‚ƒfƒ‹")]
    [SerializeField] HideObject _enemy;
    [Header("…‚µ‚Ô‚«")]
    [SerializeField] HideObject _waterSplash;
    bool _startMotion=false;

    public void Trigger()
    {
        _enemy_animator.SetTrigger(_deadTriggerName);
        _startMotion = true;
    }

    void Update()
    {
        _enemy.UpdateDeleteTime(_startMotion);
        _waterSplash.UpdateDeleteTime(_startMotion);
    }



    [System.Serializable]
    class HideObject
    {
        [SerializeField] GameObject _hideObject;
        [Header("‰½•bŒã‚ÉÁ‚·‚©")]
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
}


