using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public enum State
    {
        DISABLED,
        DEFAULT,
        ACTIVE,
        WRONG,
    }
    public State BtnState;
    //if disabled Active == false
    public GameManager manager;

    public byte ID;

    public bool Active;
    public bool Wrong;

    public float WrongTimer;
    public float WrongTime = 0.2f;

    public Vector2 pos;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    switch (BtnState)
        {
            case State.DISABLED:
                {
                    GetComponent<SpriteRenderer>().sprite = manager.SpriteIndex[(int)GameManager.Tiles.DISABLED];
                    break;
                }
            case State.DEFAULT:
                {
                    GetComponent<SpriteRenderer>().sprite = manager.SpriteIndex[(int)GameManager.Tiles.DEFAULT];
                    break;
                }
            case State.ACTIVE:
                {
                    GetComponent<SpriteRenderer>().sprite = manager.SpriteIndex[(int)GameManager.Tiles.ACTIVE];
                    break;
                }
            case State.WRONG:
                {
                    GetComponent<SpriteRenderer>().sprite = manager.SpriteIndex[(int)GameManager.Tiles.WRONG];

                    WrongTimer += Time.deltaTime;
                    if (WrongTimer > WrongTime)
                    {
                        BtnState = State.DEFAULT;
                        WrongTimer = 0;
                    }

                    break;
                }
        }
	}
}
