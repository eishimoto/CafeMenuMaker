using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{  
    //String
    [SerializeField] private string game;

    //Panel
    [SerializeField] private GameObject credit;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void CreditPanel()
    {
        credit.SetActive(true);
    }

    public void CloseCredit()
    {
        credit.SetActive(false);
    }
}
