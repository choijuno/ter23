using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoogleMap : MonoBehaviour
{
    public enum MapType
    {
        RoadMap,
        Satellite,
        Terrain,
        Hybrid
    }
    public RawImage imageDisp;
    public bool loadOnStart = true;
    public bool autoLocateCenter = true;
    public GoogleMapLocation centerLocation;
    public int zoom = 13;
    public MapType mapType;
    public int size = 512;
    public bool doubleResolution = false;
    public GoogleMapMarker[] markers;
    public GoogleMapPath[] paths;
    LocationInfo currentGPSPosition;

    void Start() {
        Input.location.Start(0.5f);
		if(loadOnStart) StartCoroutine(_Refresh_IOS());
    }

    void Update()
    {
        LocationInfo temp_l = Input.location.lastData;
        if (temp_l.latitude != currentGPSPosition.latitude && temp_l.longitude != currentGPSPosition.longitude)
        {
           // Refresh();
        }
    }


    public void Refresh() {
        if(autoLocateCenter && (markers.Length == 0 && paths.Length == 0)) {
            Debug.LogError("Auto Center will only work if paths or markers are used."); 
        }
        StartCoroutine(_Refresh_IOS());
    }

   

    IEnumerator _Refresh_IOS ()
    {
        currentGPSPosition = Input.location.lastData;
      
        var usingSensor = false;
        #if UNITY_IPHONE
        usingSensor = Input.location.isEnabledByUser && Input.location.status == LocationServiceStatus.Running;
        #endif
      
        int m_i = 0;
        string markerdata = "";
        foreach (var i in markers) {

            markerdata += "&markers=" + string.Format ("size:{0}%7Ccolor%3A{1}%7Clabel:{2}", i.size.ToString ().ToLower (), i.color, i.label);
            foreach (var loc in i.locations) {
                if (loc.address != "")
                    markerdata += "%7C" + loc.address;
                else
                {

                    if (m_i != 0)
                        markerdata += "%7C" + string.Format("{0},{1}", loc.latitude, loc.longitude);
                    else 
                        markerdata += "%7C" + string.Format("{0},{1}", currentGPSPosition.latitude, currentGPSPosition.longitude);
                }
            }
            m_i++;
        }

        //Debug.Log(markerdata);

        string keys = "&key=AIzaSyDM58tFvVQv1558qHoe0CdFlWA3jJ18PQI";

		//

		//



        string nurl = "https://maps.googleapis.com/maps/api/staticmap?center=" + "37.57284" + "," + "126.9768" +
			"&zoom="+zoom+"&size=640x640&maptype=" + mapType.ToString().ToLower() + markerdata + keys;

        UnityEngine.Networking.UnityWebRequest www1 = UnityEngine.Networking.UnityWebRequest.GetTexture(nurl);
        yield return www1.Send();
        //GetComponent<Renderer>().material.mainTexture = ((UnityEngine.Networking.DownloadHandlerTexture)www1.downloadHandler).texture;

		//Debug.Log (currentGPSPosition);

        if (www1.isError)
        {
            Debug.Log("Error while downloading image: " + www1.error);
        }
        else
        {
            imageDisp.texture = ((UnityEngine.Networking.DownloadHandlerTexture)www1.downloadHandler).texture;
        }
    }





}


public enum GoogleMapColor
{
    black,
    brown,
    green,
    purple,
    yellow,
    blue,
    gray,
    orange,
    red,
    white
}

[System.Serializable]
public class GoogleMapLocation
{
    public string address;
    public float latitude;
    public float longitude;
}

[System.Serializable]
public class GoogleMapMarker
{
    public enum GoogleMapMarkerSize
    {
        Tiny,
        Small,
        Mid
    }
    public GoogleMapMarkerSize size;
    public GoogleMapColor color;
    public string label;
    public GoogleMapLocation[] locations;

}

[System.Serializable]
public class GoogleMapPath
{
    public int weight = 5;
    public GoogleMapColor color;
    public bool fill = false;
    public GoogleMapColor fillColor;
    public GoogleMapLocation[] locations;   
}