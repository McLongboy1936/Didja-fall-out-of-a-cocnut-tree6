using UnityEngine;
using UnityEngine.SceneManagement;

public enum State { Play, Win }

public class StateMachine : MonoBehaviour
{
    public State currentState;

    void Awake()
    {
        currentState = State.Play;
    }

    public void Win()
    {
        currentState = State.Win;
    }

    public void Play()
    {
        currentState = State.Play;
    }

    void Update()
    {
        if (currentState == State.Play)
        {
            // Play state logic
        }
        else if (currentState == State.Win)
        {
   
            SceneManager.LoadScene("EndScreen");
        }
    }

}