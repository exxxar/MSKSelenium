using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSKSelenium
{
    class Program
    {
        static void Main(string[] args)
        {

            var login = "soundon"; 
            var pass = "9OPTsjS";

         
        

                    var options = new ChromeOptions();
            //options.AddArgument("no-sandbox");
            options.AddArguments("--disable-extensions");
            // options.AddArgument("no-sandbox");
            options.AddArgument("--incognito");
            // options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            if (!Directory.Exists(@"D:\DataTest"))
                Directory.CreateDirectory(@"D:\DataTest");

            options.AddUserProfilePreference("download.default_directory", @"D:\DataTest");

            ChromeDriver driver = new ChromeDriver(options);//открываем сам браузер


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //время ожидания компонента страницы после загрузки страницы
            driver.Manage().Cookies.DeleteAllCookies();

            driver.Navigate().GoToUrl("http://portal.moskvorechie.ru/login.lmz");



            IWebElement element = driver.FindElement(By.CssSelector("[name='username']"));
            element.SendKeys(login);
            System.Threading.Thread.Sleep(2000);
            element = driver.FindElement(By.CssSelector("[name='password']"));
            element.SendKeys(pass);
            System.Threading.Thread.Sleep(2000);
            element = driver.FindElement(By.CssSelector("[name='submit']"));
            element.SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(2000);
            driver.Navigate().GoToUrl("http://portal.moskvorechie.ru/index.lmz#g10");
            System.Threading.Thread.Sleep(2000);

            try
            {
                driver.FindElements(By.CssSelector($"input[name='u']"))
                    .ToArray()
                    .ToList()
                    .ForEach(el =>
                    {
                        el.SendKeys(Keys.Space);
                    });


            }
            catch
            {

            }

            /* Выбор типа загрузки (без типа загрузки качаем xls файлы)
             element = driver.FindElement(By.CssSelector("[name='ff']"));
             element.SendKeys(Keys.ArrowDown);
             element.SendKeys(Keys.ArrowDown);
             */

            element = driver.FindElement(By.CssSelector("[name='f'] option"));
            element.Click();
         

         
            System.Threading.Thread.Sleep(2000);

            element = driver.FindElement(By.CssSelector("[name='fl']"));
            element.SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(2000);
            element = driver.FindElement(By.CssSelector("[name='uc']"));
            element.SendKeys(Keys.Space);
          
          
            try
            {
            driver.FindElements(By.CssSelector($".checktree li input[type='checkbox']"))
                .ToArray()
                .ToList()
                .ForEach(el =>
                {
                    el.SendKeys(Keys.Space);
                });
                
                  
            }
            catch
            {

            }
            
            element = driver.FindElement(By.CssSelector("[name='get']"));
            element.SendKeys(Keys.Enter);

            System.Threading.Thread.Sleep(10000);
            element = driver.FindElement(By.CssSelector("[href ='/my_pricelist.lmz?']"));
            element.SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(1000);
            try
            {
                driver.FindElements(By.CssSelector($"a[href*='/price/']"))
                    .ToArray()
                    .ToList()
                    .ForEach(el =>
                    {
                        el.SendKeys(Keys.Enter);
                        System.Threading.Thread.Sleep(5000);
                    });


            }
            catch
            {

            }

            
            driver.Close();
            driver.Dispose();
        }
    }
}
