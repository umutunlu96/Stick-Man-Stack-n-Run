using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovementControl : MonoBehaviour
{
    [SerializeField] private float speed = 2;

    [SerializeField] private float rotationSpeed = 5;

    [SerializeField] private Vector2 movementLimit = Vector2.one;

    private static float z;

    private bool _canMove = false;
    private bool isFinished = false;

    private Vector2 _direction = Vector2.zero;

    private PAnimationControl animationController = null;

    private void Awake()
    {
        animationController = GetComponent<PAnimationControl>();
    }


    private void FixedUpdate()
    {
        if (!isFinished)
        {
            if (CanMove())
            {
                HandleMovement();

                if (Mathf.Abs(_direction.x * speed) > .45f)
                    HandleRotation(_direction.x, _direction.y);
                else
                    HandleRotation(0, 0);
            }
            else
                HandleRotation(0, 0);

            ValidateLocation();
        }
    }

    private void HandleMovement()
    {
        if (Mathf.Abs(_direction.x * speed) >= .45f)
        {
            HandleDirection(1);
        }
        else
            HandleDirection(0);
    }

    private void HandleDirection(float deadZone)    // 0 means no movement on X axis 1 means player can move.
    {
        var direction = new Vector3(_direction.x * speed * deadZone, 0, speed);
        transform.position += direction * Time.fixedDeltaTime;
    }

    private void HandleRotation(float xAngle, float yAngle)
    {
        var currRotation = transform.rotation;

        var targetRotation = Quaternion.Euler(new Vector3(0, Mathf.Atan2(xAngle, yAngle) * 90 / Mathf.PI, 0));

        transform.rotation = Quaternion.Lerp(currRotation, targetRotation, Time.fixedDeltaTime * rotationSpeed);
    }

    public void StopMovement()
    {
        _canMove = false;
    }

    private void FinishState()
    {
        isFinished = true;
    }

    private bool CanMove()
    {
        return _canMove;
    }

    private void OnDragged(Vector2 direction)
    {
        _canMove = true;
        _direction = direction;
        if(!isFinished)
            animationController.StartRunAnimation();
    }

    private void OnReleased()
    {
        _canMove = false;
        _direction = Vector2.zero;
        if(!isFinished)
            animationController.StartIdleAnimation();
    }

    private void OnPressed()
    {
        // TODO
    }


    private void ValidateLocation()
    {
        var currentLocation = transform.position;

        if (currentLocation.x >= movementLimit.y)
        {
            currentLocation.x = movementLimit.y;

            _direction = Vector2.zero;
        }

        else if (currentLocation.x <= movementLimit.x)
        {
            currentLocation.x = movementLimit.x;

            _direction = Vector2.zero;
        }

        transform.position = currentLocation;
        z = transform.position.z;
    }

    public static float GetZ()
    {
        return z;
    }

    private void OnEnable()
    {
        Joystick.OnJoystickDrag += OnDragged;
        Joystick.OnJoystickPress += OnPressed;
        Joystick.OnJoystickRelease += OnReleased;
        PStackTrigger.OnFinish += FinishState;
    }

    private void OnDisable()
    {
        Joystick.OnJoystickDrag -= OnDragged;
        Joystick.OnJoystickPress -= OnPressed;
        Joystick.OnJoystickRelease -= OnReleased;
        PStackTrigger.OnFinish -= FinishState;
    }
}
