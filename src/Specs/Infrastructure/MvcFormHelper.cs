﻿using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Web.Mvc;
using OpenQA.Selenium;

namespace Specs.Infrastructure
{
    public class MvcFormHelper<TViewModel> 
    {
        private readonly IWebDriver _driver;

        public MvcFormHelper(IWebDriver driver)
        {
            _driver = driver;
        }
        
        public TProperty Get<TProperty>(Expression<Func<TViewModel, TProperty>> expression)
        {
            var element = FindElement(expression);
            var rawValue = element.Text;
            var value = new ValueProviderResult(rawValue, rawValue, CultureInfo.CurrentCulture).ConvertTo(typeof (TProperty));
            return (TProperty) value;
        }

        public void Set<TProperty>(Expression<Func<TViewModel, TProperty>> expression, TProperty value)
        {
            var element = FindElement(expression);
            element.Clear();

            if (Equals(value, null))
                return;

            element.SendKeys(value.ToString());
        }

        public void Submit<TProperty>(Expression<Func<TViewModel, TProperty>> expression)
        {
            var element = FindElement(expression);
            element.Submit();
        }

        public string FindElementName<TProperty>(Expression<Func<TViewModel, TProperty>> expression)
        {
            return MvcContrib.UI.InputBuilder.Helpers.ReflectionHelper.BuildNameFrom(expression);
        }

        public string FindElementId<TProperty>(Expression<Func<TViewModel, TProperty>> expression)
        {
            return HtmlHelper.GenerateIdFromName(FindElementName(expression));
        }

        public IWebElement FindElement<TProperty>(Expression<Func<TViewModel, TProperty>> expression)
        {
            return _driver.FindElement(By.Id(FindElementId(expression)));
        }

    }
}
