using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject crossArrowImage;
    [SerializeField] private GameObject circleArrowImage;
    [SerializeField] private GameObject crossYouText;
    [SerializeField] private GameObject circleYouText;
    [SerializeField] private TextMeshProUGUI crossScoreText;
    [SerializeField] private TextMeshProUGUI circleScoreText;

    private void Awake()
    {
        crossArrowImage.SetActive(false);
        circleArrowImage.SetActive(false);
        crossYouText.SetActive(false);
        circleYouText.SetActive(false);

        crossScoreText.text = "";
        circleScoreText.text = "";
    }

    private void Start()
    {
        GameManager.Instance.OnGameStarted += GameManager_OnGameStarted;
        GameManager.Instance.OnCurrentPlayablePlayerTypeChanged += GameManager_OnCurrentPlayablePlayerTypeChanged;
        GameManager.Instance.OnScoreChanged += GameManager_OnScoreChanged;
    }

    private void GameManager_OnScoreChanged(object sender, System.EventArgs e)
    {
        GameManager.Instance.GetScores(out int playerCrossScore, out int playerCircleScore);

        crossScoreText.text = playerCrossScore.ToString();
        circleScoreText.text = playerCircleScore.ToString();
    }

    private void GameManager_OnCurrentPlayablePlayerTypeChanged(object sender, System.EventArgs e)
    {
        UpdateCurrentArrow();
    }

    private void GameManager_OnGameStarted(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.GetLocalPlayerType() == GameManager.PlayerType.Cross)
        {
            crossYouText.SetActive(true);
        }
        else
        {
            circleYouText.SetActive(true);
        }
        crossScoreText.text = "0";
        circleScoreText.text = "0";

        UpdateCurrentArrow();
    }

    private void UpdateCurrentArrow()
    {
        if (GameManager.Instance.GetCurrentPlayablePlayerType() == GameManager.PlayerType.Cross)
        {
            crossArrowImage.SetActive(true);
            circleArrowImage.SetActive(false);
        }
        else
        {
            crossArrowImage.SetActive(false);
            circleArrowImage.SetActive(true);
        }

    }
}
