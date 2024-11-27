using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    public Color colorPlayer = Color.white;
    public Color colorEnemy = Color.white;
    public string namePlayer = "";
    public string nameEnemy = "";

    private const string SAVED_WINNER_KEY = "SavedWinner";

    private static SaveController _instance;

    public static SaveController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SaveController>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
            }

            return _instance;

        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public string GetName(bool isPlayer)
    {
        return isPlayer ? namePlayer : nameEnemy;
    }

    public void Reset()
    {
        colorPlayer = Color.white;
        colorEnemy = Color.white;
        namePlayer = "";
        nameEnemy = "";
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString(SAVED_WINNER_KEY, winner);
    }

    public string GetLastWinner()
    {
        return PlayerPrefs.GetString(SAVED_WINNER_KEY);
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
