using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ����ģʽ��ȷ��ֻ��һ��GameManagerʵ��
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    // ��Ϸ״̬ö��
    public enum GameState
    {
        Playing,
        Paused,
        GameOver
    }

    // ��ǰ��Ϸ״̬
    private GameState currentState = GameState.Playing;


    

    private void Start()
    {
        SetState(GameState.Playing);
    }

    private void Update()
    {
        HandleInput();
    }

    // �����������
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    // �л���Ϸ״̬
    private void SetState(GameState newState)
    {
        switch (newState)
        {                       
            case GameState.Playing:
                OnPlaying();
                break;
            case GameState.Paused:
                OnPaused();
                break;
            case GameState.GameOver:
                OnGameOver();
                break;
        }
        currentState = newState;
    }  

    /// <summary>
    /// ��ͣ/�ָ���Ϸ
    /// </summary>
    public void TogglePause()
    {
        if (currentState == GameState.Playing)
        {
            SetState(GameState.Paused);
            //�������д�����߼������缤����ͣѡ�����ȵ�

        }
        else if (currentState == GameState.Paused)
        {
            SetState(GameState.Playing);


        }
    }

    /// <summary>
    /// ������Ϸ
    /// </summary>
    public void EndGame()
    {
        SetState(GameState.GameOver);
    }

    // ״̬�л�ʱ�Ĵ����߼�


    private void OnPlaying()
    {
        Time.timeScale = 1f;
     
    }

    private void OnPaused()
    {
        Time.timeScale = 0f;
       
    }

    private void OnGameOver()
    {
        Time.timeScale = 0f;
        
    }

    /// <summary>
    /// ��ת�������ؿ�����
    /// </summary>
    /// <param name="sceneName"></param>
    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}
