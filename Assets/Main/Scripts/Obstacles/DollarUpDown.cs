using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollarUpDown : MonoBehaviour
{
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float speed;
    private Vector3 startPos;
    private bool moveUp = true;

    private void Start()
    {
        startPos = transform.position;
        targetPosition.x = transform.position.x;
        targetPosition.y = transform.position.y + targetPosition.y;
        targetPosition.z = transform.position.z;
    }

    private void Update()
    {
        LerpPosition();
    }


    private void LerpPosition()
    {
        if (moveUp)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            if (transform.position.y >= targetPosition.y)
                moveUp = false;
        }

        else
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
            if (transform.position.y <= startPos.y)
                moveUp = true;
        }
    }
}
