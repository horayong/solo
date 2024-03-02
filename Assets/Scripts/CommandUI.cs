using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CommandUI : MonoBehaviour
{
    GameManager GM;
    public Image[] curCommand = new Image[7];
    public Sprite[] commandSprites= new Sprite[4];
    void Start()
    {
        GM = GameManager.instance;
    }

    public void RefreshCommandUI()
    {
        Queue<string> directionQueue = GM.command.directionQueue;
        // 스택에 쌓인 명령을 순서대로 가져와서 이미지를 변경
        int index = 0;
        foreach (string direction in directionQueue)
        {
            if (index >= curCommand.Length)
                break;

            // 명령에 해당하는 스프라이트를 찾음
            Sprite commandSprite = FindCommandSprite(direction);

            // 해당 인덱스의 이미지에 스프라이트 적용
            curCommand[index].sprite = commandSprite;
            index++;
        }

        // 남은 이미지는 비움
        for (int i = index; i < curCommand.Length; i++)
        {
            curCommand[i].sprite = null;
        }
    }

    Sprite FindCommandSprite(string direction)
    {
        // 명령에 해당하는 스프라이트를 찾아서 반환
        switch (direction)
        {
            case "Left":
                return commandSprites[0];
            case "Down":
                return commandSprites[1];
            case "Right":
                return commandSprites[2];
            case "Up":
                return commandSprites[3];
            default:
                return null;
        }
    }
}
