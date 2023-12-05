using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScreen : AutoMonobehaviour
{
    [SerializeField] private List<Transform> loadScreenTexts;
    [SerializeField] private RectTransform frameLoad;
    [SerializeField] private TMP_Text textLevel;

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        frameLoad = transform.Find("Frame_Load").transform.Find("Load").GetComponent<RectTransform>();
        textLevel = transform.Find("Level").GetComponent<TMP_Text>();
    }
    #endregion

    protected override void Awake()
    {
        base.Awake();
        LoadSceneFake();
        textLevel.text = "Level " + DataManager.GetIntData(DataManager.INT_LEVEL);
    }

    private void LoadSceneFake()
    {
        Extension.StartDelayAction(this, 1f, () => LoadPercentScreen(1));
        Extension.StartDelayAction(this, 1.5f, () => LoadPercentScreen(2));
        Extension.StartDelayAction(this, 2f, () => LoadPercentScreen(3));
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        yield return new WaitForSeconds(2.5f);
        int levelPresent = DataManager.GetIntData(DataManager.INT_LEVEL);
        string nameLevel = "Level_" + levelPresent;

        AsyncOperation asyncOperation = LoadSceneManager.LoadSeneAsync(nameLevel);
        while (!asyncOperation.isDone)
        {
            float process = (float)2/3 + Mathf.Clamp01(asyncOperation.progress);
            yield return null;
        }
    }

    protected virtual void LoadText(int index)
    {
        foreach (Transform text in loadScreenTexts)
            text.gameObject.SetActive(false);

        loadScreenTexts[index - 1].gameObject.SetActive(true);
    }

    protected virtual void LoadPercentScreen(int rate)
    {
        float widthFrame = (float) rate * frameLoad.parent.GetComponent<RectTransform>().rect.width / loadScreenTexts.Count;
        float heightFrame = frameLoad.rect.height;

        Vector2 newSzie = new Vector2(widthFrame, heightFrame);
        frameLoad.sizeDelta = newSzie;
        LoadText(rate);
    }
}
