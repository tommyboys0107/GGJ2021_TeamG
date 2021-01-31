using UnityEngine;
using DG.Tweening;

public class NotImportItem : ItemCollideHandler
{
    public GameObject GO;
    protected override void DoTouch(Collider collision)
    {
        GO.transform.DOMoveY(0,2f);
        gameObject.SetActive(false);
    }
}

