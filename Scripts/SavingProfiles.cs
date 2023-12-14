using Godot;
using System;
using Newtonsoft.Json;
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
            string filePath = @"Saves/Profiles.json";
            
            string jsonProfiles = JsonConvert.SerializeObject(AllObjects.allProfiles, new JsonSerializerSettings() {TypeNameHandling = TypeNameHandling.All});
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
                    new SaveProfile("Profile 1" , 0, 0,new List<POI>(){}, new List<NPC>(), new List<Upgrade>(){AllObjects.allUpgrades[0],AllObjects.allUpgrades[1],AllObjects.allUpgrades[2],AllObjects.allUpgrades[3]},new List<Attack>(){AllObjects.allAttacks[0]},new List<Multiplier>{}),
                    new SaveProfile("Profile 2" , 0, 0,new List<POI>(){}, new List<NPC>(), new List<Upgrade>(){AllObjects.allUpgrades[0],AllObjects.allUpgrades[1],AllObjects.allUpgrades[2],AllObjects.allUpgrades[3]},new List<Attack>(){AllObjects.allAttacks[0]},new List<Multiplier>{}),
                    new SaveProfile("Profile 3" , 0, 0,new List<POI>(){}, new List<NPC>(), new List<Upgrade>(){AllObjects.allUpgrades[0],AllObjects.allUpgrades[1],AllObjects.allUpgrades[2],AllObjects.allUpgrades[3]},new List<Attack>(){AllObjects.allAttacks[0]},new List<Multiplier>{}),
                    new SaveProfile("Profile 4" , 0, 0,new List<POI>(){}, new List<NPC>(), new List<Upgrade>(){AllObjects.allUpgrades[0],AllObjects.allUpgrades[1],AllObjects.allUpgrades[2],AllObjects.allUpgrades[3]},new List<Attack>(){AllObjects.allAttacks[0]},new List<Multiplier>{}),
                    };      
                    
                    sw.Write(JsonConvert.SerializeObject(newProfiles, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All }));
                }
                AllObjects.ProfileLoad(newProfiles);
            }
            else
            {
                string jsonProfiles = File.ReadAllText(filePath);

                List<SaveProfile> deserializedProfiles = JsonConvert.DeserializeObject<List<SaveProfile>>(jsonProfiles, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto});

                var economyupgrade = (EconomyUpgrade)(deserializedProfiles[0].UpgradeLevels[0]);
                GD.Print(economyupgrade.GetType());
                GD.Print(deserializedProfiles[0].UpgradeLevels[0]);
                GD.Print(deserializedProfiles[0].UpgradeLevels[0].Description);
                GD.Print("First");

                AllObjects.ProfileLoad(deserializedProfiles);
            }
        }
    }
}

