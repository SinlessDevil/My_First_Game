using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomJSON : MonoBehaviour
{
    public static List<B> FromJson<B>(string json)
    {
        Wrapper<B> wrapper = JsonUtility.FromJson<Wrapper<B>>(json);
        return wrapper.UIitems;
    }

    public static string ToJson<B>(List<B> list)
    {
        Wrapper<B> wrapper = new Wrapper<B>();
        wrapper.UIitems = list;
        return JsonUtility.ToJson(wrapper);
    }

    [System.Serializable]
    public class Wrapper<B>
    {
        public List<B> UIitems;
    }

}
