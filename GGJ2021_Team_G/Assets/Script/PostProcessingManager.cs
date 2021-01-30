using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using DG.Tweening;

public class PostProcessingManager : MonoBehaviour
{
    public static PostProcessingManager instance;

    public bool defaultGray = true;
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


}
