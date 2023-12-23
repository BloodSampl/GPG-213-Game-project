//using System.Collections;
//using System.Collections.Generic;
//using System.Xml;
//using UnityEngine;

//public class Location : MonoBehaviour
//{
//    public string playerPrefsKey = "Country";

//    private void Start()
//    {
//        getGeographicalCoordinates();
//    }

//    public void getGeographicalCoordinates()
//    {
//        if (Input.location.isEnabledByUser)
//            StartCoroutine(getGeographicalCoordinatesCoroutine());
//    }
//    private IEnumerator getGeographicalCoordinatesCoroutine()
//    {
//        Debug.Log("Finding location");
//        Input.location.Start();
//        int maximumWait = 20;
//        while (Input.location.status == LocationServiceStatus.Initializing && maximumWait > 0)
//        {
//            yield return new WaitForSeconds(1);
//            maximumWait--;
//        }
//        if (maximumWait < 1 || Input.location.status == LocationServiceStatus.Failed)
//        {
//            Input.location.Stop();
//            yield break;
//        }
//        float latitude = Input.location.lastData.latitude;
//        float longitude = Input.location.lastData.longitude;
//        //      Asakusa.
//        //      float latitude = 35.71477f;
//        //      float longitude = 139.79256f;
//        Input.location.Stop();
//        WWW www = new WWW("https://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latitude + "," + longitude + "&sensor=true");
//        yield return www;
//        if (www.error != null) yield break;
//        XmlDocument reverseGeocodeResult = new XmlDocument();
//        reverseGeocodeResult.LoadXml(www.text);
//        if (reverseGeocodeResult.GetElementsByTagName("status").Item(0).ChildNodes.Item(0).Value != "OK") yield break;
//        string countryCode = null;
//        bool countryFound = false;
//        foreach (XmlNode eachAdressComponent in reverseGeocodeResult.GetElementsByTagName("result").Item(0).ChildNodes)
//        {
//            if (eachAdressComponent.Name == "address_component")
//            {
//                foreach (XmlNode eachAddressAttribute in eachAdressComponent.ChildNodes)
//                {
//                    if (eachAddressAttribute.Name == "short_name") countryCode = eachAddressAttribute.FirstChild.Value;
//                    if (eachAddressAttribute.Name == "type" &&  eachAddressAttribute.FirstChild.Value == "country")
//                        countryFound = true;
//                }
//                if (countryFound) break;
//            }
//        }
//        if (countryFound && countryCode != null)
//        {
//            PlayerPrefs.SetString(playerPrefsKey, countryCode);
//            Debug.Log("Country: " + countryCode);
//        }
//        else
//        {
//            Debug.Log("Country not found");

//        }
//    }
//}
