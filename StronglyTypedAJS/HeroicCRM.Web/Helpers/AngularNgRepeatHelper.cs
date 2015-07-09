﻿using System;
using System.Web.Mvc;
using HtmlTags;

namespace HeroicCRM.Web.Helpers
{
	public class AngularNgRepeatHelper<TModel> : AngularModelHelper<TModel>, IDisposable
	{
		public AngularNgRepeatHelper(HtmlHelper helper, 
			string variableName, string propertyExpression)
			: base(helper, variableName)
		{
			var div = new HtmlTag("div");
			div.Attr("ng-repeat", 
				string.Format("{0} in {1}", variableName, propertyExpression));
			div.NoClosingTag();

			Helper.ViewContext.Writer.Write(div.ToString());
		}

		void IDisposable.Dispose()
		{
			Helper.ViewContext.Writer.Write("</div>");
		}
	}
}