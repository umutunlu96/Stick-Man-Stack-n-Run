using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollarRotateAround : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed, Space.World);
    }
}
