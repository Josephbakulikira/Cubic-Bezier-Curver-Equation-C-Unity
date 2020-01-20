using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierFormula : MonoBehaviour
{
    [SerializeField] Transform[] targetPositions;
    Vector2 pos;
    private void OnDrawGizmos()
    {
        for (float t = 0; t <= 1; t += 0.05f)
        {
            Gizmos.color = Color.white;

            pos = Mathf.Pow(1 - t, 3) * targetPositions[0].position + 3 *
                Mathf.Pow(1 - t, 2) * t * targetPositions[1].position +
                3 * (1 - t) * Mathf.Pow(t, 2) * targetPositions[2].position +
                Mathf.Pow(t, 3) * targetPositions[3].position;
            Gizmos.DrawSphere(pos, 0.2f);
            
        }

        Gizmos.DrawLine(new Vector2(targetPositions[0].position.x, targetPositions[0].position.y),
                new Vector2(targetPositions[1].position.x, targetPositions[1].position.y)
            );
        Gizmos.DrawLine(new Vector2(targetPositions[2].position.x, targetPositions[2].position.y),
            new Vector2(targetPositions[3].position.x, targetPositions[3].position.y));
    }
}
