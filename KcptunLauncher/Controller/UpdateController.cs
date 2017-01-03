using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
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

        private const string UserAgent = "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.3319.102 Safari/537.36";

        private const string ReleaseUrl = "https://api.github.com/repos/Darnix/KcptunLauncher/releases";

        private const string KcptunReleaseUrl = "https://api.github.com/repos/xtaci/kcptun/releases";
        private const string KcptunVersionPatten = @"\bv\d{8}";
        private const string KcptunFileName = @"\bkcptun-windows-386-\d{8}.tar.gz";
        private const string Kcptunx64FileName = @"\bkcptun-windows-amd64-\d{8}.tar.gz";

        private readonly string _currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        private readonly string _updateFolderPath = AppDomain.CurrentDomain.BaseDirectory + "update";

        private Release _latestRelease { get; set; }
        public Release LatestRelease { get { return _latestRelease; } }

        private KcptunRelease _latestKcptunRelease { get; set; }
        public KcptunRelease LatestKcptunRelease { get { return _latestKcptunRelease; } }

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
                            .ShowNotification(10, "KcptunLauncher", "当前已是最新的版本", ToolTipIcon.Info, null);
                    }
                    return;
                }

                releaseList.Sort(new VersionComparer());

                _latestRelease = releaseList[releaseList.Count - 1];
                MenuControlController.GetInstance().ShowNotification(10, "KcptunLauncher", "检测到有新版本，点击此处获取 KcptunLauncher " + _latestRelease.Version + " 版本的更新", ToolTipIcon.Info, (sender2, e2) =>
                {
                    StartUpdating(_latestRelease);
                });
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

        public void StartCheckingKcptun()
        {
            Process mProcess = new Process
            {
                StartInfo =
                {
                    FileName = MainProcessController.KcptunClientFilePath,
                    Arguments = "-v",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true
                }
            };

            mProcess.ErrorDataReceived += (sender, e) => { };
            mProcess.OutputDataReceived += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(e.Data)) return;

                string date = e.Data.Substring(e.Data.Length - 8, 8);

                Check(false, date);
            };

            mProcess.Start();
            mProcess.BeginErrorReadLine();
            mProcess.BeginOutputReadLine();
        }

        public void Check(bool isAutoCheckUpdate, string version)
        {
            WebClient client = new WebClient();
            client.Headers.Add("User-Agent", UserAgent);
            client.DownloadStringCompleted += (sender, e) =>
            {
                List<KcptunRelease> releaseList = new List<KcptunRelease>();

                string aaa = "";

                string result = e.Result; MessageBox.Show(result);
                JArray releaseJArr = JArray.Parse(result);
                foreach (JObject release in releaseJArr)
                {
                    if ((bool)release["prerelease"]) continue;

                    string tagName = release["tag_name"].ToString();

                    if (Regex.IsMatch(tagName, KcptunVersionPatten))
                    {
                        if (KcptunRelease.CompareVersion(tagName.Substring(1, 8), version) > 0)
                        {
                            releaseList.AddRange(from JObject assets in release["assets"]
                                                 where Regex.IsMatch((string)assets["name"], Kcptunx64FileName)
                                                 select new KcptunRelease()
                                                 {
                                                     Version = tagName.Substring(1, 8),
                                                     FileName = (string)assets["name"],
                                                     DownloadUrl = (string)assets["browser_download_url"]
                                                 });
                        }
                    }
                }

                if (releaseList.Count <= 0)
                {
                    if (!isAutoCheckUpdate)
                    {
                        MenuControlController.GetInstance()
                            .ShowNotification(10, "Kcptun", "当前已是最新的版本", ToolTipIcon.Info, null);
                    }
                    return;
                }

                releaseList.Sort(new KcptunVersionComparer());

                _latestKcptunRelease = releaseList[releaseList.Count - 1];
                MenuControlController.GetInstance().ShowNotification(10, "KcptunLauncher", "检测到有新版本，点击此处获取 Kcptun " + _latestKcptunRelease.Version + " 版本的更新", ToolTipIcon.Info,
                    (sender2, e2) =>
                    {
                        StartUpdating(_latestKcptunRelease);
                    });
            };
            client.DownloadStringAsync(new Uri(KcptunReleaseUrl));
            //client.DownloadProgressChanged += (sender, e) =>
            //{
            //    if (e.ProgressPercentage != 0 && e.ProgressPercentage % 10 == 0)
            //    {
            //        MessageBox.Show(e.ProgressPercentage + "");
            //    }
            //};
        }

        public class KcptunRelease : Release
        {
            //public string Version { get; set; }
            //public string FileName { get; set; }
            //public string DownloadUrl { get; set; }

            public new int CompareVersion(string version)
            {
                return CompareVersion(Version, version);
            }

            public new static int CompareVersion(string x, string y)
            {
                if (string.Equals(x, y)) return 0;
                return int.Parse(x) - int.Parse(y);
            }
        }

        public class KcptunVersionComparer : IComparer<KcptunRelease>
        {
            public int Compare(KcptunRelease x, KcptunRelease y)
            {
                return KcptunRelease.CompareVersion(x.Version, y.Version);
            }
        }
    }
}
