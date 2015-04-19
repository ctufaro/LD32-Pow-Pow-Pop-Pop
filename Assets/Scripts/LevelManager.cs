using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public bool lastLevel;
    public Transform pappy;
    private Text scoreText;
    private Text screenText;
    private Image imagePanel;
    private int score;

    // Use this for initialization
	void Start () {
        score = 0;
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        screenText = GameObject.Find("ScreenText").GetComponent<Text>();
        screenText.gameObject.SetActive(false);
        imagePanel = GameObject.Find("ScreenPanel").GetComponent<Image>();
        JunkyBehavior.OnKill += new System.EventHandler(JunkyBehavior_OnKill);
        LevelTrigger.OnGameOver += new System.EventHandler(LevelTrigger_OnGameOver);
        LevelTrigger.OnLevelOver += new System.EventHandler(LevelTrigger_OnLevelOver);
	}

    void LevelTrigger_OnLevelOver(object sender, System.EventArgs e)
    {
        LevelOver();
    }

    void LevelTrigger_OnGameOver(object sender, System.EventArgs e)
    {
        GameOver();
    }

    void JunkyBehavior_OnKill(object sender, System.EventArgs e)
    {
        IncrementScore();
    }

    public void ResetLevel()
    {
        Application.LoadLevel(lastLevel ? 1 : 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void IncrementScore()
    {
        if (scoreText != null)
        {
            scoreText.text = string.Concat("Score: ", (++score) * 100);
        }
    }

    void GameOver()
    {
        if (pappy)
        {
            Destroy(pappy.GetComponent<PappyMovement>());
            StartCoroutine(FadeToStart(imagePanel, .8f, 3f));
            pappy.GetComponent<Animator>().SetInteger("Speed", -1);
            pappy.GetComponent<Animator>().SetBool("Idle", true);
            screenText.gameObject.SetActive(true);
            screenText.text = "Thanks For Playing!";
        }
    }

    void LevelOver()
    {
        if (pappy)
        {
            Destroy(pappy.GetComponent<PappyMovement>());
            StartCoroutine(FadeToStart(imagePanel, .8f, 3f));
            pappy.GetComponent<Animator>().SetInteger("Speed", -1);
            pappy.GetComponent<Animator>().SetBool("Idle", true);
            screenText.gameObject.SetActive(true);
            screenText.text = "Level Complete!";
            StartCoroutine(LoadLevel());
        }
    }

    IEnumerator FadeToStart(Image panel, float aValue, float aTime)
    {
        float alpha, r, g, b = 0f;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            alpha = 0f;
            r = panel.color.r;
            g = panel.color.g;
            b = panel.color.b;
            panel.color = new Color(r, g, b, Mathf.Lerp(alpha, aValue, t));
            yield return null;
        }


    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(4);
        Application.LoadLevel(1);
    }
}
