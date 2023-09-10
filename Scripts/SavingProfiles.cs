using Godot;
using System;
using Newtonsoft.Json;
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
            string jsonProfiles = JsonConvert.SerializeObject(AllObjects.allProfiles);

            File.AppendAllText(filePath,jsonProfiles);
            GD.Print("Saved");
        }

        public static void LoadProfiles()
        {
            string filePath = @"D:\NEA Stuff\Project Folder\NEAPrototype\Saves\Profiles.json";

            if(!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    List<SaveProfile> newProfiles = new List<SaveProfile>(){
                    new SaveProfile("New Profile 1" , 0, new List<POI>(), new List<NPC>(), new List<Upgrade>()),
                    new SaveProfile("New Profile 2" , 0, new List<POI>(), new List<NPC>(), new List<Upgrade>()),
                    new SaveProfile("New Profile 3" , 0, new List<POI>(), new List<NPC>(), new List<Upgrade>()),
                    new SaveProfile("New Profile 4" , 0, new List<POI>(), new List<NPC>(), new List<Upgrade>()),
                    };      
                    
                    sw.Write(JsonConvert.SerializeObject(newProfiles));
                } 
            }
            else
            {
                string jsonProfiles = File.ReadAllText(filePath);

                List<SaveProfile> deserializedProfiles = (List<SaveProfile>)JsonConvert.DeserializeObject(jsonProfiles);

                AllObjects.ProfileLoad(deserializedProfiles);
                GD.Print("Loaded");
            }
        }
    }
}

