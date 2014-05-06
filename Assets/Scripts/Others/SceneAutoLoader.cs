﻿using UnityEngine;
using UnityEditor;

/// <summary>
/// Scene auto loader.
/// </summary>
/// <description>
/// Данный класс добавляетFile > Scene Autoload в меню, содержащее возможность выбора
/// "мастер сцены", с которой будет осуществляться запуск игры, когда пользователь нажимает Play в редакторе
/// Когда сцена выбрана, она будет запущена при запуске
/// оригинальная сцена будет загружена на остановке
/// </description>
[InitializeOnLoad]
static class SceneAutoLoader
{
    // Static constructor binds a playmode-changed callback.
    // [InitializeOnLoad] above makes sure this gets executed.
    static SceneAutoLoader()
    {
        EditorApplication.playmodeStateChanged += OnPlayModeChanged;
    }

    // Menu items to select the "master" scene and control whether or not to load it.
    [MenuItem("File/Scene Autoload/Select Master Scene...")]
    private static void SelectMasterScene()
    {
        string masterScene = EditorUtility.OpenFilePanel("Select Master Scene", Application.dataPath, "unity");
        if (!string.IsNullOrEmpty(masterScene))
        {
            MasterScene = masterScene;
            LoadMasterOnPlay = true;
        }
    }

    [MenuItem("File/Scene Autoload/Load Master On Play", true)]
    private static bool ShowLoadMasterOnPlay()
    {
        return !LoadMasterOnPlay;
    }
    [MenuItem("File/Scene Autoload/Load Master On Play")]
    private static void EnableLoadMasterOnPlay()
    {
        LoadMasterOnPlay = true;
    }

    [MenuItem("File/Scene Autoload/Don't Load Master On Play", true)]
    private static bool ShowDontLoadMasterOnPlay()
    {
        return LoadMasterOnPlay;
    }
    [MenuItem("File/Scene Autoload/Don't Load Master On Play")]
    private static void DisableLoadMasterOnPlay()
    {
        LoadMasterOnPlay = false;
    }

    // Play mode change callback handles the scene load/reload.
    private static void OnPlayModeChanged()
    {
        if (!LoadMasterOnPlay)
        {
            return;
        }

        if (!EditorApplication.isPlaying && EditorApplication.isPlayingOrWillChangePlaymode)
        {
            // User pressed play -- autoload master scene.
            PreviousScene = EditorApplication.currentScene;
            if (EditorApplication.SaveCurrentSceneIfUserWantsTo())
            {
                if (!EditorApplication.OpenScene(MasterScene))
                {
                    Debug.LogError(string.Format("error: scene not found: {0}", MasterScene));
                    EditorApplication.isPlaying = false;
                }
            }
            else
            {
                // User cancelled the save operation -- cancel play as well.
                EditorApplication.isPlaying = false;
            }
        }
        if (EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode)
        {
            // User pressed stop -- reload previous scene.
            if (!EditorApplication.OpenScene(PreviousScene))
            {
                Debug.LogError(string.Format("error: scene not found: {0}", PreviousScene));
            }
        }
    }

    // Properties are remembered as editor preferences.
    private const string cEditorPrefLoadMasterOnPlay = "SceneAutoLoader.LoadMasterOnPlay";
    private const string cEditorPrefMasterScene = "SceneAutoLoader.MasterScene";
    private const string cEditorPrefPreviousScene = "SceneAutoLoader.PreviousScene";

    private static bool LoadMasterOnPlay
    {
        get { return EditorPrefs.GetBool(cEditorPrefLoadMasterOnPlay, false); }
        set { EditorPrefs.SetBool(cEditorPrefLoadMasterOnPlay, value); }
    }

    private static string MasterScene
    {
        get { return EditorPrefs.GetString(cEditorPrefMasterScene, "Master.unity"); }
        set { EditorPrefs.SetString(cEditorPrefMasterScene, value); }
    }

    private static string PreviousScene
    {
        get { return EditorPrefs.GetString(cEditorPrefPreviousScene, EditorApplication.currentScene); }
        set { EditorPrefs.SetString(cEditorPrefPreviousScene, value); }
    }
}