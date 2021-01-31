using UnityEngine;
public class ColorWorldItem : ItemCollideHandler
{
   protected override void DoTouch(Collider collision)
    {
        PostProcessingManager.instance.TweenGrayEffect(false);
        GameManager.Stage_MoveForward(new ToKillBoss_Stage());
        gameObject.SetActive(false);
    }
}

