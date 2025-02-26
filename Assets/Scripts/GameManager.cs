using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TMP_Text label_s;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        label_s.text = "Score: " + score;
    }

    public void StartScene()
    {
        SceneManager.LoadScene(1);
    }

    public void Cerrar()
    {
        Application.Quit();
    }

    public void DaPuntos()
    {
        score += 10;
    }
}
