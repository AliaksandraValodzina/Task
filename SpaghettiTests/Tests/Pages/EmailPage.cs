﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Tests.Pages
{
    public class EmailPage
    {
        [FindsBy(How = How.ClassName, Using = "asl T-I-J3 J-J5-Ji")]
        public IWebElement ButtonSpam { get; set; }

        private IWebDriver driver;

        public EmailPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public HomePage addLetterToSpam()
        {
            ButtonSpam.Click();
            return new HomePage(driver);
        }
    }
}