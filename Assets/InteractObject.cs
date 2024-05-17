using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    [SerializeField]
    private Collider _collider;

    /// <summary>
    /// 
    /// </summary>
    private Action _onEnter;

    /// <summary>
    /// 
    /// </summary>
    private Action _onExit;


    public void SetAction(Action onEnter, Action onExit)
    {
        _onEnter = onEnter;
        _onExit = onExit;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        _onEnter?.Invoke();
    }


    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        _onExit?.Invoke();
    }
}
