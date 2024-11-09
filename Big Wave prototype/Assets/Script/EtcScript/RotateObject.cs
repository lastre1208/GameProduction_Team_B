using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    [SerializeField] float minSpeed;
    private Vector3 rotationDirection;
    private float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotationDirection = new(0, Random.value > 0.5f ? 1 : -1, 0);//ランダムで時計回り、反時計回りを指定
        rotationSpeed=Random.Range(minSpeed,maxSpeed );
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationDirection*rotationSpeed*Time.deltaTime);
    }
}
