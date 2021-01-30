
using UnityEngine;

public static class Tool 
{
    public static GameObject FindChildGameObject(GameObject Root,string GameObjectName)
    {
        if (Root==null) { Debug.LogError("there is no Root");return null; }

        if (Root.name == GameObjectName) return Root;
        Transform Result = null;
        Transform[] _childs=  Root.transform.GetComponentsInChildren<Transform>(true);
        foreach (var child in _childs)
        {
            if (child.name == GameObjectName)
            {
                if (Result == null)
                {
                    Result = child;
                }
                else Debug.LogError("there is more than one gameobject has the same name.");
            }  
        }
        if (Result == null) Debug.LogError($"GameObject {Root} don't have a ChildGameObject named {GameObjectName}");
        return Result?.gameObject;
    }

    public static T GetUIComponent<T>(GameObject Root,string UIName) where T:UnityEngine.Component
    {
        GameObject _childGameObject = FindChildGameObject(Root, UIName);
        if (_childGameObject == null) return null;

        T Result = _childGameObject.GetComponent<T>();
        if (Result == null) { Debug.LogError($"{UIName} don't has component in type {typeof(T)}.");return null; }
        return Result;
    }


    public static bool IsUpdateTime(ref float TimeCheckclock, float TimeCheckInterval)
    {
        if (TimeCheckclock < TimeCheckInterval) { TimeCheckclock += Time.deltaTime; return false; }
        else { TimeCheckclock = 0; return true; }
    }
}
