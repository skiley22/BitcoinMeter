using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace JSONreader
{
    public class User
    {
        public string username { get; set; }
        public string status { get; set; }
        public string currSpeed { get; set; }
        public string joinDt { get; set; }
        public string lastSeen { get; set; }
        public string active { get; set; }
        public double estimated { get; set; }
        public double unconfirmed { get; set; }
        public double historical { get; set; }
        public double unpaid { get; set; }
        public List<object> solvedBlocks { get; set; }
        public string efficiency { get; set; }
        public int requested { get; set; }
        public int submitted { get; set; }
    }

    public class Pool
    {
        public string currentRound { get; set; }
        public string currentSpeed { get; set; }
    }

    public class RootObject
    {
        public User User { get; set; }
        public Pool Pool { get; set; }
    }
    public class Serializer
    {
        public String json = "";
        public String output = "";
        public User user;
        public Pool pool;
        public Serializer()
        {
            var serializer = new JavaScriptSerializer();
            var webClient = new WebClient();
			var userGet = "/*username here*/"
            json = webClient.DownloadString("https://www.bitcoinpool.com/user.php?u="+userGet+"&json=1");

            var newObject = new RootObject();

            try
            {
                newObject = serializer.Deserialize<RootObject>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            user = new User();
            setUser(newObject.User);

            pool = new Pool();
            setPool(newObject.Pool);

         
            output = "Username: " + user.username + "\n Status: " + user.status + "\n Current Speed: " + user.currSpeed + "\n Join Date: " + user.joinDt + "\n Last seen: " + user.lastSeen + "\n Active: " + user.active + "\n Estimated: " + user.estimated + "\n Unconfirmed: " + user.unconfirmed + "\n Historial: " + user.historical + "\n Unpaid: " + user.unpaid + "\n Solved Blocks: " + user.solvedBlocks + "\n Efficiency: " + user.efficiency + "\n Requested: " + user.requested + "\n Submitted: " + user.submitted + "\n \n Pool: \n Current Round: " + pool.currentRound + "\n Current Speed: " + pool.currentSpeed;

            setString(output);
            

        }
        public void setString(String _s)
        {
            output = _s;
        }
        public String getString()
        {
            //return json;
            return output;
        }
        public void setUser(User _user)
        {
            user = _user;
        }
        public User getUser()
        {
            return user;
        }
        public void setPool(Pool _pool)
        {
            pool = _pool;
        }
        public Pool getPool()
        {
            return pool;
        }
    }

}
