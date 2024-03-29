﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    #region Variables
    static Managers s_instance; //싱글턴
    static Managers Instance { get { Init(); return s_instance; } }

    GameManagerEx game = new GameManagerEx();
    ResourceManager resource = new ResourceManager();
    SceneManagerEx scene = new SceneManagerEx();
    SoundManager sound = new SoundManager();
    UIManager ui = new UIManager();

    public static GameManagerEx Game { get { return Instance.game; } }
    public static ResourceManager Resource { get { return Instance.resource; } }
    public static SceneManagerEx Scene { get { return Instance.scene; } }
    public static SoundManager Sound { get { return Instance.sound; } }
    public static UIManager UI { get { return Instance.ui; } }
    #endregion

    void Start()
    {
        Init();
    }

    static void Init()
    {
        if(s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if(go==null)
            {
                go = new GameObject { name = "@Managers" }; 
                go.AddComponent<Managers>(); 
            }
            DontDestroyOnLoad(go); 
            s_instance = go.GetComponent<Managers>(); 

            s_instance.sound.Init();
        }
    }

    public static void Clear()
    {
        Sound.Clear();
        Scene.Clear();
        UI.Clear();
    }
}