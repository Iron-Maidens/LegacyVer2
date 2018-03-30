using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string playScene = "Diary";
    public string diaryScene = "Diary";
    public SceneFader sceneFader;

	public void play ()
	{
		sceneFader.FadeTo(playScene);
	}
    public void gotoDiary()
    {
        sceneFader.FadeTo(diaryScene);
    }
}
