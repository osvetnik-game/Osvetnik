using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public bool bossDead = false;
    // Start is called before the first frame update
    //public string mission = "Kill boss and get back to the van";
    void Start()
    {
        
    }

    //void OnGUI()
    //{
    //    GUI.skin.label.fontSize = 20;
    //    GUI.Label(new Rect(20, 10, 1000, 200), mission);
    //}

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (bossDead)
        {
            if(other.gameObject.tag == "Player")
            {
                Debug.Log("next level");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
