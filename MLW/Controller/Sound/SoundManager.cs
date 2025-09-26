using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MLW.Controller.Sound;

public class SoundManager
{
    public SoundManager() { }
    // Define the folder where the sounds are copied
    private const string SoundFolder = "SoundEffects";

    // --- The character's sound property would now be just the file names ---
    public static readonly string[] BasicAttackSounds = new string[]
    {
    "man1.wav",
    "man2.wav"
    };

    public static void PlayRandomAttackSound()
    {
        string soundFileName = BasicAttackSounds[1];

        // 2. Construct the FULL path using the SoundFolder
        // Path.Combine is the safest way to join paths, handling slashes correctly across operating systems.
        //string soundFilePath = Path.Combine(
        //    Environment.CurrentDirectory,
        //    SoundFolder,
        //    soundFileName
        //);
        string soundFilePath = Path.Combine(
           Environment.CurrentDirectory,
           SoundFolder,
           soundFileName
       );

        // 3. Play the sound (with error handling)
        if (File.Exists(soundFilePath))
        {
            try
            {
                SoundPlayer player = new SoundPlayer(soundFilePath);
                player.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SFX Error: Could not play {soundFileName}. {ex.Message}]");
            }
        }
        else
        {
            Console.WriteLine($"[SFX Error: File not found at {soundFilePath}]");
        }
    }

    public static void PlayRandomAttackSoundForPlayer()
    {
        string soundFileName = BasicAttackSounds[0];

        // 2. Construct the FULL path using the SoundFolder
        // Path.Combine is the safest way to join paths, handling slashes correctly across operating systems.
        string soundFilePath = Path.Combine(
            Environment.CurrentDirectory,
            SoundFolder,
            soundFileName
        );

        // 3. Play the sound (with error handling)
        if (File.Exists(soundFilePath))
        {
            try
            {
                SoundPlayer player = new SoundPlayer(soundFilePath);
                player.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SFX Error: Could not play {soundFileName}. {ex.Message}]");
            }
        }
        else
        {
            Console.WriteLine($"[SFX Error: File not found at {soundFilePath}]");
        }
    }
}
