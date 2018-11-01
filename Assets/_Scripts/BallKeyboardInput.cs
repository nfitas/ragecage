using UnityEngine;
using System.Collections;

public class BallKeyboardInput : MonoBehaviour, IBallInput
{

    public float strength { get; private set; }
    public bool decreaseStrenght { get; private set; }
    public bool increaseStrenght { get; private set; }
    public bool restart { get; private set; }
    public bool throwBall { get; private set; }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        decreaseStrenght = Input.GetKeyDown(KeyCode.DownArrow);
        increaseStrenght = Input.GetKeyDown(KeyCode.UpArrow);
        restart = Input.GetKeyDown(KeyCode.Space);
        throwBall = Input.GetKeyDown(KeyCode.Return);
    }
}