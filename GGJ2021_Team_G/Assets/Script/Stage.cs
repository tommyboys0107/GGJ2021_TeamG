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
public class _3DStage : Stage
{
    public override void DO()
    {
        GameManager.source.ItemColorWorld.SetActive(true);
        GameManager.source.ItemVisibleBoss.SetActive(true);

    }
}
public class ToKillBoss_Stage : Stage
{
    public override void DO()
    {
        //做stage3要做的事，打倒魔王的物品
        GameManager.source.ItemKillBoss.SetActive(true);
    }
}
