using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using Utility.Diagnostics;
using PackageInfo = UnityEditor.PackageManager.PackageInfo;


public class GeneratePackagesInfo
{
    private const string FILE_NAME = "PackagesInfo.txt";
    
    [MenuItem(itemName: "thief01/Packages in SDK/Generate packages list")]
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

        string packagesList = $"Generated: {DateTime.Now} Packages using in WRA-SDK PROJECT: \n";
        for (int i = 0; i < packages.Length; i++)
        {
            packagesList += packages[i].name +"\n";
        }

        var writer = File.CreateText(path + "/PackagesInfo.txt");
        writer.Write(packagesList);
        writer.Close();

        WraDiagnostics.Log("Project succesfully generated packages info");
        AssetDatabase.Refresh();
    }

    [MenuItem(itemName: "thief01/Packages in SDK/Check packages")]
    public static void CheckPackages()
    {
        var path = Application.dataPath + "/WRA-SDK";
        if (!File.Exists(path + "/" + FILE_NAME))
        {
            WraDiagnostics.LogError($"Not found packages list file path: {path + "/" + FILE_NAME}");
            return;
        }

        var packagesList = PackageInfo.GetAllRegisteredPackages().ToList();
        var packagesInSDK = File.ReadAllLines(path + "/" + FILE_NAME).ToList();
        packagesInSDK.RemoveAt(0);

        string notFoundPackages = "";
        string foundPackages = "";

        for (int i = 0; i < packagesInSDK.Count; i++)
        {
            var found = packagesList.Find(ctg => ctg.name == packagesInSDK[i]);
            if (found == null)
            {
                notFoundPackages += packagesInSDK[i] + "\n";
            }
            else
            {
                foundPackages += packagesInSDK[i] + "\n";
            }
        }
        
        WraDiagnostics.LogError(notFoundPackages, Color.red);
        WraDiagnostics.Log(foundPackages, Color.green);
    }
}
