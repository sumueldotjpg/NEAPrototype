using Godot;
using System;
using System.Text.Json;
using System.Collections;
using System.Collections.Generic;
using Variables;
using System.IO;

namespace Main
{
    public class SaveManager
    {
        public static void SaveProfiles()
        {
            SaveProfile test = new SaveProfile("sam",20000000,null,null,null);

            string jsonString = JsonSerializer.Serialize(test);
            string filePath = @"D:\NEA Stuff\Project Folder\NEAPrototype\Saves\Profiles.json";

            File.WriteAllText(filePath, jsonString);
        }

        public static void LoadProfiles()
        {
            AllObjects.allProfiles.Add(new SaveProfile("This Profile",200000000,null,null,null));
        }
    }
}

