using UnityEngine;

public class Diagonal : PathBase
{
    
    [SerializeField] private float diagonalNumber;
    [SerializeField] private float diagonalLimit;
    [SerializeField] private GameObject target;
    private bool canDiagonal = true;

    public override void OnUpdate()
    {
        if (canDiagonal)
        {
            float currentYRotation = target.transform.eulerAngles.y;
            if (currentYRotation > 180f) currentYRotation -= 360f;
            float rotationDirection = Mathf.Sign(diagonalLimit); // diagonalLimitの符号を取得
            float newYRotation = currentYRotation + rotationDirection * diagonalNumber * Time.deltaTime ;

            target.transform.rotation = Quaternion.Euler(target.transform.eulerAngles.x, newYRotation, target.transform.eulerAngles.z);

            // diagonalLimitに基づいて、適切な回転停止条件を設定
            if ((rotationDirection > 0 && newYRotation >= diagonalLimit) ||
                (rotationDirection < 0 && newYRotation <= diagonalLimit))
            {
                canDiagonal = false;
              //  Debug.Log("Reached diagonal limit");
            }
        }
    }

    public override void OnExit(PathBase roadBases_Exit)
    {
        canDiagonal = true;
    }
}
