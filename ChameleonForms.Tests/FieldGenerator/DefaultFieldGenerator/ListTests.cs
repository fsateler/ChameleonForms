﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using ApprovalTests.Html;
using ChameleonForms.Component.Config;
using ChameleonForms.FieldGenerators.Handlers;
using NUnit.Framework;

namespace ChameleonForms.Tests.FieldGenerator.DefaultFieldGenerator
{
    class ListTests : DefaultFieldGeneratorShould
    {
        private readonly List<IntListItem> IntList = new List<IntListItem>
        {
            new IntListItem {Id = 1, Name = "A"},
            new IntListItem {Id = 2, Name = "B"}
        };

        private readonly List<StringListItem> StringList = new List<StringListItem>
        {
            new StringListItem { Value = "1", Label = "A" },
            new StringListItem { Value = "2", Label = "B" }
        };

        private FieldGenerators.DefaultFieldGenerator<TestFieldViewModel, T> Arrange<T>(Expression<Func<TestFieldViewModel, T>> property, T value)
        {
            var propInfo = (PropertyInfo)((MemberExpression)property.Body).Member;
            return Arrange(property, m => propInfo.SetValue(m, value, null), m => m.IntList = IntList, m => m.StringList = StringList);
        }

        [Test]
        public void Use_correct_html_for_optional_int_list_id()
        {
            var g = Arrange(m => m.OptionalIntListId, null);

            var result = g.GetFieldHtml(null);

            HtmlApprovals.VerifyHtml(result.ToHtmlString());
        }

        [Test]
        public void Use_correct_html_for_required_nullable_int_list_id()
        {
            var g = Arrange(m => m.RequiredNullableIntListId, null);

            var result = g.GetFieldHtml(null);

            HtmlApprovals.VerifyHtml(result.ToHtmlString());
        }

        [Test]
        public void Use_correct_html_for_optional_string_list_id_as_list()
        {
            var g = Arrange(m => m.OptionalStringListId, string.Empty);

            var result = g.GetFieldHtml(new FieldConfiguration().AsList());

            HtmlApprovals.VerifyHtml(result.ToHtmlString());
        }

        [Test]
        public void Use_correct_html_for_optional_string_list_id_with_empty_item_hidden()
        {
            var g = Arrange(m => m.OptionalStringListId, string.Empty);

            var result = g.GetFieldHtml(new FieldConfiguration().HideEmptyItem());

            HtmlApprovals.VerifyHtml(result.ToHtmlString());
        }

        [Test]
        public void Use_correct_html_for_null_required_string_list_id_as_list()
        {
            var g = Arrange(m => m.RequiredStringListId, null);

            var result = g.GetFieldHtml(new FieldConfiguration().AsList());

            HtmlApprovals.VerifyHtml(result.ToHtmlString());
        }

        [Test]
        public void Use_correct_html_for_optional_int_list_id_with_none_string_override()
        {
            var g = Arrange(m => m.OptionalIntListId, null);

            var result = g.GetFieldHtml(new FieldConfiguration().WithNoneAs("-- Select Item"));

            HtmlApprovals.VerifyHtml(result.ToHtmlString());
        }

        [Test]
        public void Use_correct_html_for_optional_int_list_id_as_list()
        {
            var g = Arrange(m => m.OptionalIntListId, null);

            var result = g.GetFieldHtml(new FieldConfiguration().AsList());

            HtmlApprovals.VerifyHtml(result.ToHtmlString());
        }

        [Test]
        public void Use_correct_html_for_optional_string_list_id_as_list_with_none_string_override()
        {
            var g = Arrange(m => m.OptionalStringListId, "2");

            var result = g.GetFieldHtml(new FieldConfiguration().AsList().WithNoneAs("No Value"));

            HtmlApprovals.VerifyHtml(result.ToHtmlString());
        }

        [Test]
        public void Use_correct_html_for_required_int_list_id()
        {
            var g = Arrange(m => m.RequiredIntListId, 2);

            var result = g.GetFieldHtml(null);

            HtmlApprovals.VerifyHtml(result.ToHtmlString());
        }

        [Test]
        public void Use_correct_html_for_required_string_list_id_as_list()
        {
            var g = Arrange(m => m.RequiredStringListId, "2");

            var result = g.GetFieldHtml(new FieldConfiguration().AsList());

            HtmlApprovals.VerifyHtml(result.ToHtmlString());
        }
        
        [Test]
        public void Use_correct_html_for_required_int_list_ids()
        {
            var g = Arrange(m => m.RequiredIntListIds, new List<int>{ 1 , 2 });

            var result = g.GetFieldHtml(null);

            HtmlApprovals.VerifyHtml(result.ToHtmlString());
        }

        [Test]
        public void Use_correct_html_for_required_int_list_ids_as_list()
        {
            var g = Arrange(m => m.RequiredIntListIds, new List<int> { 1, 2 });

            var result = g.GetFieldHtml(new FieldConfiguration().AsList());

            HtmlApprovals.VerifyHtml(result.ToHtmlString());
        }

        [Test]
        public void Use_correct_html_for_required_nullable_int_list_ids()
        {
            var g = Arrange(m => m.RequiredNullableIntListIds, null);

            var result = g.GetFieldHtml(null);

            HtmlApprovals.VerifyHtml(result.ToHtmlString());
        }

        [Test]
        public void Use_correct_html_for_optional_int_list_ids()
        {
            var g = Arrange(m => m.OptionalIntListIds, new List<int> { 1, 2 });

            var result = g.GetFieldHtml(null);

            HtmlApprovals.VerifyHtml(result.ToHtmlString());
        }

        [Test]
        public void Use_correct_html_for_optional_int_list_ids_with_empty_item_hidden()
        {
            var g = Arrange(m => m.OptionalIntListIds, new List<int> { 1, 2 });

            var result = g.GetFieldHtml(new FieldConfiguration().HideEmptyItem());

            HtmlApprovals.VerifyHtml(result.ToHtmlString());
        }

        [Test]
        public void Use_correct_html_for_optional_int_list_ids_as_list()
        {
            var g = Arrange(m => m.OptionalIntListIds, new List<int> { 1, 2 });

            var result = g.GetFieldHtml(new FieldConfiguration().AsList());

            HtmlApprovals.VerifyHtml(result.ToHtmlString());
        }

        [Test]
        public void Use_correct_html_for_optional_nullable_int_list_ids()
        {
            var g = Arrange(m => m.OptionalNullableIntListIds, null);

            var result = g.GetFieldHtml(null);

            HtmlApprovals.VerifyHtml(result.ToHtmlString());
        }

        [Test]
        public void Use_correct_html_for_optional_nullable_int_list_ids_as_list()
        {
            var g = Arrange(m => m.OptionalNullableIntListIds, null);

            var result = g.GetFieldHtml(new FieldConfiguration().AsList());

            HtmlApprovals.VerifyHtml(result.ToHtmlString());
        }

        [Test]
        public void Throw_exception_when_model_containing_list_property_is_null()
        {
            var g = Arrange(m => m.RequiredIntListId);
            _h.ViewData.Model = null;
            _h.ViewData.ModelMetadata.Model = null;

            var ex = Assert.Throws<ModelNullException>(() => g.GetFieldHtml(null));

            Assert.That(ex.Message, Is.EqualTo("The page model is null; please specify a model because it's needed to generate the list for property RequiredIntListId."));
        }

        [Test]
        public void Throw_exception_when_the_list_property_value_is_null()
        {
            var g = Arrange(m => m.OptionalIntListId, v => v.IntList = null);

            var ex = Assert.Throws<ListPropertyNullException>(() => g.GetFieldHtml(null));

            Assert.That(ex.Message, Is.EqualTo("The list property (IntList) specified in the [ExistsIn] on OptionalIntListId is null."));
        }
    }
}
