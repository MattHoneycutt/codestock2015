using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using HtmlTags;

namespace HeroicCRM.Web.Helpers
{
	public static class AngularHelperExtension
	{
		public static AngularHelper<TModel> Angular<TModel>(this HtmlHelper<TModel> helper)
		{
			return new AngularHelper<TModel>(helper);
		}
	}

	public class AngularHelper<TModel>
	{
		private readonly HtmlHelper<TModel> _htmlHelper;

		public AngularHelper(HtmlHelper<TModel> helper)
		{
			_htmlHelper = helper;
		}

		public AngularModelHelper<TModel> ModelFor(string expressionPrefix)
		{
			return new AngularModelHelper<TModel>(_htmlHelper, expressionPrefix);
		}

		public HtmlTag FormForModel(string expressionPrefix)
		{
			var modelHelper = ModelFor(expressionPrefix);

			var formGroupForMethodGeneric = typeof(AngularModelHelper<TModel>)
				.GetMethod("FormGroupFor");

			var wrapperTag = new HtmlTag("<div>").NoTag();

			foreach (var prop in typeof(TModel)
				.GetProperties(BindingFlags.Public | BindingFlags.Instance))
			{
				if (prop.GetCustomAttributes().OfType<HiddenInputAttribute>().Any()) continue;

				var formGroupForProp = formGroupForMethodGeneric
					.MakeGenericMethod(prop.PropertyType);

				var propertyLambda = MakeLambda(prop);

				var formGroupTag = (HtmlTag)formGroupForProp.Invoke(modelHelper, new[] { propertyLambda });

				wrapperTag.Append(formGroupTag);
			}

			return wrapperTag;
		}

		//Constructs a lambda of the form x => x.PropName
		private object MakeLambda(PropertyInfo prop)
		{
			var parameter = Expression.Parameter(typeof(TModel), "x");
			var property = Expression.Property(parameter, prop);
			var funcType = typeof(Func<,>).MakeGenericType(typeof(TModel), prop.PropertyType);

			//x => x.PropName
			return Expression.Lambda(funcType, property, parameter);
		}
	}
}