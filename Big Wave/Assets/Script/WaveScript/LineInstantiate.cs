using System.Collections.Generic;
using UnityEngine;

public class LineInstantiate : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    private Queue<Transform> points = new Queue<Transform>();

    private void Update()
    {
        ReflectLineRenderer();
    }

    //ü¶¬ˆÊ’u‚Ì’Ç‰Á

    public void Add(Transform point)
    {
        points.Enqueue(point);
    }

    //ü¶¬ˆÊ’u‚Ìíœ
    public void Remove()
    {
        points.Dequeue();
    }

    void ReflectLineRenderer()// LineRenderer‚É”½‰f
    {
        int index = 0;
        lineRenderer.positionCount = points.Count;
        foreach (Transform point in points)
        {
            lineRenderer.SetPosition(index, point.position);
            index++;
        }
    }

    //public void LineSet(Transform transform)
    //{
    //    //    Transform newposition = transform;
    //    //    // V‚µ‚¢“_‚ð’Ç‰Á
    //    //    points.Enqueue(newposition);
    //    //if(points.Count > pointNumber)
    //    //{
    //    //    points.Dequeue();
    //    //}
    //    //    // LineRenderer‚É”½‰f
    //    //    lineRenderer.positionCount = points.Count;
    //    //    int index = 0;
    //    //    foreach (Transform point in points)
    //    //    {
    //    //        lineRenderer.SetPosition(index, point.position);
    //    //        index++;
    //    //    }
        
    //}
}