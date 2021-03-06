using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    public Vector3 pointB;
    public float speed = 1;
    public GameObject[] endpoint;

    IEnumerator Start()
    {
        Vector3 pointA = transform.position;
        Vector3 pointB = new Vector3(endpoint[0].transform.position.x, transform.position.y, transform.position.z);
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3));
        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        float i = 0.0f;
        float rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }

}
