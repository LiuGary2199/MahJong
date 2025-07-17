// Project: Plinko
// FileName: YFTool.cs
// Author: AX
// CreateDate: 20230505
// CreateTime: 13:48
// Description:

using UnityEditor;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using LitJson;
using UnityEngine.Assertions.Must;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;
using System.Reflection;


public class YFTool : EditorWindow
{
    //  ���� �������� ����
    private const int funcTplCount = 1; //�����������뺯��ģ�����

    private delegate string FuncTplHandle(string methonName, string param1, string param2, string param3);

    private static FuncTplHandle[] arrFuncTplHandle;
    private static bool isGenerateXcode = false;

    private static string[] excludeFiles = new string[]
    {
        "GameData.cs",
        "DataConfig.cs",
        "GameConfig",
        "GameUtil.cs",
    };
    static List<string> excludeDirectories = new List<string>  // �ų���Ŀ¼
    {
        "\\Resources\\Assets",
        "\\Resources\\LevelJson",
        "\\Resources\\LevelJson",
        "\\Resources\\Data",
        "\\Resources\\HappyDT",
        "\\Resources\\Prefab\\boardPrefab",
        "Script\\Editor",
        "\\Resources\\GameConstructSet",

        "\\Resources\\LevelConstructSets",

        "\\Resources\\Theme",

    };

    //private static string scripteEncoding = "gb2312";
    private static string scripteEncoding = "utf-8";
    private static string scriptFilePath = Application.dataPath + "/Script";

    //��Դ�ļ�����������
    private static string audioFilePath = Application.dataPath + "/Resources/Audio";
    private static string texFilePath = Application.dataPath + "/Art/Tex";
    private static string texFilePath2 = Application.dataPath + "/Resources/Art/Tex";
    private static string prefabFilePath = Application.dataPath + "/Resources/Prefab";
    private static string panelFilePath = Application.dataPath + "/Resources/UIPanel";
    // private static string panelCsFilePath = Application.dataPath + "/Script/UI";
    private static string assetPath = Application.dataPath;


    private static List<string> audioFileTypeList = new List<string>() { "mp3", "wav", "MP3", "WAV" };
    private static List<string> texFileTypeList = new List<string>() { "png", "PNG", "jpg", "JPG" };
    private static List<string> prefabFileTypeList = new List<string>() { "prefab" };
    private static List<string> scriptFileTypeList = new List<string>() { "cs" };

    private static List<string> allAssetFileTypeList = new List<string>()
        {"mp3", "wav", "MP3", "WAV", "png", "PNG", "jpg", "JPG", "prefab", "prefab", "cs"};


    private static List<string> fileList;
    private static List<string> newFileList;
    private static List<string> fileNameList;

    private static Dictionary<int, List<string>> words;
    static Dictionary<string, string> wordDic = new Dictionary<string, string>();

    [MenuItem("Tools/�������")]
    public static void ReNameFile()
    {
        InitLengthDic(Application.dataPath + "/Editor/words.txt");
        InitWordDic(Application.dataPath + "/Editor/WordDic.csv");

        ReNameTexFile();
        ReNameTexFile2();
        ReNameAudioFile();
        ReNamePrefabFile();
        ReNamePanelFile();
        ReNameScriptFile();
        ModifiedFileGuid();


        // �����ֵ�д���ĵ�
        string content = "";
        foreach (string key in wordDic.Keys)
        {
            content += key + "," + wordDic[key] + "\n";
        }
        using (StreamWriter sw = new StreamWriter(Application.dataPath + "/Editor/WordDic.csv"))
        {
            sw.WriteLine(content);
        }
    }

    private static void ReNameAudioFile()
    {
        fileList = new List<string>();
        fileNameList = new List<string>();
        GetFileList(audioFilePath, audioFileTypeList);
        ReNameFile(fileList);
        DealAudioJson();
    }


    private static void ReNameTexFile()
    {
        fileList = new List<string>();
        fileNameList = new List<string>();
        GetFileList(texFilePath, texFileTypeList);
        ReNameFile(fileList);
    }

    private static void ReNameTexFile2()
    {
        fileList = new List<string>();
        fileNameList = new List<string>();
        GetFileList(texFilePath2, texFileTypeList);
        ReNameFile(fileList);
    }

    private static void ReNamePrefabFile()
    {
        fileList = new List<string>();
        fileNameList = new List<string>();
        GetFileList(prefabFilePath, prefabFileTypeList);
        ReNameFile(fileList);
    }

    private static void ReNamePanelFile()
    {
        fileList = new List<string>();
        fileNameList = new List<string>();
        GetFileList(panelFilePath, prefabFileTypeList);
        ReNameFile(fileList);
        DealUIFormJson();
    }

    private static void ReNameScriptFile()
    {
        fileList = new List<string>();
        newFileList = new List<string>();

        fileNameList = new List<string>();
        GetFileList(scriptFilePath, scriptFileTypeList);
        ReNameFile(fileList);

        GetNewFileList(scriptFilePath, scriptFileTypeList);
        ChangeContext(newFileList);
    }

    private static void ModifiedFileGuid()
    {
        fileList = new List<string>();
        fileNameList = new List<string>();
        GetFileList(assetPath, allAssetFileTypeList);
        string[] guids = GetGuidList(fileList);
        ModifiedGuid(guids);
    }


    // ȫ�� �������� �滻
    private static void ChangeContext(List<string> tarFileList)
    {
        List<string> nameList = new List<string>();
        foreach (string fileName in fileNameList)
        {
            if (fileName.EndsWith(".cs"))
            {
                nameList.Add(fileName.Substring(0, fileName.Length - 3));
            }
        }


        foreach (string filePath in tarFileList)
        {
            Debug.Log(filePath);
            StreamReader sr = new StreamReader(filePath, Encoding.GetEncoding(scripteEncoding));
            String fileContent = sr.ReadToEnd().TrimStart();
            sr.Close();
            sr.Dispose();
            if (!string.IsNullOrEmpty(fileContent))
            {
                foreach (string oldName in nameList)
                {
                    string newStr = ChangeWord(oldName);
                    string regStr = @"\WthisStr\W".Replace("thisStr", oldName);
                    Regex s = new Regex(regStr);
                    // Debug.Log(regStr);
                    // string temp  = Regex.Replace(fileContent, regStr, newStr);
                    MatchCollection c = s.Matches(fileContent);
                    // MatchCollection c = Regex.Matches(fileContent, regStr);
                    foreach (Match match in c)
                    {
                        string str = match.Groups[0].ToString();
                        string newTempStr = str.Replace(oldName, newStr);
                        fileContent = fileContent.Replace(str, newTempStr);
                    }

                    // fileContent = ReplaceText(fileContent, oldName, prefixStr);
                }

                StreamWriter streamWriter = new StreamWriter(filePath, false, Encoding.GetEncoding(scripteEncoding));
                streamWriter.Write(fileContent);
                streamWriter.Close();
                streamWriter.Dispose();
                //File.WriteAllText(filePath, fileContent);
                //�ر���
                sr.Close();
                //������
                sr.Dispose();
            }
            else
            {
                sr.Close();
                //������
                sr.Dispose();
            }
        }
    }


    // �������ļ�
    private static void ReNameFile(List<string> tarFileList)
    {
        foreach (string path in tarFileList)
        {
            int num = Application.dataPath.Length;
            string str = "Assets" + path.Substring(num, path.Length - num);
            GUID guid = AssetDatabase.GUIDFromAssetPath(str);
            string guidPath = AssetDatabase.GUIDToAssetPath(guid);
            if (guidPath != null)
            {
                string[] name = guidPath.Split('/');
                string fileName = name[name.Length - 1];
                fileNameList.Add(fileName);
                //string newName = prefixStr + fileName;
                string newName = ChangeWord(fileName);
                string newPath = guidPath.Replace(fileName, newName);

                AssetDatabase.RenameAsset(guidPath, newName);
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    // ��ȡGuid
    private static string[] GetGuidList(List<string> tarFileList)
    {
        List<string> guidList = new List<string>();

        foreach (string path in tarFileList)
        {
            int num = Application.dataPath.Length;
            string str = "Assets" + path.Substring(num, path.Length - num);
            GUID guid = AssetDatabase.GUIDFromAssetPath(str);
            if (guid != null)
            {
                guidList.Add(guid.ToString());
            }
        }

        return guidList.ToArray();
    }


    // ��ȡ�ļ�List
    private static void GetFileList(string filePath, List<string> fileTypeList)
    {
        DirectoryInfo fileDir = new DirectoryInfo(filePath);
        if (fileDir.Exists)
        {
            FileSystemInfo[] fsinfos = fileDir.GetFileSystemInfos();

            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                string fileFullName = fsinfo.FullName;

                if (Directory.Exists(fileFullName))
                {
                    //GetFileList(fileFullName, fileTypeList);
                    // �жϵ�ǰĿ¼�Ƿ����ų��б��У������������еݹ����
                    if (!excludeDirectories.Any(excludePath => fileFullName.Contains(excludePath)))
                    {
                        GetFileList(fileFullName, fileTypeList);
                    }
                }
                else
                {
                    if (excludeFiles.Where(file => fileFullName.Contains(file)).Count() == 0)
                    {
                        string[] arr = fileFullName.Split('.');
                        string fileType = arr[arr.Length - 1];
                        if (fileTypeList.Contains(fileType))
                        {
                            fileList.Add(fileFullName);
                        }
                    }
                }
            }
        }
    }


    // ������ �ļ�List
    private static void GetNewFileList(string filePath, List<string> fileTypeList)
    {
        DirectoryInfo fileDir = new DirectoryInfo(filePath);
        FileSystemInfo[] fsinfos = fileDir.GetFileSystemInfos();

        foreach (FileSystemInfo fsinfo in fsinfos)
        {
            string fileFullName = fsinfo.FullName;

            if (Directory.Exists(fileFullName))
            {
                GetNewFileList(fileFullName, fileTypeList);
            }
            else
            {
                if (excludeFiles.Where(file => fileFullName.Contains(file)).Count() == 0)
                {
                    string[] arr = fileFullName.Split('.');
                    string fileType = arr[arr.Length - 1];
                    if (fileTypeList.Contains(fileType))
                    {
                        newFileList.Add(fileFullName);
                    }
                }
            }
        }
    }


    // ���� audio  json
    private static void DealAudioJson()
    {
        string audioJsonPath = Application.dataPath + "/Resources/Audio/AudioInfo.json";
        StreamReader sr = new StreamReader(audioJsonPath, Encoding.UTF8);
        String fileContent = sr.ReadToEnd().TrimStart();
        sr.Close();
        sr.Dispose();
        if (!string.IsNullOrEmpty(fileContent))
        {
            JsonData shopJson = JsonMapper.ToObject(fileContent);
            for (int i = 0; i < shopJson.Count; i++)
            {
                JsonData obj = shopJson[i];
                AudioJsonData data = JsonMapper.ToObject<AudioJsonData>(JsonMapper.ToJson(obj));
                string filePath = data.filePath;
                string[] arr = filePath.Split('/');
                string fileName = arr[arr.Length - 1];
                filePath = filePath.Substring(0, filePath.Length - fileName.Length);
                data.filePath = filePath + ChangeWord(fileName);
                Debug.Log(data.filePath);
                JsonData newObj = JsonMapper.ToObject(JsonMapper.ToJson(data));
                shopJson[i] = newObj;
            }

            string newText = JsonMapper.ToJson(shopJson);
            File.WriteAllText(audioJsonPath, newText);
            //�ر���
            sr.Close();
            //������
            sr.Dispose();
        }
        else
        {
            sr.Close();
            //������
            sr.Dispose();
        }
    }


    // ���� UIform json
    private static void DealUIFormJson()
    {
        string uiFormJsonOld = Application.dataPath + "/Resources/UIFormsConfigInfo.json";
        StreamReader sr = new StreamReader(uiFormJsonOld, Encoding.UTF8);
        String fileContent = sr.ReadToEnd().TrimStart();
        sr.Close();
        sr.Dispose();
        if (!string.IsNullOrEmpty(fileContent))
        {
            string keyName = "ConfigInfo";
            JsonData uiFormJson = JsonMapper.ToObject(fileContent);
            JsonData valueData = uiFormJson[keyName];
            // for (int i = valueData.Count - 1; i < 0; i--)
            for (int i = 0; i < valueData.Count; i++)
            {
                JsonData obj = valueData[i];
                UiFormJsonData jsonData = JsonMapper.ToObject<UiFormJsonData>(JsonMapper.ToJson(obj));
                string name = jsonData.Key;
                if (fileNameList.Contains(name + ".prefab"))
                {
                    string value = jsonData.Value;

                    Debug.Log(name);
                    Debug.Log(value);
                    string[] arr = value.Split('\\');
                    string fileName = arr[arr.Length - 1];
                    value = value.Substring(0, value.Length - fileName.Length);
                    jsonData.Value = value + ChangeWord(fileName);
                    jsonData.Key = ChangeWord(jsonData.Key);
                    JsonData newObj = JsonMapper.ToObject(JsonMapper.ToJson(jsonData));
                    valueData[i] = newObj;
                }
            }

            uiFormJson[keyName] = valueData;

            string newText = JsonMapper.ToJson(uiFormJson);
            File.WriteAllText(uiFormJsonOld, newText);
            //�ر���
            sr.Close();
            //������
            sr.Dispose();
        }
        else
        {
            sr.Close();
            //������
            sr.Dispose();
        }
    }


    /*
     *  ���ɻ�������
     * * 
     */

    private static void PlSearchFiles(string filePath)
    {
        DirectoryInfo fileDir = new DirectoryInfo(filePath);

        FileSystemInfo[] fsinfos = fileDir.GetFileSystemInfos();
        foreach (FileSystemInfo fsinfo in fsinfos)
        {
            string fileFullName = fsinfo.FullName;
            if (Directory.Exists(fileFullName))
            {
                PlSearchFiles(fsinfo.FullName);
            }
            else
            {
                if (fileFullName.EndsWith(".cs"))
                {
                    //Encoding encoding = GetType(fileFullName);
                    StreamReader sr = new StreamReader(fileFullName, System.Text.Encoding.UTF8);
                    String fileContent = sr.ReadToEnd().TrimStart();
                    sr.Close();
                    sr.Dispose();
                    if (!string.IsNullOrEmpty(fileContent))
                    {
                        string timeNow = DateTime.Now.ToString();
                        GarbageCodeParam funcTplParam = GetFuncTplParam(timeNow + fsinfo.Name,
                            UnityEngine.Random.Range(fsinfos.Length, fsinfos.Length * 2));
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.AppendLine(fileContent);
                        stringBuilder.AppendLine("");
                        stringBuilder.AppendFormat("public class {0} \n", funcTplParam.className);
                        stringBuilder.AppendLine("{");


                        string funcContent = GetFuncContent(funcTplParam.mainFuncName,
                            funcTplParam.mainFuncParam1, funcTplParam.mainFuncParam2, funcTplParam.mainFuncParam3);
                        stringBuilder.Append(funcContent);

                        stringBuilder.AppendLine("}");
                        File.WriteAllText(fsinfo.FullName, stringBuilder.ToString());
                        //�ر���
                        sr.Close();
                        //������
                        sr.Dispose();
                    }
                    else
                    {
                        sr.Close();
                        sr.Dispose();
                    }
                }
            }
        }
    }

    //��ȡ�����壨��������ģ��������ɣ�
    private static string GetFuncContent(string methonName, string param1, string param2, string param3)
    {
        //���û�г�ʼ�����ʼ������ģ��
        if (null == arrFuncTplHandle || arrFuncTplHandle.Length < funcTplCount)
        {
            arrFuncTplHandle = new FuncTplHandle[funcTplCount];
            arrFuncTplHandle[0] = FuncTpl1;
        }

        //���һ��ģ�����ɺ�����
        int randNum = UnityEngine.Random.Range(0, funcTplCount);
        if (arrFuncTplHandle[randNum] == null)
        {
            Debug.LogError("�����ڷ�ʽ��������" + randNum.ToString());
            return "";
        }

        return arrFuncTplHandle[randNum](methonName, param1, param2, param3);
    }


    private static GarbageCodeParam GetFuncTplParam(string timeNow, int index)
    {
        //���ݵ�ǰʱ��+���+��ǰʱ��� ����md5ֵ
        string md5 = CalcMd5(timeNow + index.ToString() + (System.DateTime.Now).ToFileTime().ToString());
        md5 = "_" + md5;

        //��md5ֵ������������ں�������������
        GarbageCodeParam garbageCodeParam = new GarbageCodeParam();
        garbageCodeParam.className = md5;
        garbageCodeParam.mainFuncName = md5 + "m";
        garbageCodeParam.mainFuncParam1 = md5 + "a";
        garbageCodeParam.mainFuncParam2 = md5 + UnityEngine.Random.Range(0, 100);
        garbageCodeParam.mainFuncParam3 = md5 + "c";
        return garbageCodeParam;
    }


    /// <summary>
    /// �����ַ�����MD5ֵ
    /// </summary>
    private static string CalcMd5(string source)
    {
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        byte[] data = System.Text.Encoding.UTF8.GetBytes(source);
        byte[] md5Data = md5.ComputeHash(data, 0, data.Length);
        md5.Clear();

        string destString = "";
        for (int i = 0; i < md5Data.Length; i++)
        {
            destString += System.Convert.ToString(md5Data[i], 16).PadLeft(2, '0');
        }

        destString = destString.PadLeft(32, '0');
        return destString;
    }

    //����ģ��1
    private static string FuncTpl1(string methonName, string param1, string param2, string param3)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendFormat("    int {0}2(int {1})\n", methonName, param1);
        stringBuilder.AppendLine("    {");
        stringBuilder.AppendFormat("        return (int)(3.1415926535897932384626433832795028841 * {0} * {0});\n",
            param1);
        stringBuilder.AppendLine("    }");
        stringBuilder.AppendLine("");
        if (isGenerateXcode)
        {
            //��ں���xcodeû��public
            stringBuilder.AppendFormat("    int {0}(int {1},int {2},int {3} = 0) \n", methonName, param1, param2,
                param3);
        }
        else
        {
            stringBuilder.AppendFormat("    public int {0}(int {1},int {2},int {3} = 0) \n", methonName, param1, param2,
                param3);
        }

        stringBuilder.AppendLine("    {");
        stringBuilder.AppendFormat("        int t{0}p = {0} * {1};\n", param1, param2);
        stringBuilder.AppendFormat("        if ({1} != 0 && t{0}p > {1})\n", param1, param3);
        stringBuilder.AppendLine("        {");
        stringBuilder.AppendFormat("            t{1}p = t{1}p / {0};\n", param3, param1);
        stringBuilder.AppendLine("        }");
        stringBuilder.AppendLine("        else");
        stringBuilder.AppendLine("        {");
        stringBuilder.AppendFormat("            t{1}p -= {0};\n", param3, param1);
        stringBuilder.AppendLine("        }");
        stringBuilder.AppendLine("");
        stringBuilder.AppendFormat("        return {0}2(t{1}p);\n", methonName, param1);
        stringBuilder.AppendLine("    }");
        return stringBuilder.ToString();
    }


    // �޸� Guid
    private static void ModifiedGuid(string[] selectGuids)
    {
        var assetGUIDS = AssetGUIDRegenerator.ExtractGUIDs(selectGuids, false);

        AssetDatabase.StartAssetEditing();
        AssetGUIDRegenerator.RegenerateGUIDs(assetGUIDS);
        AssetDatabase.StopAssetEditing();
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }


    internal class AssetGUIDRegenerator
    {
        private const string SearchFilter = "t:Object";

        private static readonly string[] SearchDirectories = { "Assets" };

        public static void RegenerateGUIDs(string[] selectedGUIDs)
        {
            var assetGUIDs = AssetDatabase.FindAssets(SearchFilter, SearchDirectories);

            var updatedAssets = new Dictionary<string, int>();
            var skippedAssets = new List<string>();

            var inverseReferenceMap = new Dictionary<string, HashSet<string>>();

            foreach (var selectedGUID in selectedGUIDs)
            {
                inverseReferenceMap[selectedGUID] = new HashSet<string>();
            }

            var scanProgress = 0;
            var referencesCount = 0;
            foreach (var guid in assetGUIDs)
            {
                scanProgress++;
                var path = AssetDatabase.GUIDToAssetPath(guid);
                if (IsDirectory(path)) continue;

                var dependencies = AssetDatabase.GetDependencies(path);
                foreach (var dependency in dependencies)
                {
                    var dependencyGUID = AssetDatabase.AssetPathToGUID(dependency);
                    if (inverseReferenceMap.ContainsKey(dependencyGUID))
                    {
                        inverseReferenceMap[dependencyGUID].Add(path);

                        var metaPath = AssetDatabase.GetTextMetaFilePathFromAssetPath(path);
                        inverseReferenceMap[dependencyGUID].Add(metaPath);

                        referencesCount++;
                    }
                }
            }

            var countProgress = 0;

            foreach (var selectedGUID in selectedGUIDs)
            {
                var newGUID = GUID.Generate().ToString();
                try
                {
                    var assetPath = AssetDatabase.GUIDToAssetPath(selectedGUID);
                    var metaPath = AssetDatabase.GetTextMetaFilePathFromAssetPath(assetPath);

                    var metaContents = File.ReadAllText(metaPath);

                    if (assetPath.EndsWith(".unity"))
                    {
                        skippedAssets.Add(assetPath);
                        continue;
                    }

                    var metaAttributes = File.GetAttributes(metaPath);
                    var bIsInitiallyHidden = false;

                    if (metaAttributes.HasFlag(FileAttributes.Hidden))
                    {
                        bIsInitiallyHidden = true;
                        HideFile(metaPath, metaAttributes);
                    }

                    metaContents = metaContents.Replace(selectedGUID, newGUID);
                    File.WriteAllText(metaPath, metaContents);

                    if (bIsInitiallyHidden) UnhideFile(metaPath, metaAttributes);

                    if (IsDirectory(assetPath))
                    {
                        updatedAssets.Add(AssetDatabase.GUIDToAssetPath(selectedGUID), 0);
                        continue;
                    }

                    var countReplaced = 0;
                    var referencePaths = inverseReferenceMap[selectedGUID];
                    foreach (var referencePath in referencePaths)
                    {
                        countProgress++;

                        if (IsDirectory(referencePath)) continue;

                        var contents = File.ReadAllText(referencePath);

                        if (!contents.Contains(selectedGUID)) continue;

                        contents = contents.Replace(selectedGUID, newGUID);
                        File.WriteAllText(referencePath, contents);

                        countReplaced++;
                    }

                    updatedAssets.Add(AssetDatabase.GUIDToAssetPath(selectedGUID), countReplaced);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    EditorUtility.ClearProgressBar();
                }
            }
        }

        public static string[] ExtractGUIDs(string[] selectedGUIDs, bool includeFolders)
        {
            var finalGuids = new List<string>();
            foreach (var guid in selectedGUIDs)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                if (IsDirectory(assetPath))
                {
                    string[] searchDirectory = { assetPath };

                    if (includeFolders) finalGuids.Add(guid);
                    finalGuids.AddRange(AssetDatabase.FindAssets(SearchFilter, searchDirectory));
                }
                else
                {
                    finalGuids.Add(guid);
                }
            }

            return finalGuids.ToArray();
        }

        private static void HideFile(string path, FileAttributes attributes)
        {
            attributes &= ~FileAttributes.Hidden;
            File.SetAttributes(path, attributes);
        }

        private static void UnhideFile(string path, FileAttributes attributes)
        {
            attributes |= FileAttributes.Hidden;
            File.SetAttributes(path, attributes);
        }

        public static bool IsDirectory(string path) => File.GetAttributes(path).HasFlag(FileAttributes.Directory);
    }

    // �����ֵ䣬key:����
    static Dictionary<int, List<string>> InitLengthDic(string filePath)
    {
        words = new Dictionary<int, List<string>>();

        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            // ���ж�ȡ�ļ����ݣ�ֱ�������ļ�ĩβ
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Contains(' ') || line.Contains('-') || line.Contains('.') || line.Contains('(') || line.Contains('\'') || line.Contains('/'))
                {
                    continue;
                }
                line = line.Trim();
                int len = line.Length;
                if (!words.ContainsKey(len))
                {
                    words.Add(len, new List<string>());
                }
                words[len].Add(line);
            }
        }

        return words;
    }

    // ��ʼ��Ԥ���趨���ֵ�
    static void InitWordDic(string filePath)
    {
        wordDic = new Dictionary<string, string>();
        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            // ���ж�ȡ�ļ����ݣ�ֱ�������ļ�ĩβ
            while ((line = sr.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                if (words.Length == 2)
                {
                    if (!wordDic.ContainsKey(words[0]))
                    {
                        wordDic.Add(words[0].Trim(), words[1].Trim());
                    }
                }
            }
        }
    }

    // ���ַ������շ�ָ���滻��ͬ���ȵ���
    static string ChangeWord(string input)
    {
        string[] inputs = input.Split('.');
        string suffix = ""; // ��׺
        if (inputs.Length > 1)
        {
            suffix = "." + inputs[inputs.Length - 1];
        }
        string name = input.Substring(0, input.Length - suffix.Length);

        if (wordDic.ContainsKey(name))
        {
            return wordDic[name] + suffix;
        }

        // ƥ����������ĸ�Ӵ����������ʽ
        Regex regex = new Regex("[a-zA-Z]+");
        // ƥ����
        MatchCollection matches = regex.Matches(name);
        string result = name;
        foreach (Match match in matches)
        {
            string substr = match.Value;
            string newName = "";
            if (wordDic.ContainsKey(substr))
            {
                newName = wordDic[substr];
            }
            else
            {
                string[] names = SplitCamelCase(substr);    // �����շ�ָ�
                foreach (string name2 in names)
                {
                    if (wordDic.ContainsKey(name2))
                    {
                        newName += wordDic[name2];
                    }
                    else
                    {
                        if (words.ContainsKey(name2.Length))
                        {
                            List<string> list = words[name2.Length];
                            System.Random random = new System.Random();
                            // ����һ���������
                            int randomIndex = random.Next(list.Count);
                            string randomWord = CapitalizeFirstLetter(list[randomIndex]);
                            newName += CapitalizeFirstLetter(randomWord);
                            wordDic.Add(name2, randomWord);
                        }
                        else
                        {
                            newName += name2;
                        }
                    }
                }
                if (!wordDic.ContainsKey(substr)) wordDic.Add(substr, newName);
            }
            if (!string.IsNullOrEmpty(newName))
            {
                result = result.Replace(substr, newName);
            }
        }

        if (!wordDic.ContainsKey(name)) wordDic.Add(name, result);
        return result + suffix;
    }

    // �շ����ָ��ַ���
    static string[] SplitCamelCase(string input)
    {
        // ʹ���������ʽƥ���շ��ʽ�ַ���
        // �ڴ�д��ĸǰ���ӿո�Ȼ��ʹ�ÿո�ָ��ַ���
        string pattern = @"(?<!^)(?=[A-Z])";
        string[] words = Regex.Split(input, pattern);
        return words;
    }

    // ����ĸ��д
    static string CapitalizeFirstLetter(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        // ����һ���ַ�ת��Ϊ��д��Ȼ��ʣ�ಿ�ֱ��ֲ���
        return char.ToUpper(input[0]) + input.Substring(1);
    }
}


public class AudioJsonData
{
    public string name { get; set; }
    public double volume { get; set; }
    public string filePath { get; set; }
}

public class UiFormJsonData
{
    public string Key { get; set; }
    public string Value { get; set; }
}

public class GarbageCodeParam
{
    public string className; //����
    public string mainFuncName; //��ں�����
    public string mainFuncParam1; //��ں�������1
    public string mainFuncParam2; //��ں�������2
    public string mainFuncParam3; //��ں�������3
}