using UniRx;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    private Vector3 position;
    public float speed = 10f;
    IDisposable characterMove;
    void Start()
    {
        Instance = this;
        position = this.transform.position;
        characterMove = Observable.EveryUpdate()
            .Subscribe(_ => _2DMove())
            .AddTo(this.gameObject);
    }
    [ContextMenu("2D_to_3D")]
    public void changeMove()
    {
        characterMove.Dispose();
        characterMove= Observable.EveryUpdate()
            .Subscribe(_ => _3DMove())
            .AddTo(this.gameObject);
    }

    void _3DMove()
    {
        float Hor_Input = 0f;
        float Ver_Input = 0f;
        Ver_Input = Input.GetAxis("Vertical");
        Hor_Input = Input.GetAxis("Horizontal");

        Vector3 moveDirection = new Vector3(Hor_Input, 0, Ver_Input);
        moveDirection.Normalize();
        if (moveDirection == Vector3.zero) return;
        transform.forward = moveDirection; 
        transform.position += moveDirection* speed*Time.deltaTime;
    }
    void _2DMove()
    {
        float Hor_Input = 0f;
        Hor_Input = Input.GetAxis("Horizontal");

        Vector3 moveDirection = new Vector3(Hor_Input, 0, 0);
        moveDirection.Normalize();
        if (moveDirection == Vector3.zero) return;
        transform.forward = moveDirection;
        transform.position += moveDirection * speed * Time.deltaTime;
    }
    public void DeadReset()
    {
        transform.position = position;
    }
}
