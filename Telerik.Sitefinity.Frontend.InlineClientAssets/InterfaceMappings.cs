﻿using Ninject.Modules;
using Telerik.Sitefinity.Frontend.InlineClientAssets.Mvc.Models.EmbedCode;
using Telerik.Sitefinity.Frontend.InlineClientAssets.Mvc.Models.JavaScript;
using Telerik.Sitefinity.Frontend.InlineClientAssets.Mvc.Models.StyleSheet;

namespace Telerik.Sitefinity.Frontend.InlineClientAssets
{
    /// <summary>
    /// This class is used to describe the bindings which will be used by the Ninject container when resolving classes
    /// </summary>
    public class InterfaceMappings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<IJavaScriptModel>().To<JavaScriptModel>();
            Bind<IStyleSheetModel>().To<StyleSheetModel>();
            Bind<IEmbedCodeModel>().To<EmbedCodeModel>();
        }
    }
}
