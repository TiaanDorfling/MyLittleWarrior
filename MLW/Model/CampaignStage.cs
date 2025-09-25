using MLW.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLW.Model;

public class CampaignStage
{
    public string Name { get; set; }
    public Character Enemy { get; set; }
    public int GoldReward { get; set; }
    public Equipment EquipmentReward { get; set; }
    public Boolean Completed { get; set; }
}
