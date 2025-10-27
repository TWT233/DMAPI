using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace DMAPI.ModBuildConfig;

public class DeployModTask : Task
{
    /// <summary>The name (without extension or path) of the current mod's DLL.</summary>
    [Required]
    public string ModDllName { get; set; }

    /// <summary>The folder containing the game's mod folders.</summary>
    [Required]
    public string GameModsDir { get; set; }

    /// <summary>The folder containing the project files.</summary>
    [Required]
    public string ProjectDir { get; set; }

    /// <summary>The folder containing the build output.</summary>
    [Required]
    public string TargetDir { get; set; }

    public override bool Execute()
    {
        try
        {
            // ensure target folder
            Directory.CreateDirectory(GameModsDir + "/" + ModDllName);

            var ok = GetFilesNeedCopy(out var filePairs);
            if (!ok)
            {
                LogErr("failed to get required file, skip deploy");
                return false;
            }

            foreach (var (src, dst) in filePairs)
            {
                File.Copy(src, dst, true);
            }
        }
        catch (Exception ex)
        {
            LogErr("Exception raised when deploy: " + ex);
            return false;
        }

        return true;
    }

    private bool GetFilesNeedCopy(out IEnumerable<(string, string)> filePairs)
    {
        var dstDir = Path.Combine(GameModsDir, ModDllName);
        filePairs = [];

        var dllPath = Path.Combine(TargetDir, ModDllName + ".dll");
        if (!File.Exists(dllPath))
        {
            LogErr("missing " + dllPath + ", can not deploy");
            return false;
        }

        filePairs = filePairs.Append((dllPath, Path.Combine(dstDir, ModDllName + ".dll")));

        var iniPath = Path.Combine(ProjectDir, "info.ini");
        if (!File.Exists(iniPath))
        {
            LogErr("missing " + iniPath + ", can not deploy");
            return false;
        }

        filePairs = filePairs.Append((iniPath, Path.Combine(dstDir, "info.ini")));

        var previewPath = Path.Combine(ProjectDir, "preview.png");
        if (File.Exists(previewPath)) // optional file
        {
            filePairs = filePairs.Append((previewPath, Path.Combine(dstDir, "preview.png")));
        }

        return true;
    }


    private void LogErr(string message, params object[] messageArgs)
    {
        Log.LogError("[DMAPI][ModBuildConfig] " + message, messageArgs);
    }

    private void LogInfo(string message, params object[] messageArgs)
    {
        Log.LogMessage("[DMAPI][ModBuildConfig] " + message, messageArgs);
    }
}