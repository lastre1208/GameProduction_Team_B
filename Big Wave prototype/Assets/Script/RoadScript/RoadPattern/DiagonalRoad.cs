using UnityEngine;

public class DiagonalRoad : RoadBase
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
            float rotationDirection = Mathf.Sign(diagonalLimit); // diagonalLimit‚Ì•„†‚ðŽæ“¾
            float newYRotation = currentYRotation + rotationDirection * diagonalNumber * Time.deltaTime ;

            target.transform.rotation = Quaternion.Euler(target.transform.eulerAngles.x, newYRotation, target.transform.eulerAngles.z);

            // diagonalLimit‚ÉŠî‚Ã‚¢‚ÄA“KØ‚È‰ñ“]’âŽ~ðŒ‚ðÝ’è
            if ((rotationDirection > 0 && newYRotation >= diagonalLimit) ||
                (rotationDirection < 0 && newYRotation <= diagonalLimit))
            {
                canDiagonal = false;
                Debug.Log("Reached diagonal limit");
            }
        }
    }

    public override void OnExit(RoadBase roadBases_Exit)
    {
        canDiagonal = true;
    }
}
