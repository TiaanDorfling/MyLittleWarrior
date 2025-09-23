using MLW.Model;


namespace MLW.Controller;

public class CampaignData
{
    public Dictionary<int, CampaignStage> campaignStageData = new Dictionary<int, CampaignStage>();

    // The single instance of the Player class.
    private static CampaignData _instance;

    // A lock object to ensure thread-safe creation.
    private static readonly object _lock = new object();

    // The private constructor prevents direct instantiation.
    private CampaignData()
    {
        campaignStageData = initCampaignData();
    }
    private Dictionary<int, CampaignStage> initCampaignData()
    {
        ICharacterFactory enemyFactory = new GoblinFactory();

        campaignStageData.Add(1, new CampaignStage
        {
            Name = "The beginning of time",
            Enemy = enemyFactory.CreateCharacter(),
            GoldReward = 50,
            EquipmentReward = new Equipment(),
            Completed = false,
        });
        campaignStageData.Add(2, new CampaignStage
        {
            Name = "The break of dawn",
            Enemy = enemyFactory.CreateCharacter(),
            GoldReward = 50,
            EquipmentReward = new Equipment(),
            Completed = false,
        });
        campaignStageData.Add(3, new CampaignStage
        {
            Name = "The icy cold night",
            Enemy = enemyFactory.CreateCharacter(),
            GoldReward = 50,
            EquipmentReward = new Equipment(),
            Completed = false,
        });
        campaignStageData.Add(4, new CampaignStage
        {
            Name = "The soothing sunset",
            Enemy = enemyFactory.CreateCharacter(),
            GoldReward = 50,
            EquipmentReward = new Equipment(),
            Completed = false,
        });
        campaignStageData.Add(5, new CampaignStage
        {
            Name = "The dark night",
            Enemy = enemyFactory.CreateCharacter(),
            GoldReward = 50,
            EquipmentReward = new Equipment(),
            Completed = false,
        });

        return campaignStageData;
    }

    // Public static method to get the single instance.
    public static CampaignData Instance
    {
        get
        {
            // Thread-safe check to ensure only one instance is created.
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new CampaignData();
                }
                return _instance;
            }
        }
    }

    public void DisplayStages()
    {
        int firstUncompletedStageKey = campaignStageData.FirstOrDefault(s => !s.Value.Completed).Key;

        //if all stages are complete
        if (firstUncompletedStageKey == 0)
        {
            // Display the list of available campaign stages
            Console.Clear();
            Console.WriteLine("--- Campaign Stages ---");
            foreach (var stage in campaignStageData)
            {
                Console.WriteLine($"{stage.Key}. {stage.Value.Name}");
            }
            Console.WriteLine("-------------------------");
            Console.Write("Enter the number of the stage you wish to play: ");
        }
        else
        {
            // Display the list of available campaign stages
            Console.Clear();
            Console.WriteLine("--- Campaign Stages ---");
            for (int i = 1; i <= firstUncompletedStageKey; i++)
            {
                Console.WriteLine($"{i}. {campaignStageData[i].Name}");
            }
            Console.WriteLine("-------------------------");
            Console.Write("Enter the number of the stage you wish to play: ");
        }
    }

    public bool IsValidStage(int stageNumber)
    {
        if (campaignStageData[stageNumber].Completed == true)
        {
            return true;
        }
        else
        {
            if (stageNumber == 1 || campaignStageData[stageNumber - 1].Completed == true)
            {
                return true;
            }
        }

        return false;
    }
}
