using NUnit.Framework;
using ApplicationPages.GlobalSQA;
using Assignment_18_VD;
using System.Collections.Generic;

namespace Assignment_16_VD
{
    public class Assignment18Tests : BaseTest
    {
        [Test]
        [Category("Selenium")]
        public void Assignment18_1Test()
        {
            string globalSqaUrl = "https://www.globalsqa.com/";
            string menuFirstLevel = "Tester’s Hub";
            string menuSecondLevel = "Sample Page Test";

            string picName = "cartoon_blackbird.gif";
            string name = "FirstName LastName";
            string email = "firstnamelastname@mail.com";
            string website = "https://www.google.com";
            string experienceValue = "10+";

            Dictionary<string, bool> expertise = new Dictionary<string, bool> {
                { "Functional Testing", true},
                { "Automation Testing", false },
                { "Manual Testing", true }
            };

            string education = "Other";
            string comment = Faker.Lorem.Sentence();


            driver.Url = globalSqaUrl;

            HomePage homePage = new HomePage(driver);
            homePage.menu.navigateTo(menuFirstLevel, menuSecondLevel);

            SamplePageTestPage samplePageTestPage = new SamplePageTestPage(driver);

            samplePageTestPage.UploadProfilePic(picName);
            samplePageTestPage.SetName(name);
            samplePageTestPage.SetEmail(email);
            samplePageTestPage.SetWebsite(website);
            samplePageTestPage.SelectExperience(experienceValue);

            samplePageTestPage.SetExperise(expertise);
            samplePageTestPage.SetEducation(education);
            samplePageTestPage.SetComment(comment);
            samplePageTestPage.SubmitForm();

            SamplePageTestResultPage samplePageTestResultPage = new SamplePageTestResultPage(driver);
            var resultData = samplePageTestResultPage.GetResultFormData();

            Assert.Multiple(() =>
            {
                Assert.True(picName == samplePageTestResultPage.GetProfilePicName(), 
                    $"Expected: {picName}, but got: {samplePageTestResultPage.GetProfilePicName()}");

                Assert.True(name == resultData["Name"], $"Expected: {name}, but got: {resultData["Name"]}");
                Assert.True(email == resultData["Email"], $"Expected: {email}, but got: {resultData["Email"]}");
                Assert.True(website == resultData["Website"], $"Expected: {website}, but got: {resultData["Website"]}");

                Assert.True(experienceValue == resultData["Experience (In Years)"], $"Expected: {experienceValue}, but got: {resultData["Experience (In Years)"]}");
                Assert.True(education == resultData["Education"], $"Expected: {education}, but got: {resultData["Education"]}");
                Assert.True(comment == resultData["Comment"], $"Expected: {comment}, but got: {resultData["Comment"]}");

                Assert.True(samplePageTestResultPage.ConvertExpertiseValues(expertise) == resultData["Expertise"], 
                    $"Expected: {samplePageTestResultPage.ConvertExpertiseValues(expertise)}, but got: {resultData["Expertise"]}");
            });
        }
    }
}