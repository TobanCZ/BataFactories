using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ipad : MonoBehaviour
{
    public GameObject miniIpad;
    public GameObject ipadObject;
    public GameObject botyObject;
    public GameObject poptavkaObject;
    public GameObject zamestnanciObject;
    public GameObject krabiceObject;
    public GameObject ShopObject;
    public GameObject infoObject;
    void Start()
    {
        
    }

    public void off()
    {
        Application.Quit();
    }

    public void IpadOpend(bool activity)
    {
        ipadObject.active = activity;
        miniIpad.active = !activity;
    }
    
    public void Boty(bool activity)
    {
        botyObject.active = activity;
    }

    public void Poptavka(bool activity)
    {
        poptavkaObject.active = activity;
    }

    public void Zamestnanci(bool activity)
    {
        zamestnanciObject.active = activity;
    }

    public void Krabice(bool activity)
    {
        krabiceObject.active = activity;
    }

    public void Shop(bool activity)
    {
        ShopObject.active = activity;
    }

    public void Info(bool activity)
    {
        infoObject.active = activity;
    }

    public void Restrart()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
