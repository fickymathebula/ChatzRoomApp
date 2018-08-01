using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChatzRoom
{
    class Tweets
    {
        private readonly string tweetsFile = @"C:\DataFiles\tweet.txt";        
        private List<string> tweetFileData = new List<string>();

        public List<string> GetTweets()
        {
            if (File.Exists(tweetsFile))
            {
                using (var str = new StreamReader(tweetsFile))
                {
                    String text;
                    while ((text = str.ReadLine()) != null)
                    {
                        tweetFileData.Add(text);
                    }
                }
            }
            else
            {
                Console.WriteLine("The file tweet.txt not found.");
            }

            return tweetFileData;

        }
    }
}
