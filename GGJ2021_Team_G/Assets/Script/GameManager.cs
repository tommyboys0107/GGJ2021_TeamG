using UniRx;
using System;
using UnityEngine;

public static class GameManager 
{
    private static Animator Room;
    static int nowStage;
    private static GameObject canvas;
    public static void Start()
    {
        canvas=GameObject.Find("Canvas");
        Room = Tool.GetUIComponent<Animator>(canvas, "Curtain");
        Stage_MoveForward(new Stage1());
        Dead60Sec();
    }
    
    public static void Stage_MoveForward(Stage stage)
    {
        stage.DO();
    }

    //���ܶ���

    static IDisposable dead;
    //���`����
    public static void Dead60Sec()
    {
        dead = Observable.Timer(TimeSpan.FromSeconds(6))
            .Subscribe(_=> Dead())
            .AddTo(Player.Instance);
    }
    private static void Dead()
    {
        dead.Dispose();
        //�@�q�ʵe�Ჾ���l��m
        Observable.Timer(TimeSpan.FromSeconds(3))
                  .Subscribe(_ => Reset())
                  .AddTo(Player.Instance);
    }
    static void Reset()
    {
        Room.Play("RoomIn");
        Observable.Timer(TimeSpan.FromSeconds(1))
            .Subscribe(_=> { Player.Instance.DeadReset(); Room.Play("RoomOut"); })
            .AddTo(Player.Instance);
        
    }
}
