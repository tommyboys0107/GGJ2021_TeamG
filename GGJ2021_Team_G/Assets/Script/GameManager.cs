using UniRx;
using System;
using UnityEngine;

public static class GameManager 
{
    static int nowStage;
    public static void Stage_MoveForward()
    {
        nowStage++;
    }
    //�{�b���A
    public static bool RightStage(int stage)
    {
        if (stage == nowStage) return true;
        else return false;
    }
    //���ܶ���

    static IDisposable dead;
    //���`����
    public static void Dead60Sec(Player player)
    {
        dead = Observable.Timer(TimeSpan.FromSeconds(60))
            .Subscribe(_=> ReSet())
            .AddTo(player);
    }
    private static void ReSet()
    {
        Debug.Log("DEAD");
        dead.Dispose();
        //�@�q�ʵe�Ჾ���l��m
    }
}
