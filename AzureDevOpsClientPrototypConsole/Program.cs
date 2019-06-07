using System;

namespace AzureDevOpsClientPrototyp {
    class Program {
        static void Main(string[] args) {
            string orgName = "thomasgassner";
            var personalAccessToken = "TODO";
            var projectName = "Test";
            int workItemId = 1;

            AzureDevOpsClientPrototypLogic.Downloader downloader = new AzureDevOpsClientPrototypLogic.Downloader();
            Console.WriteLine(downloader.download(orgName, personalAccessToken, projectName, workItemId));
        }
    }
}
