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
        dead = Observable.Timer(TimeSpan.FromSeconds(3))
            .Subscribe(_=> Dead())
            .AddTo(Player.Instance);
    }
    public static void Dead60Sec_Cancel()
    {
        dead.Dispose();
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
        Debug.Log("gameEnd");return;
        RoomIn();
        Observable.Timer(TimeSpan.FromSeconds(3))
         .Subscribe(_ =>
         {
             //��ܹϤ��B������
             GameEndPicture.gameObject.SetActive(true);
             source.MusicSource.clip = source.MusicClip;
             source.MusicSource.Play();
             //��v���ҽk
             //PostProcessingManager.instance
             //�C���ʵe
             //��v�����ҽk
             //RoomOut�i�ள��
             //�W�[�I�������C��
             RoomOut();
         })
         .AddTo(Player.Instance);
    }
}
