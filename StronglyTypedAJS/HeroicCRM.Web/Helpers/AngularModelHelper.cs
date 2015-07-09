﻿using System;
﻿using System.Collections.Generic;
﻿using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using HeroicCRM.Web.Utilities;
using HtmlTags;
using Humanizer;

namespace HeroicCRM.Web.Helpers
{
	public class AngularModelHelper<TModel>
	{
		protected readonly HtmlHelper Helper;
		private readonly string _expressionPrefix;

		public AngularModelHelper(HtmlHelper helper, string expressionPrefix)
		{
			Helper = helper;
			_expressionPrefix = expressionPrefix;
		}

		/// <summary>
		/// Converts an lambda expression into a camel-cased string, prefixed
		/// with the helper's configured prefix expression, ie:
		/// vm.model.parentProperty.childProperty
		/// </summary>
		public IHtmlString ExpressionFor<TProp>(Expression<Func<TModel, TProp>> property)
		{
			var expressionText = ExpressionForInternal(property);
			return new MvcHtmlString(expressionText);
		}

		/// <summary>
		/// Converts a lambda expression into a camel-cased AngularJS binding expression, ie:
		/// {{vm.model.parentProperty.childProperty}} 
		/// </summary>
		public IHtmlString BindingFor<TProp>(Expression<Func<TModel, TProp>> property)
		{
			return MvcHtmlString.Create("{{" + ExpressionForInternal(property) + "}}");
		}

		/// <summary>
		/// Creates a div with an ng-repeat directive to enumerate the specified property,
		/// and returns a new helper you can use for strongly-typed bindings on the items
		/// in the enumerable property.
		/// </summary>
		public AngularNgRepeatHelper<TSubModel> Repeat<TSubModel>(
			Expression<Func<TModel, IEnumerable<TSubModel>>> property, string variableName)
		{
			var propertyExpression = ExpressionForInternal(property);
			return new AngularNgRepeatHelper<TSubModel>(
				Helper, variableName, propertyExpression);
		}

		private string ExpressionForInternal<TProp>(Expression<Func<TModel, TProp>> property)
		{
			var camelCaseName = property.ToCamelCaseName();

			var expression = !string.IsNullOrEmpty(_expressionPrefix)
				? _expressionPrefix + "." + camelCaseName
				: camelCaseName;

			return expression;
		}

		public HtmlTag FormGroupFor<TProp>(Expression<Func<TModel, TProp>> property)
		{
			var metadata = ModelMetadata.FromLambdaExpression(property, new ViewDataDictionary<TModel>());
			
			var name = ExpressionHelper.GetExpressionText(property);

			var expression = ExpressionForInternal(property);

			//Creates <div class="form-group has-feedback"
			//				form-group-validation="Name">
			var formGroup = new HtmlTag("div")
				.AddClasses("form-group", "has-feedback")
				.Attr("form-group-validation", name)
				;

			var labelText = metadata.DisplayName ?? name.Humanize(LetterCasing.Title);

			//Creates <label class="control-label" for="Name">Name</label>
			var label = new HtmlTag("label")
				.AddClass("control-label")
				.Attr("for", name)
				.Text(labelText);

			var tagName = metadata.DataTypeName == "MultilineText"
				? "textarea"
				: "input";

			var placeholder = metadata.Watermark ??
			                  (labelText + "...");
			//Creates <input ng-model="expression"
			//		   class="form-control" name="Name" type="text" >
			var input = new HtmlTag(tagName)
				.AddClass("form-control")
				.Attr("ng-model", expression)
				.Attr("name", name)
				.Attr("type", "text")
				.Attr("placeholder", placeholder);

			ApplyValidationToInput(input, metadata);

			return formGroup
				.Append(label)
				.Append(input);
		}

		private void ApplyValidationToInput(HtmlTag input, ModelMetadata metadata)
		{
			if (metadata.IsRequired)
				input.Attr("required", "");

			if (metadata.DataTypeName == "EmailAddress")
				input.Attr("type", "email");

			if (metadata.DataTypeName == "PhoneNumber")
				input.Attr("pattern", @"[\ 0-9()-]+");
		}
	}
}