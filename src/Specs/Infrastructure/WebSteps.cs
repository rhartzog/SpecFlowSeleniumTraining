﻿using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Specs.Infrastructure
{
    public abstract class WebSteps
    {

        public IWebDriver Browser { get { return ScenarioContext.Current.Get<IWebDriver>(); } }
        public Uri BaseUrl { get { return ScenarioContext.Current.Get<Uri>(); } }

        public Uri RelativeUrl()
        {
            return RelativeUrl(Browser.Url);
        }

        public Uri RelativeUrl(string absoluteUrl)
        {
            return RelativeUrl(new Uri(absoluteUrl, UriKind.Absolute));
        }

        public Uri RelativeUrl(Uri absoluteUri)
        {
            return BaseUrl.MakeRelativeUri(absoluteUri);
        }

        public void NavigateTo(string url)
        {
            var absoluteUrl = new Uri(BaseUrl, url);
            Browser.Navigate().GoToUrl(absoluteUrl);
        }

    }
}
