using UniRx;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{



    public float speedInFrame = 0.01F;
    CharacterController controller;
    IDisposable characterMove;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        characterMove = Observable.EveryUpdate()
            .Subscribe(_ => _2DMove())
            .AddTo(this.gameObject);



    }
    [ContextMenu("2D_to_3D")]
    private void changeMove()
    {
        characterMove.Dispose();
        characterMove= Observable.EveryUpdate()
            .Subscribe(_ => _3DMove())
            .AddTo(this.gameObject);
    }

    void _3DMove()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speedInFrame;
        controller.Move(moveDirection);
    }
    void _2DMove()
    {
        Vector3 moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speedInFrame;
        controller.Move(moveDirection);
    }
    private void OnCollisionEnter(Collision collision)
    {
    }
}
