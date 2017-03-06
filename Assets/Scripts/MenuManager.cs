using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public GameManager game;

    public GameObject title;
    public GameObject GameMenu;
    public GameObject GameTypeMenu;
    public Text text;

    public string chosenGame;

    public string lightningInstructions = "Try to tap as many green buttons as you can before time runs out!";
    public string timetrialInstructions = "See how long it takes for you to tap 50 buttons!";
    public string reactionInstructions = "See your reaction time, Button will randomly light up and your score will be based on reaction time!";

    public void GameTypeChosen(string type)
    {
        if (type != "Scoreboard")
        {
            if (type == "Lightning")
                text.text = lightningInstructions;
            else if (type == "TimeTrial")
                text.text = timetrialInstructions;
            else if (type == "Reaction")
                text.text = reactionInstructions;

            chosenGame = type;
            GameMenu.SetActive(false);
            GameTypeMenu.SetActive(true);
        }
        else
        {

        }
    }

    public void PlayBtn()
    {
        GameMenu.SetActive(false);
        GameTypeMenu.SetActive(false);
        title.SetActive(false);

        game.StartGame();
    }

    public void BackBtn()
    {
        chosenGame = "";
        GameMenu.SetActive(true);
        GameTypeMenu.SetActive(false);
        title.SetActive(true);
    }

    public void OpenScore()
    {

    }
}
