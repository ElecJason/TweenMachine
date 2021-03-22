using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TweenMachine : MonoBehaviour
{
    private static TweenMachine instance;
    private List<Tween> _activeTweens = new List<Tween>();
    private Dictionary<EasingTypes, Func<float, float>> easingCombiner = new Dictionary<EasingTypes, Func<float, float>>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            this.enabled = false;
            Debug.LogWarning("Only 1 Tweenmachine");
            return;
        }

        easingCombiner.Add(EasingTypes.EaseInQuad, Easings.EaseInQuad);
        easingCombiner.Add(EasingTypes.EaseOutQuad, Easings.EaseOutQuad);
        easingCombiner.Add(EasingTypes.EaseInQuint, Easings.EaseInQuint);
    }

    private void Update()
    {
        if (_activeTweens.Count < 1) return;

        for (int i = 0; i < _activeTweens.Count; i++)
        {
            _activeTweens[i].UpdateTween(Time.deltaTime);
        }
    }

    public static TweenMachine GetInstance()
    {
        return instance;
    }

    public void MoveGameObject(GameObject objectMove, Vector3 targetPos, float speed, EasingTypes type)
    {
        Tween newTween = new Tween(objectMove, targetPos, speed, easingCombiner[type]);
        Debug.Log("Voeg een tween toe");
        _activeTweens.Add(newTween);
    }
}
