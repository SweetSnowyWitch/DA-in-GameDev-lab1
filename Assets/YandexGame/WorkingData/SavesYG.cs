using System.Collections.Generic;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Ваши сохранения
        public int score;
        public int bestScore = 0;
        public List<string> achievements = new List<string>();
    }
}
