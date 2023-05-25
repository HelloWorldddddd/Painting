using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class input : MonoBehaviour
{
    /// <summary>
    /// 场景结构体
    /// </summary>
    [Serializable]
    public struct SceneStruct
    {
        public string  id;  //场景id
        public float  time; //场景用时
        public string  background; //场景背景
        public int roleNumber; //角色数量
        public string  prop; //道具id
        public RoleStruct[] role; //场景角色
    }
    [Serializable]
    public struct RoleStruct
    {
        public string  id;  //角色id
        public string  action;  //角色动作
        
    }
    public SceneStruct[] script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
