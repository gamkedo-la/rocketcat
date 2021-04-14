using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ShowLevelName : MonoBehaviour
{
    private TextMeshProUGUI TMPText;
    private string wasText;

    // Start is called before the first frame update
    void Start()
    {
        TMPText = GetComponent<TextMeshProUGUI>();
        wasText = TMPText.text;
        Debug.Log(wasText);
    }

    public void ChangeText(int level)
    {
        TMPText.text = "Level " + level + ": " + NameFromIndex(level+SceneLoader.publicNumOfScenesBeforeLevelsStart);
    }

    public void RestoreText() {
        TMPText.text = wasText;
    }

    // code trick found at https://answers.unity.com/questions/1262342/how-to-get-scene-name-at-certain-buildindex.html
    // by JimmyCushnie · Apr 18, 2018 at 06:50 PM
    private static string NameFromIndex(int BuildIndex) {
        string path = SceneUtility.GetScenePathByBuildIndex(BuildIndex);
        int slash = path.LastIndexOf('(');
        string name = path.Substring(slash + 1);
        int dot = name.LastIndexOf('.');
        return name.Substring(0, dot-1);
    }

}
