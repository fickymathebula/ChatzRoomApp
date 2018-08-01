using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChatzRoom
{
    class Program
    {
        private static Users users = new Users();
        private static Tweets tweets = new Tweets();       

        static void Main(string[] args)                
        {
            List<string> _users = new List<string>();
            List<string> _followers = new List<string>();
            List<string> _tweets = tweets.GetTweets();

            foreach (var usersItems in users.ReadUsersFile())
            {   
                // defining new text format to work with
                string strNewLine = usersItems.Replace("follows ", "").Replace(",","");

                // get followers info into list to use in tweets
                _followers.Add(strNewLine);
                // get all users in the list
                var allUsers = strNewLine.Split(' ');
                
                // using Linq to remove duplicates from the list & sort the list
                _users = allUsers.Distinct().OrderBy(x => x) .ToList();
            }
            
           
            // Prepare message to print
            string msg = "";

            foreach (var user in _users) 
            {
                msg += user + "\n";              

                // Search for tweets for people followed by user
                foreach (var folowerList in _followers)
                {
                    var strFollowers = folowerList.Split(' ');

                    if (user == strFollowers[0]) // this user is following someone
                    {
                        string followed = "";

                        for (int x = 0; x < strFollowers.Count(); x++)
                        {                             
                            if (x != 0)
                            {
                                followed = strFollowers[x].ToString();

                                //PrintTweets(_tweets, followed, msg);
                                foreach (var tweets in _tweets)
                                {
                                    var userTweets = tweets.Split('>'); // Check tweets

                                    if (followed == userTweets[0])
                                    {
                                        msg += "\t@" + followed + ": " + userTweets[1] + "\n";
                                    }
                                }
                            }
                            
                        }
                    }
                    else // user is not following anyone so check if has tweeted and print own tweet
                    {
                        foreach (var tweets in _tweets)
                        {
                            var userTweets = tweets.Split('>');

                            if (user == userTweets[0])
                            {
                                msg += "\t@" + user + ": " + userTweets[1] + "\n";
                            }
                        }

                        //PrintTweets(_tweets, user, msg);
                        break; // Exit once printed user tweets
                    }                    
                }
            }

            Console.WriteLine(msg);
            Console.ReadKey();
            
        }

        public static string PrintTweets(List<string> tweetList, string tweeter, string msg)
        {
            foreach (var tweets in tweetList)
            {
                var userTweets = tweets.Split('>'); // Check tweets

                if (tweeter == userTweets[0])
                {
                    msg += "\t@" + tweeter + ": " + userTweets[1] + "\n";
                }
            }
            return msg;

        }

    }
}
