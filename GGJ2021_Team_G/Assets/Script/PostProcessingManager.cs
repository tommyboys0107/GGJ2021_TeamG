using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using DG.Tweening;
using System;

public class PostProcessingManager : MonoBehaviour
{
    public static PostProcessingManager instance;

    public bool defaultGray = true;
    public float tweenGrayTime = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(this);
        SetGrayScale(defaultGray);
    }

    public void SetGrayScale(bool gray)
    {
        Volume volume = GetComponent<Volume>();
        var profile = volume.profile;
        var list = profile.components;
        IReadOnlyCollection<VolumeParameter> collection = null;
        /*考慮到後面還會添加其它的 override
        for (int i = 0; i < list.Count; i++)
        {
            collection = list[i].parameters;
        }
        */
        //取第一個 color adjustment
        collection = list[0].parameters;

        var e = collection.GetEnumerator();

        VolumeParameter vp = gray ? new FloatParameter(-100) : new FloatParameter(0);

        while (e.MoveNext())
        {
            if (e.Current.overrideState)
            {
                e.Current.SetValue(vp);
                
            }
        }

    }

    public void TweenGrayEffect(bool gray)
    {
        Volume volume = GetComponent<Volume>();
        var profile = volume.profile;
        var list = profile.components;
        IReadOnlyCollection<VolumeParameter> collection = null;
        /*考慮到後面還會添加其它的 override
        for (int i = 0; i < list.Count; i++)
        {
            collection = list[i].parameters;
        }
        */
        //取第一個 color adjustment
        collection = list[0].parameters;

        float old_f = gray ? 0 : -100;
        float new_f = gray ? -100 : 0;
        float temp = old_f;
        /*
        VolumeParameter vp = new FloatParameter(old_f);
        while (e.MoveNext())
        {
            if (e.Current.overrideState)
            {
                e.Current.SetValue(vp);
            }
        }
        */

        Sequence s = DOTween.Sequence();
        s.SetAutoKill(false);
        s.Append(DOTween.To(() => temp, x => temp = x, new_f, tweenGrayTime)).OnUpdate(() =>{
            //print(temp);
            var e = collection.GetEnumerator();
            VolumeParameter vp = new FloatParameter(temp);
            while (e.MoveNext())
            {
                if (e.Current.overrideState)
                {
                    e.Current.SetValue(vp);
                }
            }
        });
        //old_f = new_f;

        //DOTween.To(() => myVector, x => myVector = x, new Vector3(3, 4, 8), 1);
    }
}
