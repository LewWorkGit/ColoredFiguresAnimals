using TMPro;
using UnityEngine;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject dynamicCanvas;
    [SerializeField] private TextMeshProUGUI gameOverText;

    [SerializeField] private string WinTextValue;
    [SerializeField] private string LoseTextValue;

    public void Win()
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = WinTextValue;
        dynamicCanvas.SetActive(false);
    }

    public void Lose()
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = LoseTextValue;
        dynamicCanvas.SetActive(false);
    }

}
