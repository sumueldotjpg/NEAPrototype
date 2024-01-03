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
        static JsonSerializerSettings settings = new JsonSerializerSettings{TypeNameHandling = TypeNameHandling.Objects};
        public static void SaveProfiles()
        {
            string filePath = @"Saves/Profiles.json";
            
            string jsonProfiles = JsonConvert.SerializeObject(AllObjects.allProfiles, settings);
            File.WriteAllText(filePath,jsonProfiles);
        }

        public static void LoadProfiles()
        {
            string filePath = @"Saves/Profiles.json";

            if(!File.Exists(filePath))
            {
                List<SaveProfile> newProfiles = new List<SaveProfile>();
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    newProfiles = new List<SaveProfile>(){
                    new SaveProfile("Profile 1" , 0, 0,new List<POI>(){}, new List<NPC>(), new List<Upgrade>(){AllObjects.allUpgrades[0],AllObjects.allUpgrades[1],AllObjects.allUpgrades[2],AllObjects.allUpgrades[3]},new List<Attack>(){AllObjects.allAttacks[0]},new List<Multiplier>{}),
                    new SaveProfile("Profile 2" , 0, 0,new List<POI>(){}, new List<NPC>(), new List<Upgrade>(){AllObjects.allUpgrades[0],AllObjects.allUpgrades[1],AllObjects.allUpgrades[2],AllObjects.allUpgrades[3]},new List<Attack>(){AllObjects.allAttacks[0]},new List<Multiplier>{}),
                    new SaveProfile("Profile 3" , 0, 0,new List<POI>(){}, new List<NPC>(), new List<Upgrade>(){AllObjects.allUpgrades[0],AllObjects.allUpgrades[1],AllObjects.allUpgrades[2],AllObjects.allUpgrades[3]},new List<Attack>(){AllObjects.allAttacks[0]},new List<Multiplier>{}),
                    new SaveProfile("Profile 4" , 0, 0,new List<POI>(){}, new List<NPC>(), new List<Upgrade>(){AllObjects.allUpgrades[0],AllObjects.allUpgrades[1],AllObjects.allUpgrades[2],AllObjects.allUpgrades[3]},new List<Attack>(){AllObjects.allAttacks[0]},new List<Multiplier>{}),
                    };      
                    
                    sw.Write(JsonConvert.SerializeObject(newProfiles));
                }
                AllObjects.ProfileLoad(newProfiles);
            }
            else
            {
                string jsonProfiles = File.ReadAllText(filePath);
                settings.TypeNameHandling = TypeNameHandling.Auto;
                List<SaveProfile> deserializedProfiles = JsonConvert.DeserializeObject<List<SaveProfile>>(jsonProfiles,settings);
                settings.TypeNameHandling = TypeNameHandling.Objects; // Preventing a possible future 

                AllObjects.ProfileLoad(deserializedProfiles);
            }
        }
    }
}

