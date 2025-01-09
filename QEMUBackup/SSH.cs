using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QEMUBackup
{
    public class SSH
    {
        private ConnectionInfo connectionInfo;

        public SSH(string host, int port, string username, string password)
        {
            if (port == 0)
            {
                port = 22;
            }
            connectionInfo = new ConnectionInfo(host, port, username, new PasswordAuthenticationMethod(username, password));
        }

        public string ExecuteSSHCommand(string remoteCommand)
        {
            string result;
            using (var ssh = new SshClient(connectionInfo))
            {
                ssh.Connect();
                var command = ssh.CreateCommand(remoteCommand);
                result = command.Execute();
                ssh.Disconnect();
            }

            return result;
        }
    }
}
