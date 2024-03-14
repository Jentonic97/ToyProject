using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName;

    void Start()
    {
        // Video Player ������Ʈ�� �̺�Ʈ�� OnVideoEnd �Լ��� �����մϴ�.
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // ������ ���� �����ϸ� ���� ������ �Ѿ�ϴ�.
        SceneManager.LoadScene(nextSceneName);
    }
}
