using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace QEMUBackup.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class IndexModel : PageModel
    {
        public string MainSelection { get; set; }
        public string[] MainSelectionValues = new[] { "List Virtual Machines(列出所有虚拟机)",
                                                      "List Virtual Machines With Backups(列出所有虚拟机备份信息)",
                                                      "Get Virtual Machine XML(展示所选虚拟机XML)",
                                                      "Get Virtual Machine Details(展示所选虚拟机详情)",
                                                      "Set Virtual Machine Details(设置所选虚拟机详情)",
                                                      "List Virtual Machine Backups(列出所选虚拟机所有备份)",
                                                      "Backup Virtual Machine(备份所选虚拟机)" };

        public string Host { get; private set; }
        public int Port { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string BackupPath { get; private set; }


        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string host = System.Environment.GetEnvironmentVariable("QEMUBackupHost", EnvironmentVariableTarget.Process);
            string username = System.Environment.GetEnvironmentVariable("QEMUBackupUsername", EnvironmentVariableTarget.Process);
            string backupPath = System.Environment.GetEnvironmentVariable("QEMUBackupBackupPath", EnvironmentVariableTarget.Process);

            Host = host;
            Port = 22;
            Username = username;
            Password = "";
            BackupPath = backupPath;
        }
    }
}
