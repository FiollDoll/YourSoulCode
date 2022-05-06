using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;


public class ad : MonoBehaviour, IUnityAdsListener
{
    public Button AdButton;
    public int hp;
    public int moneyGame;
    public bool newLive;

    void Start()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            Advertisement.AddListener(this);
            Advertisement.Initialize("4661845", true);
        }
    }
    public void ShowAd()
    {
        if(Advertisement.isInitialized)
        {
            Advertisement.Show("Rewarded_Android");
        }
    }
    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ready");
    }
    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Error");
    }
    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Start");
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(showResult == ShowResult.Finished)
        {
            Debug.Log("Result");
            newLive = true;
            hp = 3;
            StartCoroutine("StopBonus");
        }
    }
    IEnumerator StopBonus()
    {
        Debug.Log("Vso");
        yield return new WaitForSeconds(2);
        newLive = false;
        yield return new WaitForSeconds(5);
        hp = 0;
    }
}
