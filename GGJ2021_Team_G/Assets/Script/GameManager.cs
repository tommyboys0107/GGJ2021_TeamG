using UniRx;
using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public static class GameManager 
{
    //private static GameSource source;
    private static Image Room;
    static int nowStage;
    private static GameObject canvas;
    public static void Start()
    {
        //source = GameObject.Find("GameSource").GetComponent<GameSource>();
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
        Room.DOColor(new Color(0, 0, 0, 1), 1f)
            .SetEase(Ease.InCubic)
            .OnComplete(()=>test());

        
    }
    static void test()
    {
        Observable.Timer(TimeSpan.FromSeconds(0.5))
          .Subscribe(_ => {
              Player.Instance.DeadReset();
              Room.DOColor(new Color(0, 0, 0, 0), 1f)
                  .SetEase(Ease.OutCubic);
              Dead60Sec();
          })
          .AddTo(Player.Instance);

    }

    public static void GameEnd()
    {

    }
}
