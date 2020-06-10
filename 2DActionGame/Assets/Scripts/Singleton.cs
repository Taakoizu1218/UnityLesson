using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
    where T:MonoBehaviour
{
    private static T _instance = null;
    // Start is called before the first frame update
 
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                //コンポーネントを探す(メッチャ重い)
                _instance = FindObjectOfType<T>();
                if(_instance == null)
                {
                    _instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
                    Debug.LogWarning("指定したシングルトンのオブジェクトが見つからなかったので作成=" + typeof(T).ToString());
                }
            }
            return _instance;
        }
    }
}
