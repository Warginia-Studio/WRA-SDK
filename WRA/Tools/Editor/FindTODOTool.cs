using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using WRA.Utility.Diagnostics;

public class FindTODOTool : MonoBehaviour
{ 
    [MenuItem("thief01/Tools/Find TODO's comments")]
    public static void Find()
    {
        ProcessDirectory(Application.dataPath);
    }
    
    private static void ProcessDirectory(string targetDirectory)
    {
        // Process the list of files found in the directory.
        string [] fileEntries = Directory.GetFiles(targetDirectory, "*.cs");
        foreach(string fileName in fileEntries)
            ProcessFile(fileName);

        // Recurse into subdirectories of this directory.
        string [] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
        foreach(string subdirectory in subdirectoryEntries)
            ProcessDirectory(subdirectory);
    }
    
    private static void ProcessFile(string path)
    {
        // Debug.Log(string.Format("Processed file '{0}'.", path));
        if (path.Contains("FindTODOTool"))
        {
            return;
        }
        
        var lines = File.ReadLines(path).ToList();

        for (int i = 0; i < lines.Count; i++)
        {
            if (lines[i].Contains("// TODO:"))
            {
                LogTodo(path, i.ToString(), lines[i]);
            }
        }
    }

    private static void LogTodo(string file, string lineNumber, string commentTodo)
    {
        WraDiagnostics.Log($"Found TODO in file {Path.GetFileName(file)} in line {lineNumber} comment TODO: {commentTodo}", Color.yellow);
    }
}
