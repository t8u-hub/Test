using Gene.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    CharacterController _characterController;

    private GamepadInput _input = new GamepadInput();

    private Vector3 _moveVector;

    public bool IsStopMove { get; set; }

    // Update is called once per frame
    void Update()
    {
        if (IsStopMove)
        {
            return;
        }

        var cameraTransform = Camera.main.transform;

        var inputVector = _input.GetMoveVector(); // �J�������W�ł̈ړ��x�N�g��
        Debug.Log(inputVector);
        if (inputVector.sqrMagnitude < 0.001f) return;

        _moveVector.x = inputVector.x;
        _moveVector.y = 0f;
        _moveVector.z = inputVector.y;

        var moveVectorWrold = cameraTransform.rotation * _moveVector;// ���[���h���W�ł̈ړ��x�N�g���ɕϊ�
        moveVectorWrold.y = 0f; // �㉺�ɂ͈ړ������Ȃ�

        this.transform.rotation = Quaternion.LookRotation(moveVectorWrold);
        _characterController.Move(moveVectorWrold * .02f);
    }
}
