using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBoxController : MonoBehaviour
{
    [SerializeField] GameObject moneyPrefab;
    [SerializeField] private float distanceBetweenObjects;
    [SerializeField] private Transform prevObj;
    [SerializeField] private Transform parent;

    ScoreManager scoreManager;
    private int stackCount;

    public static Action OnStacksComplete;


    private void Start()
    {
        scoreManager = ScoreManager.instance;
    }



    void StartStack()
    {
        stackCount = scoreManager.Score;

        StartCoroutine(StackUp());
    }

    private IEnumerator StackUp()
    {
        yield return new WaitForSeconds(.5f);

        for (int i = stackCount; i > 0; i--)
        {
            GameObject obj = Instantiate(moneyPrefab, prevObj);
            obj.transform.parent = parent;

            Vector3 desPos = prevObj.localPosition;
            desPos.y -= distanceBetweenObjects;
            obj.transform.localPosition = desPos;
            prevObj = obj.transform;

            parent.transform.position += Vector3.up * .5f;

            yield return new WaitForSeconds(.2f);
        }

        yield return new WaitForSeconds(1);

        OnStacksComplete?.Invoke();
    }

    private void OnEnable()
    {
        PStackTrigger.OnFinish += StartStack;
    }

    private void OnDisable()
    {
        PStackTrigger.OnFinish -= StartStack;
    }
}