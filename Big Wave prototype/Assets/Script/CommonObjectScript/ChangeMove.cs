using UnityEngine;

public class PingPongVertical : MonoBehaviour
{
    // ‰•œ‚·‚é’·‚³
    [SerializeField] private float _length = 50;
    public float speed = 10;
    private void Update()
    {
        // ‰•œ‚µ‚½’l‚ğŠÔ‚©‚çŒvZ
        var value = Mathf.PingPong(Time.time*speed, _length) - _length / 2; ;

        // yÀ•W‚ğ‰•œ‚³‚¹‚Äã‰º‰^“®‚³‚¹‚é
        transform.Translate(Vector3.right * value * Time.deltaTime);
    }
}