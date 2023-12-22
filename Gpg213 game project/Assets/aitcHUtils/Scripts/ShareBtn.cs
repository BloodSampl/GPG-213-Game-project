using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareBtn : MonoBehaviour
{
    [SerializeField] string androidLink, iosLink;


    private static AndroidJavaObject activity = null;

    private static void CreateActivity()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
    if(activity == null)
        activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").
            GetStatic<AndroidJavaObject>("currentActivity");
#endif

    }

    public static void ShareActivity(string title, string subject, string body)
    {
        CreateActivity();
        AndroidJavaObject sharingIntent = new AndroidJavaObject("android.content.Intent", "android.intent.action.SEND")
                          .Call<AndroidJavaObject>("setType", "text/plain")
                          .Call<AndroidJavaObject>("putExtra", "android.intent.extra.TEXT", body)
                          .Call<AndroidJavaObject>("putExtra", "android.intent.extra.SUBJECT", subject);

        AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent", activity)
                          .CallStatic<AndroidJavaObject>("createChooser", sharingIntent, title);
        activity.Call("startActivity", intent);
    }

    public void onClick_Share() 
    {
        string title = "Musical Line";
        string subject = "Checkout this game!!!";
        string body = "Download this game. " + ((Application.platform == RuntimePlatform.Android) ? androidLink : iosLink);

        ShareActivity(title, subject, body);
    }
}
