using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Tween
{
    private GameObject _gameObject;
    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private Vector3 _direction;

    private float _speed;
    private float _percent;

    private Func<float, float> _easeMethod;

    public Tween(GameObject objectToMove, Vector3 targetPosition, float speed, Func<float,float> easeMethod)
    {
        _gameObject = objectToMove;
        _targetPosition = targetPosition;
        _speed = speed;

        _startPosition = _gameObject.transform.position;
        _direction = _targetPosition - _startPosition;
        _percent = 0;

        _easeMethod = easeMethod;

        Debug.Log("Tween Started");
    }

    public void UpdateTween(float dt)
    {
        _percent += dt / _speed;

        if (_percent < 1)
        {
            float easeStep = _easeMethod(_percent);
            // virtual of abstracte class maken, die overerft van een base class
            _gameObject.transform.position = _startPosition + (_direction * easeStep);
            
            Debug.Log(_gameObject + ": Tween Update");
        }
        else
        {
            //TODO: deze print wordt elke frame aangeroepen. Moet ik nog fixen... Huiswerk??
            _gameObject.transform.position = _targetPosition;
            Debug.Log("Tween Finished!");
        }
    }
}