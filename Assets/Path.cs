using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private Transform[] path;
    private int pathIndex;
    private bool freeToGo;
    private float parameter;
   
    private float speed ;
    private Vector2 player_position;

    private void Start()
    {
        freeToGo = true;
        pathIndex = 0;
        parameter = 0;
        speed = 0.5f;
    }
    private void Update()
    {
        if (freeToGo)
            StartCoroutine(bezierCurves(pathIndex));

    }
    IEnumerator bezierCurves(int _index)
    {
        freeToGo = false; 

       Vector2 P0 = path[_index].GetChild(0).position;
       Vector2 P1 = path[_index].GetChild(1).position;
       Vector2 P2 = path[_index].GetChild(2).position;
       Vector2 P3 = path[_index].GetChild(3).position;

        while (parameter < 1) 
        {
            parameter += speed * Time.deltaTime;

            player_position = Mathf.Pow(1 - parameter, 3) * P0 +
                3 * Mathf.Pow(1 - parameter, 2) * parameter * P1 +
                3 * (1 - parameter) * Mathf.Pow(parameter, 2) * P2 +
                Mathf.Pow(parameter, 3) * P3;

            transform.position = player_position;
            yield return new WaitForEndOfFrame();
        }
        parameter = 0;
        pathIndex += 1;

        if (pathIndex > path.Length - 1) 
        {
            pathIndex = 0;
        }
        freeToGo = true;
    }
}
