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
public class MusicStage : Stage
{
    public override void DO()
    {
        GameManager.source.ItemGlasses.SetActive(true);
    }
}
public class _3DStage : Stage
{
    public override void DO()
    {
        GameManager.source.ItemColorWorld.SetActive(true);
        GameManager.source.ItemVisibleBoss.SetActive(true);
        GameManager.source.NotImportantList[0].SetActive(true);
        GameManager.source.NotImportantList[1].SetActive(true);
        GameManager.source.NotImportantList[2].SetActive(true);
    }
}
public class ToKillBoss_Stage : Stage
{
    public override void DO()
    {
        GameManager.source.NotImportantList[3].SetActive(true);
        GameManager.source.NotImportantList[4].SetActive(true);
        GameManager.source.NotImportantList[5].SetActive(true);

        //做stage3要做的事，打倒魔王的物品
        GameManager.source.ItemKillBoss.SetActive(true);
    }
}
