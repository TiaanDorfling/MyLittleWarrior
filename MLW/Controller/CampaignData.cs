using MLW.Model;


namespace MLW.Controller;

public class CampaignData
{
    public static Dictionary<int, CampaignStage> campaignStageData = new Dictionary<int, CampaignStage>();

    public Dictionary<int, CampaignStage> initCampaignData()
    {
        ICharacterFactory enemyFactory = new GoblinFactory();

        campaignStageData.Add(1, new CampaignStage
        {
            Name = "The beginning of time",
            Enemy = enemyFactory.CreateCharacter(),
            GoldReward = 50,
            EquipmentReward = new Equipment()
        });
        campaignStageData.Add(2, new CampaignStage
        {
            Name = "The break of dawn",
            Enemy = enemyFactory.CreateCharacter(),
            GoldReward = 50,
            EquipmentReward = new Equipment()
        });
        campaignStageData.Add(3, new CampaignStage
        {
            Name = "The icy cold night",
            Enemy = enemyFactory.CreateCharacter(),
            GoldReward = 50,
            EquipmentReward = new Equipment()
        });
        campaignStageData.Add(4, new CampaignStage
        {
            Name = "The soothing sunset",
            Enemy = enemyFactory.CreateCharacter(),
            GoldReward = 50,
            EquipmentReward = new Equipment()
        });
        campaignStageData.Add(5, new CampaignStage
        {
            Name = "The dark night",
            Enemy = enemyFactory.CreateCharacter(),
            GoldReward = 50,
            EquipmentReward = new Equipment()
        });

        return campaignStageData;
    }
}
