using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SavableMonoBehaviour : MonoBehaviour
{
    private static Dictionary<string, object> rootData;
    static Dictionary<string, Dictionary<string, object>> GameData;

    public static void Initialize()
    {
        if (GameData == null)
            GameData = new Dictionary<string, Dictionary<string, object>>();
        if (rootData == null)
            rootData = getObjectData("ROOT");
    }

    public static bool RootTryLoad<T>(string name, out T result)
    {
        result = default(T);
        object data;

        if (rootData.TryGetValue(name, out data))
        {
            result = (T)data;
            return true;
        }
        else
            return false;
    }

    public static void RootSave<T>(string name, T data)
    {
        rootData[name] = data;
    }

    public static void Clear()//Will reset the saved file when load a new game!
    {
        GameData = new Dictionary<string, Dictionary<string, object>>();
    }

    public static void Save(string file = "save")
    {
        TBFFile tbf = new TBFFile(file + ".tbf");
        tbf.SaveFile(GameData);
    }

    public static void Load(string file = "save")
    {
        TBFFile tbf = new TBFFile(file + ".tbf");
        GameData = tbf.LoadFile();

        rootData = getObjectData("ROOT");
    }

    /// <summary>
    /// Gets an objects data from the savefile or an empty set if none found
    /// </summary>
    /// <param name="Name of the object"></param>
    /// <returns></returns>
    private static Dictionary<string, object> getObjectData(string name)
    {
        Dictionary<string, object> data = null;
        if (GameData.TryGetValue(name, out data))
        {
            return data;
        }
        else
        {
            var d = new Dictionary<string, object>();
            GameData[name] = d;
            return d;
        }
    }

    private Dictionary<string, object> objectData;

    /// <summary>
    /// Must be called using base.Start() if overrided
    /// </summary>
    public virtual void Start()
    {
        objectData = getObjectData(SceneManager.GetActiveScene().name + " " + name);
        //objectData = getObjectData(name);
    }

    /// <summary>
    /// Saves data to this object in the savefile
    /// </summary>
    /// <param name="Name of the property to save"></param>
    /// <param name="Data to save"></param>
    protected void save<T>(string name, T data)
    {
        objectData[name] = data;
    }

    /// <summary>
    /// Loads data from the savefile
    /// </summary>
    /// <param name="Name of the property to load"></param>
    /// <returns></returns>
    protected bool tryLoad<T>(string name, out T result)
    {
        result = default(T);
        object data;

        if (objectData.TryGetValue(name, out data))
        {
            result = (T)data;
            return true;
        }
        else
            return false;
    }
}
