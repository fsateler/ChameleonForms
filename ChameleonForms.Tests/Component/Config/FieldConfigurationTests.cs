﻿using System.Collections.Generic;
using ApprovalTests.Html;
using ApprovalTests.Reporters;
using ChameleonForms.Component;
using ChameleonForms.Component.Config;
using ChameleonForms.Enums;
using NUnit.Framework;

namespace ChameleonForms.Tests.Component.Config
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
    class FieldConfigurationShould
    {
        [Test]
        public void Proxy_html_attributes()
        {
            var fc = Field.Configure()
                .Attr("data-attr1", "value")
                .Attr(data_attr2 => "value")
                .Attrs(new Dictionary<string, object> {{"data-attr3", "value"}})
                .Attrs(new {data_attr4 = "value"})
                .Attrs(data_attr5 => "value")
                .AddClass("someclass");

            HtmlApprovals.VerifyHtml(fc.Attributes.ToHtmlString());
        }

        [Test]
        public void Set_textarea_attributes()
        {
            var fc = Field.Configure()
                .Rows(5)
                .Cols(60);

            HtmlApprovals.VerifyHtml(fc.Attributes.ToHtmlString());
        }

        [Test]
        public void Set_inline_label()
        {
            var fc = Field.Configure()
                .InlineLabel("Some label text");

            Assert.That(fc.InlineLabelText, Is.EqualTo("Some label text"));
        }

        [Test]
        public void Set_label()
        {
            var fc = Field.Configure()
                .Label("Some label text");

            Assert.That(fc.LabelText, Is.EqualTo("Some label text"));
        }

        [Test]
        public void Use_default_display_by_default()
        {
            var fc = Field.Configure();
            Assert.That(fc.DisplayType, Is.EqualTo(FieldDisplayType.Default));
        }

        [Test]
        public void Set_list_display()
        {
            var fc = Field.Configure()
                .AsList();

            Assert.That(fc.DisplayType, Is.EqualTo(FieldDisplayType.List));
        }

        [Test]
        public void Set_select_display()
        {
            var fc = Field.Configure()
                .AsDropDown();

            Assert.That(fc.DisplayType, Is.EqualTo(FieldDisplayType.DropDown));
        }

        [Test]
        public void Use_yes_as_true_string_by_default()
        {
            var fc = Field.Configure();
            
            Assert.That(fc.TrueString, Is.EqualTo("Yes"));
        }

        [Test]
        public void Allow_override_for_true_string()
        {
            var fc = Field.Configure().WithTrueAs("Hello");

            Assert.That(fc.TrueString, Is.EqualTo("Hello"));
        }

        [Test]
        public void Use_no_as_false_string_By_default()
        {
            var fc = Field.Configure();

            Assert.That(fc.FalseString, Is.EqualTo("No"));
        }

        [Test]
        public void Allow_override_for_false_string()
        {
            var fc = Field.Configure().WithTrueAs("World!");

            Assert.That(fc.TrueString, Is.EqualTo("World!"));
        }
    }
}