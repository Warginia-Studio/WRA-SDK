using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using Utility.Diagnostics;
using PackageInfo = UnityEditor.PackageManager.PackageInfo;


public class GeneratePackagesInfo
{
    [InitializeOnLoadMethod]
    public static void RunGeneratePackagesInfo()
    {
        if (PlayerSettings.productName != "WRA-SDK")
        {
            WraDiagnostics.Log("Project didn't generate packages info because it isn't SDK project.", Color.yellow);
            return;
        }
        
        var packages = PackageInfo.GetAllRegisteredPackages();
        
        var path = Application.dataPath;
        if (!File.Exists(path + "/PackagesInfo.txt"))
        {
            File.Create(path + "/PackagesInfo.txt");
        }

        string packagesList = "";
        for (int i = 0; i < packages.Length; i++)
        {
            packagesList += packages[i].name +"\n";
        }
        
        File.WriteAllText(path + "/PackagesInfo.txt", packagesList);

        WraDiagnostics.Log("Project succesfully generated packages info");
    }
}
