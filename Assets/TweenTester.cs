using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenTester : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed;
    public EasingTypes methodeType; //maak variabel voor de enum
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TweenMachine.GetInstance().MoveGameObject(gameObject, targetPosition, speed, methodeType);
            Debug.Log("De Tween begint");
        }
    }

}
