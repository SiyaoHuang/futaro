using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class FileLoader 
{
    public static string unpackTarget(string file)
    {
        var pre = $"{Application.streamingAssetsPath}/";
        var id = file.IndexOf(pre);
        return unpackFile(file.Substring(id + pre.Length));
    }

    internal static string unpackFile(string file)
    {
#if !UNITY_ANDROID || UNITY_EDITOR
        return $"{Application.streamingAssetsPath}/{file}";
#endif
        var dir = Application.temporaryCachePath + "/";
        if (!File.Exists(dir + file))
        {
            var path = "jar:file://" + Application.dataPath + "!/assets/" + file;
            using (var unpackerWWW = UnityWebRequest.Get(path))
            {
                unpackerWWW.SendWebRequest();
                while (!unpackerWWW.isDone)
                {
                } // This will block in the webplayer.

                if (unpackerWWW.isNetworkError || unpackerWWW.isHttpError)
                {
                    Debug.Log($"Failed to get file \"{path}\": {unpackerWWW.error}");
                    return "";
                }

                var data = unpackerWWW.downloadHandler.data;
                FileInfo fileInfo = new System.IO.FileInfo(dir + file);
                fileInfo.Directory.Create();
                File.WriteAllBytes(fileInfo.FullName, data);
            }
        }

        return dir + file;
    }

    public static BinaryReader LoadStream(string file)
    {
        var results = getFileRaw(file);
        var stream = new MemoryStream(results);
        var binaryStream = new BinaryReader(stream);
        //{
            return binaryStream;
        //}
        //return null;
    }
    // Start is called before the first frame update
    public static byte[] getFile(string file)
    {
        var dir = Application.streamingAssetsPath + "/" + file;

        return getFileRaw(dir);
        //}
    }

    public static byte[] getFileRaw(string file)
    {
        if(file.StartsWith("/")){
            file = file.Substring(1);
        }
        //if (!File.Exists(dir + file))
        //{
        //var path = "jar:file://" + Application.dataPath + "!/assets/" + file;
        using (var unpackerWWW = UnityWebRequest.Get(file))
        {
            unpackerWWW.SendWebRequest();
            while (!unpackerWWW.isDone)
            {
            } // This will block in the webplayer.

            if (unpackerWWW.isNetworkError || unpackerWWW.isHttpError)
            {
                Debug.Log($"Failed to get file \"{file}\": {unpackerWWW.error}");
                return null;
            }

            var data = unpackerWWW.downloadHandler.data;
            //FileInfo fileInfo = new System.IO.FileInfo(dir + file);
            //fileInfo.Directory.Create();
            //File.WriteAllBytes(fileInfo.FullName, data);
            return data;
        }
        //}
    }
}
