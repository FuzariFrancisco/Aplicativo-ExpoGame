using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;

public class SnapshotShare : MonoBehaviour
{
	private AndroidUltimatePluginController androidUltimatePluginController;
	Camera mainCamera;
	RenderTexture renderTex;
	Texture2D screenshot;
	Texture2D LoadScreenshot;
	int width = Screen.width;   // for Taking Picture
	int height = Screen.height; // for Taking Picture
	string fileName;
    string screenShotName = "PictureShare";
    string LastName = "";
    public GameObject Botao1, Botao2;
    float timer = 0;
    bool check = false, picture = false;
    int count = 0;

    private string _caminho;

	void Start ()
	{
		androidUltimatePluginController = AndroidUltimatePluginController.GetInstance ();
	}

    private void Update()
    {
        if (check)
        {
            Botao1.SetActive(false);
            Botao2.SetActive(false);
            timer += Time.deltaTime;

            if (timer >= 1 && count == 0)
            {
                OnSaveScreenshotPress();
                count++;
            }

            if (timer >= 2)
            {
                Botao1.SetActive(true);
                Botao2.SetActive(true);
                check = false;
            }
        }

        if (!check)
        {
            timer = 0;
            count = 0;
        }
    }

    public void Snapshot ()
	{
        check = true;
	}

    public void OnSaveScreenshotPress()
    {
        NativeToolkit.SaveScreenshot("MyScreenshot", "ExpoGame", "jpeg");
    }

    public IEnumerator CaptureScreen ()
	{

		yield return null; // Wait till the last possible moment before screen rendering to hide the UI

		GameObject.Find ("Canvas").GetComponent<Canvas> ().enabled = false;
		yield return new WaitForEndOfFrame (); // Wait for screen rendering to complete
		if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
			mainCamera = Camera.main.GetComponent<Camera> (); // for Taking Picture
			renderTex = new RenderTexture (width, height, 24);
			mainCamera.targetTexture = renderTex;
			RenderTexture.active = renderTex;
			mainCamera.Render ();
			screenshot = new Texture2D (width, height, TextureFormat.RGB24, false);
			screenshot.ReadPixels (new Rect (0, 0, width, height), 0, 0);
			screenshot.Apply (); //false
			RenderTexture.active = null;
			mainCamera.targetTexture = null;
		}
		if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight) {
			mainCamera = Camera.main.GetComponent<Camera> (); // for Taking Picture
			renderTex = new RenderTexture (height, width, 24);
			mainCamera.targetTexture = renderTex;
			RenderTexture.active = renderTex;
			mainCamera.Render ();
			screenshot = new Texture2D (height, width, TextureFormat.RGB24, false);
			screenshot.ReadPixels (new Rect (0, 0, height, width), 0, 0);
			screenshot.Apply (); //false
			RenderTexture.active = null;
			mainCamera.targetTexture = null;
		}
        // on Win7 - C:/Users/Username/AppData/LocalLow/CompanyName/GameName
        // on Android - /Data/Data/com.companyname.gamename/Files
        screenShotName += Time.deltaTime.ToString() + ".png";
        LastName = screenShotName;
		File.WriteAllBytes (Application.persistentDataPath + "/" + screenShotName, screenshot.EncodeToPNG ());
        screenShotName = "PictureShare";

        // on Win7 - it's in project files (Asset folder)
        //File.WriteAllBytes (Application.dataPath + "/" + screenShotName, screenshot.EncodeToPNG ());  
        //File.WriteAllBytes ("picture1.png", screenshot.EncodeToPNG ());
        //File.WriteAllBytes (Application.dataPath + "/../../picture3.png", screenshot.EncodeToPNG ());
        //Application.CaptureScreenshot ("picture2.png");
        GameObject.Find ("Canvas").GetComponent<Canvas> ().enabled = true; // Show UI after we're done
	}

	
    /*public void ShareImage ()
	{
		string path = Application.persistentDataPath + "/" + LastName;
		androidUltimatePluginController.ShareImage ("subject", "subjectContent", path);
	}*/
    
         
   
    

	public void LoadImage ()
	{
        /*string path = Application.persistentDataPath;
		byte[] bytes;
		bytes = System.IO.File.ReadAllBytes(path);
		LoadScreenshot = new Texture2D(5,5);
		LoadScreenshot.LoadImage(bytes);
		GameObject.FindGameObjectWithTag ("Picture").GetComponent<Renderer> ().material.mainTexture = screenshot;*/


        //Application.OpenURL(Application.persistentDataPath);

        /*
        System.Diagnostics.Process p = new System.Diagnostics.Process();
        p.StartInfo = new System.Diagnostics.ProcessStartInfo(Application.persistentDataPath);
        p.Start();*/

       /*AndroidJavaClass jc = new AndroidJavaClass("android.os.Environment");
        string path = jc.CallStatic<AndroidJavaObject>("getExternalStoragePublicDirectory", 
            jc.GetStatic<string>(Application.persistentDataPath)).Call<string>("getAbsolutePath");*/
        

        Debug.Log("Teste");

    }

    public void close ()
	{
        SceneManager.LoadScene("Inicio");
	}
}
