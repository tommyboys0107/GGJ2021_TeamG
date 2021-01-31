using UniRx;
using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public static class GameManager 
{
    public static GameSource source;
    private static Image Room;
    private static Image GameEndPicture;
    static int nowStage;
    private static GameObject canvas;
    public static void Start()
    {
        source = GameObject.Find("GameSource").GetComponent<GameSource>();
        canvas =GameObject.Find("Canvas");
        Room = Tool.GetUIComponent<Image>(canvas, "Curtain");
        GameEndPicture = Tool.GetUIComponent<Image>(canvas, "GameEndPicture");
        Stage_MoveForward(new Stage1());
        Dead60Sec(2.0f);
    }
    //public static void GetNotImportantItem()
    //{
    //    //trueEndCount--;
    //}
    public static void Stage_MoveForward(Stage stage)
    {
        stage.DO();
    }

    //提示項目

    static IDisposable Dead_Detect;
    static IDisposable DoDead;
    //死亡控制
    public static void Dead60Sec(float time)
    {
        Dead_Detect = Observable.Timer(TimeSpan.FromSeconds(time))
            .Subscribe(_=> Dead())
            .AddTo(Player.Instance);
    }
    public static void Dead60Sec_Cancel()
    {
        Dead_Detect.Dispose();
        DoDead.Dispose();
    }
    private static void Dead()
    {
        Dead_Detect.Dispose();
        TimelinePlayer.PlayFocus();
        MusicManager.instance.PlayBossAttackSound();
        BossUnit boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossUnit>();
        if (boss != null)
        {
            Debug.Log("Boss Attack");
            boss.PlayBossAttack(true);
        }
        DoDead =Observable.Timer(TimeSpan.FromSeconds(3))
                  .Subscribe(_ => Reset())
                  .AddTo(Player.Instance);
    }
    static void Reset()
    {
        TimelinePlayer.PlayReturnNormal();
        MusicManager.instance.StopBossAttackSound();
        BossUnit boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossUnit>();
        if (boss != null)
        {
            boss.PlayBossAttack(false);
        }
        RoomIn();
    }

    private static void RoomIn()
    {
        MusicManager.instance.PlayBossAttackSound();
        Room.DOColor(new Color(0, 0, 0, 1), 1f)
            .SetEase(Ease.InCubic)
            .OnComplete(() => WaitRoomOut());
    }
    private static void RoomInNotRoomOut()
    {
        Room.DOColor(new Color(0, 0, 0, 1), 1f)
            .SetEase(Ease.InCubic);
    }
    static void WaitRoomOut()
    {
        Observable.Timer(TimeSpan.FromSeconds(0.5))
          .Subscribe(_ =>
          {
              Player.Instance.DeadReset();
              RoomOut();
              Dead60Sec(10.0f);
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
        //if (trueEndCount <= 0) GameEndPicture.sprite = trueEnd;return;
        RoomInNotRoomOut();
        Observable.Timer(TimeSpan.FromSeconds(3))
         .Subscribe(_ =>
         {
             //顯示圖片、播音樂
             GameEndPicture.gameObject.SetActive(true);
             MusicManager.instance.PlayFinishBGM();
             //攝影機模糊
             //PostProcessingManager.instance
             //睜眼動畫
             //攝影機不模糊
             //RoomOut可能拿掉
             //增加點擊結束遊戲
             RoomOut();
             Observable.Timer(TimeSpan.FromSeconds(6f))
             .Subscribe(_=> { source.CloseButton.gameObject.SetActive(true); source.CloseButton.onClick.AddListener(Application.Quit); });
         })
         .AddTo(Player.Instance);
    }


}
