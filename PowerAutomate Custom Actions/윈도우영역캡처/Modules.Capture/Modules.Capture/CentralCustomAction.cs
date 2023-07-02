using Microsoft.PowerPlatform.PowerAutomate.Desktop.Actions.SDK;
using Microsoft.PowerPlatform.PowerAutomate.Desktop.Actions.SDK.Attributes;
using System.ComponentModel;
using System;
using Microsoft.PowerPlatform.PowerAutomate.Desktop.Actions.SDK.ActionSelectors;

public enum SelectorChoice
{
    Selector1,
    Selector2,
    Selector3
}

namespace Modules.Capture
{
    [Action(Id = "SelectNames", Order = 1)]
    [Throws("NameActionError")] // TODO: change error name (or delete if not needed)
    public class CentralCustomAction : ActionBase
    {
        #region Properties

        [InputArgument, DefaultValue(SelectorChoice.Selector1)]
        public SelectorChoice Selector { get; set; }

        [InputArgument(Order = 1)]
        public string FirstName { get; set; }

        [InputArgument(Order = 2)]
        public string LastName { get; set; }

        [InputArgument(Order = 3)]
        public int Age { get; set; }

        [OutputArgument]
        public string DisplayedMessage { get; set; }

        #endregion

        #region Methods Overrides

        public override void Execute(ActionContext context)
        {
            if (Selector == SelectorChoice.Selector1)
            {
                DisplayedMessage = $"Hello, {FirstName}!";
            }
            else if (Selector == SelectorChoice.Selector2)
            {
                DisplayedMessage = $"Hello, {FirstName} {LastName}!";
            }
            else // The 3rd Selector was chosen 
            {
                DisplayedMessage = $"Hello, {FirstName} {LastName}!\nYour age is: {Age}";
            }
        }

        #endregion
    } // you can see below how to implement an action selector


    public class Selector1 : ActionSelector<CentralCustomAction>
    {
        public Selector1()
        {
            UseName("DisplayOnlyFirstName");
            Prop(p => p.Selector).ShouldBe(SelectorChoice.Selector1);
            ShowAll();
            Hide(p => p.LastName);
            Hide(p => p.Age);
            // or 
            // Show(p => p.FirstName); 
            // Show(p => p.DisplayedMessage);
        }
    }

    public class Selector2 : ActionSelector<CentralCustomAction>
    {
        public Selector2()
        {
            UseName("DisplayFullName");
            Prop(p => p.Selector).ShouldBe(SelectorChoice.Selector2);
            ShowAll();
            Hide(p => p.Age);
        }
    }

    public class Selector3 : ActionSelector<CentralCustomAction>
    {
        public Selector3()
        {
            UseName("DisplayFullDetails");
            Prop(p => p.Selector).ShouldBe(SelectorChoice.Selector3);
            ShowAll();
        }
    }
}
