using UnityEngine;

public class FinalItem : ItemCollideHandler
{
    protected override void DoTouch(Collider collision)
    {
        PostProcessingManager.instance.TweenGrayEffect(false);
        gameObject.SetActive(false);
    }
}
