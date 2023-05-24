using UnityEngine;
using SFB;
using UnityEngine.Video;

public class AdBanner : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer; // Reference to the VideoPlayer component on the plane
    Ray ray;
    RaycastHit hit;

    public void OpenFileExplorer()
    {
        string[] paths = StandaloneFileBrowser.OpenFilePanel("Select MP4 Video", "", "mp4", false);
        if (paths.Length > 0)
        {
            string selectedPath = paths[0];
            videoPlayer.url = "file://" + selectedPath;
            videoPlayer.Play();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Banner"))
                {
                    OpenFileExplorer();
                }
            }
        }
    }
}
