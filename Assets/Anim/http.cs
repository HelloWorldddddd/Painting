using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;
using System.Net;
using System.IO;
using System;

public class http : MonoBehaviour
{
    
    public int id;    
    public string dsc;

    public string url = "http://121.41.51.12:38000/1/兔子医生跑过去喊住了小马同学，给他一瓶魔法药水"; //请求地址
    public string getString;
    public Dictionary<string, string> dic = new Dictionary<string,string>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/*
url:请求地址
*/
    public  void Geturl()
    {
        
        id = 1;    //赋值
        dsc = "有一天，小强生病了。";
        //将数据转换为json字符串
        
      //  dic.Add("id","0");
     //   dic.Add("dsc","有一天，小强生病了。");
     //   Get(url,dic);
        StartCoroutine(Gettest(url));
    }

    
    

    public IEnumerator Gettest(string url)
    {
        
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest();
        if(webRequest.result == UnityWebRequest.Result.Success)
        {
            string rtext = webRequest.downloadHandler.text;
            Debug.Log(rtext);
        }
        else
        {
            Debug.Log(webRequest.error);
        }
        
    }

    

}
