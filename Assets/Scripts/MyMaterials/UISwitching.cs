using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISwitching : MonoBehaviour
{

    //=============================================UI选项===================================
    public GameObject main; //选择界面
    public GameObject characterMaking;  //角色制作
    public GameObject propsMaking;  //道具制作
    public GameObject sceneMaking;  //场景制作
    public GameObject materialList; //素材列表
    public GameObject workBench;    //创作区
    //=======================================================================================



    public void SwitchToWorkBench()
    {
        switch(gameObject.name)
        {
            case "CharacterMaking":
                workBench.SetActive(true);
                characterMaking.transform.GetChild(1).gameObject.SetActive(true);
                propsMaking.transform.GetChild(1).gameObject.SetActive(false);
                sceneMaking.transform.GetChild(1).gameObject.SetActive(false);
                main.SetActive(false);
                break;
            case "PropsMaking":
                workBench.SetActive(true);
                characterMaking.transform.GetChild(1).gameObject.SetActive(false);
                propsMaking.transform.GetChild(1).gameObject.SetActive(true);
                sceneMaking.transform.GetChild(1).gameObject.SetActive(false);
                main.SetActive(false);
                break;
            case "SceneMaking":
                workBench.SetActive(true);
                characterMaking.transform.GetChild(1).gameObject.SetActive(false);
                propsMaking.transform.GetChild(1).gameObject.SetActive(false);
                sceneMaking.transform.GetChild(1).gameObject.SetActive(true);
                main.SetActive(false);
                break;
            case "MaterialList":
                workBench.SetActive(true);
                
                main.SetActive(false);
                break;
            default:
                
                workBench.SetActive(true);
                characterMaking.transform.GetChild(1).gameObject.SetActive(true);
                main.SetActive(false);
                break;
            
        }
    }

    public void FuncSwitch()
    {
        switch(gameObject.transform.parent.name)
        {
            case "CharacterMaking":
                characterMaking.transform.GetChild(1).gameObject.SetActive(true);
                propsMaking.transform.GetChild(1).gameObject.SetActive(false);
                sceneMaking.transform.GetChild(1).gameObject.SetActive(false);
                break;
            case "PropsMaking":
                characterMaking.transform.GetChild(1).gameObject.SetActive(false);
                propsMaking.transform.GetChild(1).gameObject.SetActive(true);
                sceneMaking.transform.GetChild(1).gameObject.SetActive(false);
                break;
            case "SceneMaking":
                characterMaking.transform.GetChild(1).gameObject.SetActive(false);
                propsMaking.transform.GetChild(1).gameObject.SetActive(false);
                sceneMaking.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case "MaterialList":
                break;
            default:
                break;
        }
        // gameObject.SetActive(false);
        
    }

}
