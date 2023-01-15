using System.Collections.Generic;
using Patterns;

namespace Utility
{
    public class LogController : Singleton<LogController>
    {
        private List<Dictionary<string, string>> log = new List<Dictionary<string, string>>();
        private int maxInLog = -1;


        public void SetMaxInLog(int count)
        {
            maxInLog = count;
            CheckLog();
        }
    
        public void AddLog(Dictionary<string, string> info)
        {
            log.Add(info);
            CheckLog();
        }

        public List<Dictionary<string, string>> GetFullLog()
        {
            return log;
        }

        public List<Dictionary<string, string>> GetLastMessages(int count)
        {
            List<Dictionary<string, string>> lastMessages = new List<Dictionary<string, string>>();

            for (int i = log.Count-1 - count; i < log.Count; i++)
            {
                lastMessages.Add(log[i]);
            }

            return lastMessages;
        }

        private void CheckLog()
        {
            if (maxInLog==-1)
                return;
            if (log.Count < maxInLog)
                return;
            int diff = log.Count - maxInLog;
            for (int i = 0; i < diff; i++)
            {
                log.RemoveAt(0);
            }
        }
    }
}
