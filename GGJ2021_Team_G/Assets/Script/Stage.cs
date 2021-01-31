public abstract class Stage
{
    public abstract void DO(); 
}
public class Stage1 : Stage
{
    public Stage1() { }
    public override void DO()
    {
        //重置狀態
    }
}
public class _3ddStage : Stage
{
    public _3ddStage() { }
    public override void DO()
    {
        GameManager.source.ItemGlasses.SetActive(true);
    }
}
public class VisableBosStage : Stage
{
    public VisableBosStage() { }
    public override void DO()
    {
        GameManager.source.ItemVisibleBoss.SetActive(true);
        GameManager.source.NotImportantList[0].SetActive(true);
        GameManager.source.NotImportantList[1].SetActive(true);
        GameManager.source.NotImportantList[2].SetActive(true);
        GameManager.source.NotImportantList[6].SetActive(true);
    }
}
public class Color_Stage : Stage
{
    public Color_Stage() { }

    public override void DO()
    {
        GameManager.source.ItemColorWorld.SetActive(true);
        GameManager.source.NotImportantList[3].SetActive(true);
        GameManager.source.NotImportantList[4].SetActive(true);
        GameManager.source.NotImportantList[5].SetActive(true);
    }
}
public class ToKillBoss_Stage : Stage
{
    public ToKillBoss_Stage() { }
    public override void DO()
    {
        GameManager.source.NotImportantList[3].SetActive(true);
        GameManager.source.NotImportantList[4].SetActive(true);
        GameManager.source.NotImportantList[5].SetActive(true);

        //做stage3要做的事，打倒魔王的物品
        GameManager.source.ItemKillBoss.SetActive(true);
    }
}
