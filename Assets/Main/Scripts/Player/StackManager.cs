using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public static StackManager instance;

    [SerializeField] [Range(0, 1)] private float distanceBetweenStacks;
    [SerializeField] private Vector3 scaleOfStack;
    [SerializeField] private Transform parentObj;
    [SerializeField] private Transform prevObj;
    private Transform firstPos;

    private List<GameObject> stacks;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        firstPos = prevObj;
        distanceBetweenStacks += distanceBetweenStacks + prevObj.localScale.y;
        stacks = new List<GameObject>();
    }

    public void PickUp(GameObject pickObject, bool needTag = false, string tag = null, bool downOrUp = true)
    {
        if (needTag)
            pickObject.tag = tag;

        stacks.Add(pickObject);

        pickObject.GetComponent<DollarRotateAround>().enabled = false;
        pickObject.GetComponent<DollarUpDown>().enabled = false;

        pickObject.transform.parent = parentObj;
        Vector3 desPos = prevObj.localPosition;
        desPos.y += downOrUp ? distanceBetweenStacks : -distanceBetweenStacks;

        pickObject.transform.localPosition = desPos;
        pickObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        pickObject.transform.localScale = scaleOfStack;

        prevObj = pickObject.transform;
    }

    public void LeaveUp(GameObject pickObject)
    {
        pickObject.SetActive(false);

        if (stacks.Count != 0)
        {
            stacks[stacks.Count - 1].transform.parent = null;
            stacks[stacks.Count - 1].transform.position = new Vector3(transform.position.x, 0.05f, transform.position.z);

            stacks.Remove(stacks[stacks.Count -1]);

            if (stacks.Count == 0)
                prevObj = firstPos;
            else
                prevObj = stacks[stacks.Count - 1].transform;
        }
    }
}