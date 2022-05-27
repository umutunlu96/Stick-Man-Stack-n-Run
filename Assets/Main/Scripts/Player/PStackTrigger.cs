using System;
using UnityEngine;

public class PStackTrigger : MonoBehaviour
{
    public static PStackTrigger instance;

    public static Action<int> OnDollerPicked;
    public static Action OnFinish;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Pick")
        {
            StackManager.instance.PickUp(target.gameObject, true, "Untagged");
            OnDollerPicked?.Invoke(1);
        }

        else if (target.tag == "Obstacles")
        {
            StackManager.instance.LeaveUp(target.gameObject);
            OnDollerPicked?.Invoke(-1);
        }

        else if (target.tag == "Finish")
        {
            PStateControl.instance.playerState = PStateControl.PlayerState.finish;
            OnFinish?.Invoke();
        }
    }
}