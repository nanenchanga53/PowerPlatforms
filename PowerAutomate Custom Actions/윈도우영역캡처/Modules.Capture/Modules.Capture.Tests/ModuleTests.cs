using Microsoft.PowerPlatform.PowerAutomate.Desktop.Actions.SDK.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Modules.Capture.Tests
{
    [TestClass]
    public class ModuleTests
    {
        [TestMethod]
        public void Module_IsValid()
        {
            string moduleDllPath = "C:\\Users\\���â\\source\\repos\\Modules.Module1\\Modules.Module1\\bin\\Debug\\Modules.Module1.dll"; //TODO: Set correct dll path
            bool isValid = ModuleValidator.IsValid(moduleDllPath, out var errors);

            Assert.IsTrue(isValid, $"Module is invalid. Validation Errors: {Environment.NewLine}{string.Join(Environment.NewLine, errors)}");
        }
    }
}
