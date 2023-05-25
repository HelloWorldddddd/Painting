using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animation : MonoBehaviour
{
    public GameObject input;
    private int sceneFlag = 0;
    public Image sceneBackground;
    private input.SceneStruct[] sceneScript;
    private float panelWidth;
    private float panelHeight;
    private GameObject[] roles;
    private GameObject prop;
    private Animation act;
    private bool[] roleFlag =new bool[50];
    // Start is called before the first frame update
    void Start()
    {
        sceneScript = input.GetComponent<input>().script;
        panelWidth = GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width;
        panelHeight = GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height;
    }



    void Update()
    {
        
    }
    public void test()
    {
        
        anim();
    }
    private void anim()
    {
        StartCoroutine(Timer());
    }
    IEnumerator Timer() {
    while (sceneScript.Length >= sceneFlag +1) {
        if(sceneFlag == 0)
        {
            yield return new WaitForSeconds(0.01f); //开始动画
        }

        Debug.Log(string.Format("Timer is up !!! time=${0}", Time.time));
        Debug.Log(sceneScript[sceneFlag].background);
        loadBackground();
        loadRole();
        loadAction();
        loadProp();
        yield return new WaitForSeconds(sceneScript[sceneFlag].time); //每帧时长
        
        for(int i = 0; i < sceneScript[sceneFlag].roleNumber; i++)
        {
            Destroy(roles[i]);
            Destroy(prop);
            roleFlag[i] = false;
        }
        sceneFlag++;
    }

    }
    private void loadBackground()
    {
        //加载背景
        //background 转换 资源名
        
        Sprite backgroundSprite = Resources.Load<Sprite>(cutString(sceneScript[sceneFlag].background)); //资源名
        sceneBackground.sprite = backgroundSprite;
    }
    private void loadRole()
    {
        
        roles = new GameObject[sceneScript[sceneFlag].roleNumber];
        for(int i = 0; i < sceneScript[sceneFlag].roleNumber; i++)
        {
            string cutpath = cutString(sceneScript[sceneFlag].role[i].id);
            string[] rolepath = cutpath.Split("/");
            string roleResources = cutpath + "/Prefab/" + rolepath[rolepath.Length-1];
            GameObject rolePrefab = Resources.Load<GameObject>(roleResources); //资源名
            roles[i]= Instantiate(rolePrefab,new Vector3(panelWidth*(i+1)/(sceneScript[sceneFlag].roleNumber+1), 
                panelHeight*0.25f, 0), Quaternion.identity);
            roles[i].transform.localScale = new Vector3(100,100,100);
            
            //roles[].AddComponent<Animation>();
        }
     /*   
        {
            
            
		    roles[i].transform.SetParent(GameObject.Find("Panel").transform);
            roles[i].transform.position =  new Vector3(panelWidth*(i+1)/(sceneScript[sceneFlag].roleNumber+1), 
                panelHeight*0.5f, 0);
            roles[i].AddComponent<Image>();
            string roleName = "roles/" + sceneScript[sceneFlag].role[i].id;
            Sprite roleSprite = Resources.Load<Sprite>(roleName);
            roles[i].GetComponent<Image>().sprite = roleSprite;
            roleFlag[i] = true;
        }*/
    }

    private void loadAction()
    {
        if(sceneScript.Length >= sceneFlag +1)
        {
            for(int i = 0; i < sceneScript[sceneFlag].roleNumber; i++)
            {
                if(sceneScript[sceneFlag].role[i].action == "move")
                {
                    
                } 
                else
                {
                    string cutpath = cutString(sceneScript[sceneFlag].role[i].action);
                    string[] actionpath = cutpath.Split("/");
                    string actionResources = actionpath[actionpath.Length-1];
                    if(roles[i].GetComponent<Animation>())
                    {
                        act = roles[i].GetComponent<Animation>();
                        act.Play(actionResources);
                    }
                    float step = (500-roles[i].transform.localPosition.x)/sceneScript[sceneFlag].time * Time.deltaTime;
 	                roles[i].transform.localPosition = Vector3.MoveTowards(roles[i].transform.localPosition, new Vector3(300, 
                    0, 0), step);
                    
                   
                }
        
            }
        }
    }
    private void loadProp()
    {
        if(sceneScript[sceneFlag].prop !="")
        {

        
        string cutpath = cutString(sceneScript[sceneFlag].prop);
        string[] proppath = cutpath.Split("/");
        string propResources = cutpath + "/Prefab/" + proppath[proppath.Length-1];
        GameObject propPrefab = Resources.Load<GameObject>(propResources); //资源名
        prop= Instantiate(propPrefab,new Vector3(panelWidth*(0+1)/2, 
                panelHeight*0.5f, 0), Quaternion.identity);
        prop.transform.localScale = new Vector3(10,10,10);
        }
        
    }
    private string cutString(string path)
    {
        string[] filepath;
        filepath = path.Split("\\");
        string resourcepath = "";
        int flag = 0;
        foreach(string f in filepath)
        {
            if(f != "")
            {
                if(flag ==1)
                {
                    resourcepath = resourcepath + string.Format("{0}",f);
                }
                else if(flag >1)
                {
                    resourcepath = resourcepath + string.Format("/{0}",f);
                }
                flag++;
            }
            
        }
        flag = 0;
        string[] backgroundName = resourcepath.Split(".");
        return backgroundName[0];
    }
}
