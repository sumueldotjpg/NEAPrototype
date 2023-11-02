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
            string filePath = @"Saves/Profiles.json";
            
            string jsonProfiles = JsonConvert.SerializeObject(AllObjects.allProfiles);
            File.WriteAllText(filePath,string.Empty);
            File.AppendAllText(filePath,jsonProfiles);
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
                    new SaveProfile("New Profile 1" , 0, 0,new List<POI>(){AllObjects.allPOIs[0]}, new List<NPC>(), new List<Upgrade>(),new List<Attack>(){AllObjects.allAttacks[0]}),
                    new SaveProfile("New Profile 2" , 0, 0,new List<POI>(){AllObjects.allPOIs[0]}, new List<NPC>(), new List<Upgrade>(),new List<Attack>(){AllObjects.allAttacks[0]}),
                    new SaveProfile("New Profile 3" , 0, 0,new List<POI>(){AllObjects.allPOIs[0]}, new List<NPC>(), new List<Upgrade>(),new List<Attack>(){AllObjects.allAttacks[0]}),
                    new SaveProfile("New Profile 4" , 0, 0,new List<POI>(){AllObjects.allPOIs[0]}, new List<NPC>(), new List<Upgrade>(),new List<Attack>(){AllObjects.allAttacks[0]}),
                    };      
                    
                    sw.Write(JsonConvert.SerializeObject(newProfiles));
                }

                
                AllObjects.ProfileLoad(newProfiles);
            }
            else
            {
                string jsonProfiles = File.ReadAllText(filePath);

                List<SaveProfile> deserializedProfiles = JsonConvert.DeserializeObject<List<SaveProfile>>(jsonProfiles);

                AllObjects.ProfileLoad(deserializedProfiles);
            }
        }
    }
}

