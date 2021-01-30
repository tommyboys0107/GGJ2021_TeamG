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
    //現在狀態
    public static bool RightStage(int stage)
    {
        if (stage == nowStage) return true;
        else return false;
    }
    //提示項目

    static IDisposable dead;
    //死亡控制
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
        //一段動畫後移到初始位置
    }
}
