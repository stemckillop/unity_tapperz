using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public enum Tiles
    {
        DISABLED = 0,
        DEFAULT = 1,
        ACTIVE = 2,
        WRONG = 3
    }
    public Sprite[] SpriteIndex;
    public Button[] Buttons;
    Vector2 prevBtn;

    int Score = 0;

    public int TilesEnabled
    {
        get
        {
            int count = 0; for (int i = 0; i < Buttons.Length; i++)
            {
                if (Buttons[i].BtnState == Button.State.ACTIVE || Buttons[i].BtnState == Button.State.WRONG)
                    count++;
            }
            return count;
        }
    }
    public int TilesActive
    {
        get { int count = 0; for (int i = 0; i < Buttons.Length; i++) { if (Buttons[i].BtnState == Button.State.ACTIVE) count++; } return count; }
    }

    public float countTimer = 3;
    public bool Countdown;

    public bool GameActive = false;
    public float gameTimer = 30;

    public bool GameOver = false;
    public float gameoverTimer = 3;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RandomSpawn(4);

        if (Countdown)
        {
            countTimer -= Time.deltaTime;
            DrawNum((int)Mathf.Ceil(countTimer));
            if (countTimer < 0)
            {
                Countdown = false;
                countTimer = 3;
                GameActive = true;
            }
        }
        else if (GameActive)
        {
            gameTimer -= Time.deltaTime;
            if (gameTimer < 0)
            {
                GameActive = false;
                gameTimer = 30;
                GameOver = true;
            }
        }
        else if (GameOver)
        {
            FillButtons(Button.State.DISABLED);
            gameoverTimer -= Time.deltaTime;
            if (gameoverTimer < 0)
            {
                GameOver = false;
                FillButtons(Button.State.DEFAULT);
                gameoverTimer = 3;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                Clear();
            }
            if (Input.GetKey(KeyCode.S))
            {
                RandomSpawn(3);
            }
            if (Input.GetKey(KeyCode.D))
            {
                DrawOne();
            }
            if (Input.GetKey(KeyCode.F))
            {
                DrawTwo();
            }
            if (Input.GetKey(KeyCode.G))
            {
                DrawThree();
            }

            if (Input.GetKey(KeyCode.Q) && GameActive == false)
            {
                Countdown = true; 
            }
        }
    }

    public void ButtonTouched(Button btn)
    {
        prevBtn = btn.pos;

        if (btn.BtnState == Button.State.ACTIVE)
        {
            btn.BtnState = Button.State.DEFAULT;
            Score++;
        }
        else if (btn.BtnState == Button.State.DEFAULT)
        {
            btn.BtnState = Button.State.WRONG;Score--;
        }
    }

    /// <summary>
    /// Specifies how many tiles you want to be turned on
    /// </summary>
    /// <param name="count">number of tiles to turn on</param>
    void RandomSpawn(int count)
    {
        while (TilesEnabled < count)
        {
            int id = Random.Range(0, Buttons.Length);
            if (Buttons[id].BtnState != Button.State.ACTIVE && Buttons[id].pos != prevBtn)
                Buttons[id].BtnState = Button.State.ACTIVE;
        }
    }

    Button GetTileByID(int id)
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            if (Buttons[i].ID == id)
                return Buttons[i];
        }

        return null;
    }
    Button GetTileByPos(int x, int y)
    {
       for (int i = 0; i < Buttons.Length; i++)
        {
            if (Buttons[i].pos == new Vector2(x, y))
                return Buttons[i];
        }

        return null;
    }

    void DrawNum(int num)
    {
        Clear();
        if (num == 3)
            DrawThree();
        else if (num == 2)
            DrawTwo();
        else if (num == 1)
            DrawOne();
    }
    void DrawOne()
    {
        GetTileByPos(0, 1).BtnState = Button.State.ACTIVE;
        GetTileByPos(1, 0).BtnState = Button.State.ACTIVE;
        GetTileByPos(1, 1).BtnState = Button.State.ACTIVE;
        GetTileByPos(1, 2).BtnState = Button.State.ACTIVE;
        GetTileByPos(1, 3).BtnState = Button.State.ACTIVE;
        GetTileByPos(2, 4).BtnState = Button.State.ACTIVE;
        GetTileByPos(1, 4).BtnState = Button.State.ACTIVE;
        GetTileByPos(0, 4).BtnState = Button.State.ACTIVE;
    }
    void DrawTwo()
    {
        GetTileByPos(0, 0).BtnState = Button.State.ACTIVE;
        GetTileByPos(1, 0).BtnState = Button.State.ACTIVE;
        GetTileByPos(2, 0).BtnState = Button.State.ACTIVE;
        GetTileByPos(2, 1).BtnState = Button.State.ACTIVE;
        GetTileByPos(2, 2).BtnState = Button.State.ACTIVE;
        GetTileByPos(1, 2).BtnState = Button.State.ACTIVE;
        GetTileByPos(0, 2).BtnState = Button.State.ACTIVE;
        GetTileByPos(0, 3).BtnState = Button.State.ACTIVE;
        GetTileByPos(0, 4).BtnState = Button.State.ACTIVE;
        GetTileByPos(1, 4).BtnState = Button.State.ACTIVE;
        GetTileByPos(2, 4).BtnState = Button.State.ACTIVE;
    }
    void DrawThree()
    {
        GetTileByPos(2, 0).BtnState = Button.State.ACTIVE;
        GetTileByPos(2, 1).BtnState = Button.State.ACTIVE;
        GetTileByPos(2, 2).BtnState = Button.State.ACTIVE;
        GetTileByPos(2, 3).BtnState = Button.State.ACTIVE;
        GetTileByPos(2, 4).BtnState = Button.State.ACTIVE;

        GetTileByPos(0, 0).BtnState = Button.State.ACTIVE;
        GetTileByPos(1, 0).BtnState = Button.State.ACTIVE;

        GetTileByPos(0, 4).BtnState = Button.State.ACTIVE;
        GetTileByPos(1, 4).BtnState = Button.State.ACTIVE;

        GetTileByPos(1, 2).BtnState = Button.State.ACTIVE;
    }

    void FillButtons(Button.State state)
    {
        for (int i= 0; i < Buttons.Length; i++)
        {
            Buttons[i].BtnState = state;
        }
    }
    void Clear()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].BtnState = Button.State.DEFAULT;
        }
    }
}
