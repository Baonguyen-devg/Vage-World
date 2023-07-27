using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScreen : AutoMonobehaviour
{
    [SerializeField] protected List<Transform> loadScreenTexts;
    protected virtual void LoadScreenTexts()
    {
        this.loadScreenTexts = new List<Transform>();
        Transform texts = transform.Find("Texts");
        foreach (Transform text in texts)
            this.loadScreenTexts.Add(text);
    }

    [SerializeField] protected GameObject frameLoad;
    protected virtual void LoadScreenUI() =>
        this.frameLoad = transform.Find("Frame_Load")?.gameObject;

    [SerializeField] protected Transform startGameScreen;
    protected virtual void LoadStartGameScreen() =>
        this.startGameScreen = GameObject.Find("Camera")?.transform.Find("Main Camera")?.
            Find("Start_Game_Screen");

    [SerializeField] protected Text textLevel;
    protected virtual void LoadTestSkill() =>
        this.textLevel = transform.Find("Level").GetComponent<Text>();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadScreenUI();
        this.LoadStartGameScreen();
        this.LoadScreenTexts();
    }

    protected virtual void LoadText(int index)
    {
        foreach (Transform text in this.loadScreenTexts)
            text.gameObject.SetActive(false);
        this.loadScreenTexts[index].gameObject.SetActive(true);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.LoadTestSkill();
        this.textLevel.text = "LEVEL " + GameController.Instance.Level.ToString();
    }

    protected override IEnumerator LoadWaitForShortTime()
    {
        yield return StartCoroutine(base.LoadWaitForShortTime());
        UIController.Instance.LoadUI("Load_Screen");
        this.LoadPercentScreen(1);
    }

    protected override IEnumerator LoadWaitForMediumTime()
    {
        yield return StartCoroutine(base.LoadWaitForMediumTime());
        this.LoadPercentScreen(2);
    }

    protected override IEnumerator LoadWaitForLongTime()
    {
        yield return StartCoroutine(base.LoadWaitForLongTime());
        this.LoadPercentScreen(3);
        StartCoroutine(this.FinishedLoadGame());
    }

    protected virtual void LoadPercentScreen(int index)
    {
        float widthFrame = this.frameLoad.transform.Find("Frame").GetComponent<RectTransform>().rect.width - 3;
        Vector2 newSzie = new Vector2((float) index / 3 * widthFrame, this.frameLoad.transform.Find("Load").GetComponent<RectTransform>().rect.height);
        this.frameLoad.transform.Find("Load").GetComponent<RectTransform>().sizeDelta = newSzie;
        this.LoadText(index - 1);
    }

    protected virtual IEnumerator FinishedLoadGame()
    {
        yield return new WaitForSeconds(1f);
        this.startGameScreen.gameObject.SetActive(true);
        this.frameLoad.transform.parent.gameObject.SetActive(false);
        SFXSpawner.Instance.PlaySound("Sound_Background_Game", "Forest");
    }
}
