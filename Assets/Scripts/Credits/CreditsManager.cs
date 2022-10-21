using System.Collections.Generic;
using TheDuction.Global;
using UnityEngine;

namespace TheDuction.Credits
{
    public class CreditsManager : SingletonBaseClass<CreditsManager>
    {
        [SerializeField] private Sprite _creditBackgroundSprite;

        private List<Credit> _creditList;

        public Sprite CreditBackgroundSprite => _creditBackgroundSprite;
        public List<Credit> CreditList => _creditList;

        /// <summary>
        /// Set instance and don't destroy on load
        /// </summary>
        private void SetInstance()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
        }

        private void Awake()
        {
            SetInstance();
            _creditList = new List<Credit>();
            ReadFile();
        }

        /// <summary>
        /// Read file CSV or TSV
        /// </summary>
        private void ReadFile()
        {
            TextAsset creditsFile = Resources.Load<TextAsset>("credits");
            if(!creditsFile){
                Debug.LogError("Credits file not found in folder \"Resources/\"");
                return;
            }
            string lines = creditsFile.text;

            ReadLines(lines);
        }

        /// <summary>
        /// Read lines in files and convert it to dictionary
        /// </summary>
        /// <param name="lines"></param>
        private void ReadLines(string lines)
        {
            string[] rows = lines.Split('\n');

            // Assign names
            for (int i = 0; i < rows.Length; i++)
            {
                string[] items = rows[i].Split(';');

                // Get header
                if (i == 0)
                {
                    for (int j = 0; j < items.Length; j++)
                    {
                        string item = items[j].Trim();
                        _creditList.Add(new Credit(j, item, ""));
                    }
                    continue;
                }

                // Get values
                for (int j = 0; j < items.Length; j++)
                {
                    // If null or white space, continue
                    if (string.IsNullOrWhiteSpace(items[j])) continue;
                    // Add names in dict
                    _creditList[j].body += $"{items[j]}\n";
                }
            }
        }
    }
}