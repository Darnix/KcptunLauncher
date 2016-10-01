using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace KcptunLauncher.Controller
{
    public class UpdateController
    {
        private static UpdateController _controller;

        public static UpdateController GetInstance()
        {
            return _controller ?? (_controller = new UpdateController());
        }

        private const string ReleaseUrl = "https://api.github.com/repos/Darnix/KcptunLauncher/releases";

        private const string UserAgent = "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.3319.102 Safari/537.36";

        private readonly string _currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        private readonly string _updateFolderPath = AppDomain.CurrentDomain.BaseDirectory + "update";

        private Release latestRelease { get; set; }
        public Release LatestRelease { get { return latestRelease; } }

        public void StartChecking(bool isAutoCheckUpdate)
        {
            WebClient client = new WebClient();
            client.Headers.Add("User-Agent", UserAgent);
            client.DownloadStringCompleted += (sender, e) =>
            {
                List<Release> releaseList = new List<Release>();

                string result = e.Result;
                JArray releaseJArr = JArray.Parse(result);
                foreach (JObject release in releaseJArr)
                {
                    if ((bool)release["prerelease"]) continue;
                    if (Release.CompareVersion((string)release["name"], _currentVersion) > 0)
                    {
                        releaseList.Add(new Release()
                        {
                            Version = (string)release["name"],
                            FileName = (string)release["assets"][0]["name"],
                            DownloadUrl = (string)release["assets"][0]["browser_download_url"]
                        });
                    }
                }

                if (releaseList.Count <= 0)
                {
                    if (!isAutoCheckUpdate)
                    {
                        MenuControlController.GetInstance()
                            .ShowNotification(5, "KcptunLauncher", "当前已是最新的版本", ToolTipIcon.Info);
                    }
                    return;
                }

                releaseList.Sort(new VersionComparer());

                latestRelease = releaseList[releaseList.Count - 1];
                MenuControlController.GetInstance().ShowNotification(5, "KcptunLauncher", "检测到有新版本，点击此处获取 KcptunLauncher " + latestRelease.Version + " 版本的更新", ToolTipIcon.Info);
            };
            client.DownloadStringAsync(new Uri(ReleaseUrl));
        }

        public void StartUpdating(Release release)
        {
            if (!Directory.Exists(_updateFolderPath))
            {
                Directory.CreateDirectory(_updateFolderPath);
            }

            WebClient client = new WebClient();
            client.Headers.Add("User-Agent", UserAgent);
            client.DownloadFileCompleted += (sender, e) =>
            {
                Process.Start("explorer.exe", _updateFolderPath);
            };
            client.DownloadFileAsync(new Uri(release.DownloadUrl), _updateFolderPath + @"\" + release.FileName);
        }

        public class Release
        {
            public string Version { get; set; }
            public string FileName { get; set; }
            public string DownloadUrl { get; set; }

            public int CompareVersion(string version)
            {
                return CompareVersion(Version, version);
            }

            public static int CompareVersion(string x, string y)
            {
                var xSplit = x.Split('.');
                var ySplit = y.Split('.');
                for (int i = 0; i < Math.Max(xSplit.Length, ySplit.Length); i++)
                {
                    int xVersion = (i < xSplit.Length) ? int.Parse(xSplit[i]) : 0;
                    int yVersion = (i < ySplit.Length) ? int.Parse(ySplit[i]) : 0;
                    if (xVersion != yVersion)
                    {
                        return xVersion - yVersion;
                    }
                }
                return 0;
            }
        }

        public class VersionComparer : IComparer<Release>
        {
            public int Compare(Release x, Release y)
            {
                return Release.CompareVersion(x.Version, y.Version);
            }
        }
    }
}
