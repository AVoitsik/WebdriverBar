using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace OzTests
{
   // [TestClass]
    public class ChromeSettings
    {
        [TestMethod]
        [Ignore]
        public void ChromeOptions()
        {
            //------OBSOLETE----
            //DesiredCapabilities capability = new DesiredCapabilities();
            //capability.SetCapability("platform", "WIN8");
            //capability.SetCapability("browserName", "internet explorer");
            //capability.SetCapability("version", "11");
            //IWebDriver driver = new FirefoxDriver(capability);
            //IWebDriver driver = new ChromeDriver(capability);
            //IWebDriver driver = new InternetExplorerDriver(capability);

            ChromeOptions options = new ChromeOptions();
            var arguments = options.Arguments;
            var check = options.BinaryLocation;
            var check1 = options.DebuggerAddress;
            var check2 = options.Extensions;
            var check3 = options.LeaveBrowserRunning;
            var check4 = options.MinidumpPath;
            var check5 = options.PerformanceLoggingPreferences;
            var check6 = options.AcceptInsecureCertificates;
            var check7 = options.BrowserName;
            var check8 = options.BrowserVersion;
            var check9 = options.PageLoadStrategy;
            var check10 = options.PlatformName;
            var check11 = options.Proxy;
            var check12 = options.UnhandledPromptBehavior;
            ////options.AddAdditionalCapability("test", true);
            options.AddArgument("check--arguments");
            options.AddArguments(new List<string>() { "arg1", "arg2" });
            //options.AddEncodedExtension("some ext");
            //options.AddEncodedExtensions(new List<string>() { "ext11", "ext2" });
            options.AddExcludedArgument("arg");
            options.AddExcludedArguments(new List<string>() { "arg1", "arg2" });
            //options.AddExtension("pathToExtension");
            //options.AddExtensions(new List<string>() { "path_to_ext1", "path_to_ext2" });
            options.AddLocalStatePreference("locStatepPref", "valie");
            options.AddUserProfilePreference("UserProfPref", "valie");
            options.AddWindowType("webview");
            options.AddWindowTypes(new List<string>() { "webview", "webview" });
            ////options.AddAdditionalCapability("someCapability","value");
            ////options.EnableMobileEmulation("DevicenameFromChromewebToolEmulationPanel");
            var optToCap = options.ToCapabilities();
            options.SetLoggingPreference("someLogType", LogLevel.All);





            IWebDriver driver = new ChromeDriver(options);

            var aarguments = options.Arguments;
            var acheck = options.BinaryLocation;
            var acheck1 = options.DebuggerAddress;
            var acheck2 = options.Extensions;
            var acheck3 = options.LeaveBrowserRunning;
            var acheck4 = options.MinidumpPath;
            var acheck5 = options.PerformanceLoggingPreferences;
            var acheck6 = options.AcceptInsecureCertificates;
            var acheck7 = options.BrowserName;
            var acheck8 = options.BrowserVersion;
            var acheck9 = options.PageLoadStrategy;
            var acheck10 = options.PlatformName;
            var acheck11 = options.Proxy;
            var acheck12 = options.UnhandledPromptBehavior;
            options.AddAdditionalCapability("Atest", true);
            options.AddArgument("Acheck--arguments");
            options.AddArguments(new List<string>() { "Aarg1", "Aarg2" });
            //options.AddEncodedExtension("some ext");
            //options.AddEncodedExtensions(new List<string>() { "ext11", "ext2" });
            options.AddExcludedArgument("Aarg");
            options.AddExcludedArguments(new List<string>() { "Aarg1", "Aarg2" });
            //options.AddExtension("pathToExtension");
            //options.AddExtensions(new List<string>() { "path_to_ext1", "path_to_ext2" });
            options.AddLocalStatePreference("AlocStatepPref", "Avalie");
            options.AddUserProfilePreference("AUserProfPref", "Avalie");
            options.AddWindowType("webview");
            options.AddWindowTypes(new List<string>() { "webview", "webview" });
            options.AddAdditionalCapability("AsomeCapability", "Avalue");
            options.EnableMobileEmulation("ADevicenameFromChromewebToolEmulationPanel");
            var aoptToCap = options.ToCapabilities();
            options.SetLoggingPreference("AsomeLogType", LogLevel.All);
        }


        [TestMethod]
        [Ignore]
        public void TestMethod2()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.LeaveBrowserRunning = false;
            //options.BinaryLocation = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";

            options.AddUserProfilePreference("intl.accept_languages", "ru");
            options.AddUserProfilePreference("download.default_directory", @"C:\Users\SaarBaruch");
            //opt.AddUserProfilePreference("disable-popup-blocking", "false");

            var proxy = new Proxy {HttpProxy = "localhost:8080"};
            options.Proxy = proxy;
            options.BrowserVersion = "IE";


            IWebDriver driver = new ChromeDriver(options);

            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("proxy",proxy);
            //capabilities.SetCapability(ChromeOptions.options);
   

             driver = new ChromeDriver(options);


        }

        [TestMethod]
        [Ignore]
        public void ChromeAttrOptsCapsPrefs()
        {



            //ChromeArguments:https://peter.sh/experiments/chromium-command-line-switches/
            //ChromeArguments:https://chromium.googlesource.com/chromium/src/+/master/chrome/common/chrome_switches.cc
            //ChromePrefs:https://chromium.googlesource.com/chromium/src/+/master/chrome/common/pref_names.cc
            //Capabilities & ChromeOptions + ChromedriverINFO:https://sites.google.com/a/chromium.org/chromedriver/capabilities
            //ChromedriverPI:https://seleniumhq.github.io/selenium/docs/api/dotnet/

            ChromeOptions options = new ChromeOptions();
            DesiredCapabilities capabilities = new DesiredCapabilities();

            IEnumerable<string> atr = new List<string>() { @"user-data-dir=C:\ChromeProfile", "start-maximized" };
            options.AddArguments(atr);
            //options.AddArguments(@"user-data-dir=C:\ChromeProfile", "start-maximized");
            //options.AddArgument("start-maximized");

            //Dictionary<String, Object> prefs = new Dictionary<String, Object>();
            //prefs.Add("profile.default_content_settings.popups", 0);
            options.AddUserProfilePreference("profile.default_content_settings.popups", 0);
            options.AddUserProfilePreference("homepage_is_newtabpage", false);
            options.BinaryLocation=@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            //homepage_is_newtabpage

            //DesiredCapabilities capabilities = new DesiredCapabilities();
            //Proxy proxy = new Proxy();
            //proxy.HttpProxy="myhttpproxy:3337";
            //capabilities.SetCapability("takesScreenshot", false);
            //capabilities.SetCapability(ChromeOptions.Capability, options);
            ////var dict = capabilities.ToDictionary();
            //options.AddAdditionalCapability("binary", "/usr/lib/chromium-browser/chromium-browser");


            IWebDriver driver = new ChromeDriver(options);





            //IWebDriver driver = new ChromeDriver(options);
            var capabils = ((IHasCapabilities) driver).Capabilities;
            //var capabils = ((RemoteWebDriver) driver).Capabilities
            var opts = options.Arguments;





        }
    }

}
