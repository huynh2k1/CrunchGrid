using UnityEngine;

public class baseManager : MonoBehaviour
{
    public State state;

    public virtual void Home()
    {
        state = State.None;
    }

    public virtual void PlayGame()
    {
        state = State.Playing;
    }

    public virtual void ReplayGame()
    {
        state = State.Playing;
    }

    public virtual void WinGame()
    {
        state = State.None;
    }

    public virtual void LoseGame()
    {
        state = State.None;
    }

    public enum State
    {
        None,
        Playing
    }
}


