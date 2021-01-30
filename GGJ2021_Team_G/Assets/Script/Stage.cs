public abstract class Stage
{
    public abstract void DO(); 
}
public class Stage1 : Stage
{
    public override void DO()
    {
        //做stage1要做的事，丟眼鏡
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
        //做stage2要做的事，打倒魔王的物品
    }
}
