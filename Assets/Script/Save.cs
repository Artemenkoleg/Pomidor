using UnityEngine;
using System.Collections;
using System.IO;

public class Save : MonoBehaviour
{
    public string fileName;
    /*
    void Awake()
    {
        if (!Directory.Exists("Settings"))
            Directory.CreateDirectory("Settings");

        File.WriteAllLines("Settings/settings.ini", new[] { "test line 1", "test line 2" });
    }
    */

    void Start ()
    {
        //if (fileName == "")
       // {
            fileName = "Data/Save/chvak.eva";
            SaveFile();
       // }
	}
	
	void SaveFile()
    {
        StreamWriter sw = new StreamWriter(fileName);
        sw.WriteLine(Account.accountNum);
        sw.Close();
    }
}
