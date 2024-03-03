using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Magic
{
    public string name; // 이름
    public int index;
    public int power;   // 위력
    public string command; // 커맨드

    // 생성자
    public Magic(string _name, int _index, int _power, string _command)
    {
        name = _name;
        index = _index;
        power = _power;
        command = _command;
    }
}

public class Command : MonoBehaviour
{
    GameManager GM;
    public Queue<string> directionQueue = new Queue<string>(); // 방향키 정보를 저장할 큐
    float timer = 1f; // 타이머 변수
    float resetTime = 1f; // 초기화 주기
    int count = 0;


    Magic[] sampleMagics = new Magic[]
    {
        new Magic("Fireball", 1, 10, "Up, Up, Down, Down"),
        new Magic("Ice Shard", 2, 8, "Left, Right, Left"),
        new Magic("Thunderbolt", 3, 12, "Up, Left, Down, Right")
    };

    void Start()
    {
        GM = GameManager.instance;
    }

    void Update()
    {
        if (count != GM.playerData.maxCommand && GM.player.readyCast == true && Time.deltaTime != 0)
        {
            // 방향키 입력 처리
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                directionQueue.Enqueue("Up");
                GM.commandUI.RefreshCommandUI();
                count++;
                timer = resetTime;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                directionQueue.Enqueue("Down");
                GM.commandUI.RefreshCommandUI();
                count++;
                timer = resetTime;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                directionQueue.Enqueue("Left");
                GM.commandUI.RefreshCommandUI();
                count++;
                timer = resetTime;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                directionQueue.Enqueue("Right");
                GM.commandUI.RefreshCommandUI();
                count++;
                timer = resetTime;
            }
        }

        // 타이머 업데이트
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            // 큐 초기화
            CompareCommand();
            directionQueue.Clear();
            GM.commandUI.RefreshCommandUI();
            count = 0;
            // 타이머 초기화
            timer = resetTime;
        }

    }
    void CompareCommand()
    {
        // 큐에 저장된 커맨드를 하나의 문자열로 변환
        string queueCommand = string.Join(", ", directionQueue.ToArray());

        // 각 샘플 마법과 비교
        foreach (Magic magic in sampleMagics)
        {
            if (magic.command == queueCommand)
            {   
                // 여기에 마법을 발동하는 등의 처리 추가 가능
                GM.player.anim.SetInteger("AttackFlag", magic.index);
                GM.player.readyCast = false;
            
                Debug.Log("Magic " + magic.name + " activated! Power: " + magic.power);
            }
        }
    }
}
