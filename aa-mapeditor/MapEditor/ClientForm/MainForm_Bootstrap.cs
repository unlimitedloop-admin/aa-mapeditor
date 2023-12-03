/**************************************************************/
//
//
//      Copyright (c) 2023 UNLIMITED LOOP ROOT-ONE
//
//
//      This software(and source code) is completely Unlicense.
//      see "LICENSE".
//
//
/**************************************************************/
//
//
//      Arthentic Action Map Editor (Csharp Edition)
//
//      File name       : MainForm_Bootstrap.cs
//
//      Author          : u7
//
//      Last update     : 2023/12/03
//
//      File version    : 1
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Apps.Core;
using ClientForm.src.Apps.EditsUI;
using Microsoft.Extensions.DependencyInjection;



/* sources */
namespace ClientForm
{
    public partial class MainForm : Form
    {
        private readonly ServiceProvider _services;

        /// <summary>
        ///  A DI container is used to share data between multiple classes.
        /// </summary>
        /// <returns>The default IServiceProvider.</returns>
        private static ServiceProvider RegisteringServiceProvider()
        {
            ServiceCollection services = new();

            // Register BinaryArrayData as an implementation of IBinaryArrayData and IBinaryFile.
            services.AddSingleton<IBinaryArrayData, BinaryArrayData>();
            services.AddSingleton(provider => (IBinaryFile)provider.GetRequiredService<IBinaryArrayData>());

            // Registration of other necessary services.
            services.AddSingleton<IMapFieldViewer, MapFieldViewer>();
            services.AddSingleton<Func<TextBox, IPageIndex>>(provider => (textbox) =>
            {
                // NOTE : Since the PageIndexer class has a required parameter in its default constructor, define the factory method of the IPageIndex interface first.
                return new PageIndexer(textbox);
            });

            // Obtaining Services.
            return services.BuildServiceProvider();
        }

        private IBinaryArrayData GetIBinaryArrayData()
        {
            return _services.GetService<IBinaryArrayData>()!;
        }

        private IBinaryFile GetIBinaryFile()
        {
            return _services.GetService<IBinaryFile>()!;
        }

        private IMapFieldViewer GetMapFieldViewer()
        {
            return _services.GetService<IMapFieldViewer>()!;
        }

        private IPageIndex GetIPageIndex()
        {
            TextBox textbox = showPagesTextBox;
            var pageIndexerFactory = _services.GetService<Func<TextBox, IPageIndex>>()!;
            return pageIndexerFactory(textbox);
        }

        private static MapFieldNavigator GetMapFieldNavigator(IMapFieldViewer mapFieldViewer, IBinaryArrayData binaryArrayData, IBinaryFile binaryFile, IPageIndex pageIndex)
        {
            return new MapFieldNavigator(mapFieldViewer, binaryArrayData, binaryFile, pageIndex);
        }
    }
}
