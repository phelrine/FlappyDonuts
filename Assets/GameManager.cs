using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    WallGenerator generator;
    [SerializeField]
    GameObject donutsPrefab;

    [SerializeField]
    GUIText display;
    int score;

    enum State
    {
        Ready,
        Playing,
        GameOver
    }

    State state;

	// Use this for initialization
	void Start () {
        Reset();
	}

    void Reset()
    {
        score = 0;
        state = State.Ready;
        display.text = "Tap to Start";
    }

	// Update is called once per frame
	void Update ()
    {
        if (state == State.Ready && Input.GetMouseButton(0))
        {
            generator.StartGeneration();
            Instantiate(donutsPrefab, Vector3.left * 3f, Quaternion.identity);
            state = State.Playing;
        }

        if (state == State.GameOver && Input.GetMouseButton(0))
        {
            Reset();
        }
	}

    public void AddScore()
    {
        score++;
        display.text = string.Format("Score {0}", score);
    }

    public void GameOver()
    {
        generator.StopGeneration();
        foreach (var w in FindObjectsOfType<Wall>())
        {
            Destroy(w.gameObject);
        }
        state = State.GameOver;
        display.text = string.Format("Game Over\n Score {0}", score);
    }
}
