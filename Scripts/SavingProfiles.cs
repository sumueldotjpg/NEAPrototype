using Godot;
using System;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;
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
            string filePath = @"D:\NEA Stuff\Project Folder\NEAPrototype\Saves\Profiles.json";
            List<string> savingProfiles = new List<string>();

            foreach(SaveProfile profile in AllObjects.allProfiles)
            {
                string jsonString = JsonSerializer.Serialize(profile);
                savingProfiles.Add(jsonString);
            }

            File.AppendAllLines(filePath,savingProfiles);
        }

        public static void LoadProfiles()
        {

            using (StreamReader r = new StreamReader(@"D:\NEA Stuff\Project Folder\NEAPrototype\Saves\Profiles.json"))
            {
                string json = r.ReadToEnd();
                AllObjects.ProfileLoad(JsonSerializer.Deserialize<List<SaveProfile>>(json,options));
            }
        }
    }
}

