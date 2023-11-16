using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScreen : AutoMonobehaviour
{
    [SerializeField] protected List<Transform> loadScreenTexts;
    [SerializeField] protected GameObject frameLoad;
    [SerializeField] protected Transform startGameScreen;
    [SerializeField] protected Text textLevel;

    protected virtual void LoadScreenTexts()
    {
        loadScreenTexts = new List<Transform>();
        Transform texts = transform.Find("Texts");
        foreach (Transform text in texts)
            loadScreenTexts.Add(text);
    }

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        frameLoad = transform.Find("Frame_Load")?.gameObject;
        startGameScreen = GameObject.Find("Camera")?.transform.Find("Main Camera")?.
            Find("Start_Game_Screen");
        textLevel = transform.Find("Level").GetComponent<Text>();
    }

    protected virtual void LoadText(int index)
    {
        foreach (Transform text in loadScreenTexts)
            text.gameObject.SetActive(false);
        loadScreenTexts[index].gameObject.SetActive(true);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        textLevel = transform.Find("Level").GetComponent<Text>();
        textLevel.text = "LEVEL " + GameController.Instance.Level.ToString();
    }

    protected override IEnumerator LoadWaitForShortTime()
    {
        yield return StartCoroutine(base.LoadWaitForShortTime());
        UIController.Instance.LoadUI("Load_Screen");
        LoadPercentScreen(1);
    }

    protected override IEnumerator LoadWaitForMediumTime()
    {
        yield return StartCoroutine(base.LoadWaitForMediumTime());
        LoadPercentScreen(2);
    }

    protected override IEnumerator LoadWaitForLongTime()
    {
        yield return StartCoroutine(base.LoadWaitForLongTime());
        LoadPercentScreen(3);
        StartCoroutine(FinishedLoadGame());
    }

    protected virtual void LoadPercentScreen(int index)
    {
        float widthFrame = frameLoad.transform.Find("Frame").GetComponent<RectTransform>().rect.width - 3;
        Vector2 newSzie = new Vector2((float) index / 3 * widthFrame, frameLoad.transform.Find("Load").GetComponent<RectTransform>().rect.height);
        frameLoad.transform.Find("Load").GetComponent<RectTransform>().sizeDelta = newSzie;
        LoadText(index - 1);
    }

    protected virtual IEnumerator FinishedLoadGame()
    {
        yield return new WaitForSeconds(1f);
        startGameScreen.gameObject.SetActive(true);
        frameLoad.transform.parent.gameObject.SetActive(false);
        SFXSpawner.Instance.PlaySound("Sound_Background_Game");
    }
}
