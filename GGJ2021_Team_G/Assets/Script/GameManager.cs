using UniRx;
using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public static class GameManager 
{
    public static GameSource source;
    private static Image Room;
    static int nowStage;
    private static GameObject canvas;
    public static void Start()
    {
        source = GameObject.Find("GameSource").GetComponent<GameSource>();
        canvas =GameObject.Find("Canvas");
        Room = Tool.GetUIComponent<Image>(canvas, "Curtain");
        Stage_MoveForward(new Stage1());
        Dead60Sec();
    }
    
    public static void Stage_MoveForward(Stage stage)
    {
        stage.DO();
    }

    //提示項目

    static IDisposable dead;
    //死亡控制
    public static void Dead60Sec()
    {
        dead = Observable.Timer(TimeSpan.FromSeconds(3))
            .Subscribe(_=> Dead())
            .AddTo(Player.Instance);
    }
    private static void Dead()
    {
        dead.Dispose();
        //一段動畫後移到初始位置
        Observable.Timer(TimeSpan.FromSeconds(3))
                  .Subscribe(_ => Reset())
                  .AddTo(Player.Instance);
    }
    static void Reset()
    {
        RoomIn();
    }

    private static void RoomIn()
    {
        Room.DOColor(new Color(0, 0, 0, 1), 1f)
            .SetEase(Ease.InCubic)
            .OnComplete(() => WaitRoomOut());
    }

    static void WaitRoomOut()
    {
        Observable.Timer(TimeSpan.FromSeconds(0.5))
          .Subscribe(_ =>
          {
              Player.Instance.DeadReset();
              RoomOut();
              Dead60Sec();
          })
          .AddTo(Player.Instance);

    }

    private static void RoomOut()
    {
        Room.DOColor(new Color(0, 0, 0, 0), 1f)
            .SetEase(Ease.OutCubic);
    }

    public static void GameEnd()
    {
        RoomIn();
        Observable.Timer(TimeSpan.FromSeconds(1))
         .Subscribe(_ =>
         {
             //顯示圖片、播音樂
             //攝影機模糊、會逐漸關掉
             //睜眼動畫
             //RoomOut可能拿掉
             //增加點擊結束遊戲
             RoomOut();
         })
         .AddTo(Player.Instance);
    }
}
