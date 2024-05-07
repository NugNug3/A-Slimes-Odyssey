using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] List<Transform> elevatorPoints;
    [SerializeField] float moveTime = 5f;

    [SerializeField] int index = 0;

    void Start()
    {
        Move();
    }
    void Move()
    {
        StartCoroutine(MoveRoutine());
        IEnumerator MoveRoutine()
        {
            while(true)
            {
                yield return new WaitForSeconds(2f);

                float timer = 0;
                int nextIndex = (index + 1) % elevatorPoints.Count;
                while(timer < moveTime)
                {
                    yield return null;
                    timer += Time.deltaTime;

                    transform.position = Vector3.Lerp(elevatorPoints[index].position, elevatorPoints[nextIndex].position, timer / moveTime);
                }
                transform.position = elevatorPoints[nextIndex].position;
                index = nextIndex;
            }
        }
    }
}
