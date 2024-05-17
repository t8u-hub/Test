using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Gene.Core;
using Gene.CommonUI;
using Gene.Define;

/// <summary>
/// TODO tanaka_yuka インターバルで押せるようになるとかは別クラス
/// SelectListController　ちょっと検討
/// </summary>
public class Test : MonoBehaviour
{
    private const float INTERVAL_TIME = .2f;

    [SerializeField]
    private SelectList _selectList;

    [SerializeField]
    private InteractObject[] _interactObjectArray;

    [SerializeField]
    private SelectButtonItem _battleButton;


    [SerializeField]
    private SelectButtonItem _dispenseButton;

    GamepadInput _input;

    private float _intervalTime;

    private ArrowKeyAxis? _prevInputAxis = null;


    // Start is called before the first frame update
    void Start()
    {
        _input = new GamepadInput();
        _selectList.SelectItem(0);
        _selectList.RemoveCursor();
        _selectList.gameObject.SetActive(false);
  
        foreach (var interactObject in _interactObjectArray)
        {
            interactObject.SetAction(ShowUi, HideUi);
        }

        _battleButton.SetOnDecide(() =>
        {
            Debug.Log("調合へ移動");
        });

        _battleButton.SetOnDecide(() =>
        {
            Debug.Log("バトルへ移動");
        });
    }

    // Update is called once per frame
    void Update()
    {
        _intervalTime = _intervalTime > 0f ? _intervalTime - Time.deltaTime : 0f;

        if (!_selectList.gameObject.activeInHierarchy)
        {
            return;
        }

        if (_input.GetArrowKeyInput(Gene.Define.ArrowKeyAxis.Down))
        {
            if (_prevInputAxis != ArrowKeyAxis.Down || _intervalTime <= 0f)
            {
                _selectList.SelectNext();
                _prevInputAxis = ArrowKeyAxis.Down;
                _intervalTime = INTERVAL_TIME;
            }
        }
        if (_input.GetArrowKeyInput(Gene.Define.ArrowKeyAxis.Up))
        {
            if (_prevInputAxis != ArrowKeyAxis.Up || _intervalTime <= 0f)
            {
                _selectList.SelectPrev();
                _prevInputAxis = ArrowKeyAxis.Up;
                _intervalTime = INTERVAL_TIME;
            }
        }

        if (_input.GetDecideKeyDown())
        {
            Debug.Log("Actuate");
        }

        if (_input.GetCancelKeyDown())
        {
            HideUi();
        }
    }

    private void ShowUi()
    {
        _selectList.gameObject.SetActive(true);
        _selectList.PlaceCursor();
    }

    private void HideUi()
    {
        if (!_selectList.gameObject.activeSelf)
        {
            return;
        }

        _selectList.gameObject.SetActive(false);
        _selectList.RemoveCursor();
    }
}
