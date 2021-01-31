public abstract class Stage
{
    public abstract void DO(); 
}
public class Stage1 : Stage
{
    public override void DO()
    {
        //重置狀態
    }
}
public class Stage2 : Stage
{
    public override void DO()
    {
        //做stage2要做的事，丟光球、調色盤
    }
}
public class Stage3 : Stage
{
    public override void DO()
    {
        //做stage3要做的事，打倒魔王的物品
        GameManager.source.ItemVisibleBoss.SetActive(true);
    }
}
public class Stage4 : Stage
{
    public override void DO()
    {
        //做stage3要做的事，打倒魔王的物品
        GameManager.source.ItemKillBoss.SetActive(true);
    }
}
