using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    bool endedGame=false;
    // Start is called before the first frame update
    public float restartDelay=2f;
    public void EndGame()
    {
        if(endedGame==false)
        {
            endedGame=true;
            Debug.Log("Game Over");
            Invoke("Restart",restartDelay);
        }
        
    }

    // Update is called once per frame
    void Restart()
    {
        //aici se poate da load la urmatorul nivel
        SceneManager.LoadScene("MainScene");
    }
}
