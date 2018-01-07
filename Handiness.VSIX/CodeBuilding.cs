//------------------------------------------------------------------------------
// <copyright file="CodeBuilding.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using System.Globalization;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System.Windows.Forms;
using EnvDTE;
using Handiness.CodeBuild;
namespace Handiness.VSIX
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class CodeBuilding
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("510853a6-957e-4709-a77c-9fcd9475e0ca");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly Package package;

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeBuilding"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        private CodeBuilding(Package package)
        {
            if (package == null)
            {
                throw new ArgumentNullException("package");
            }

            this.package = package;

            OleMenuCommandService commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;

            if (commandService != null)
            {
                var menuCommandID = new CommandID(CommandSet, CommandId);
                var menuItem = new MenuCommand(this.MenuItemCallback, menuCommandID);

                commandService.AddCommand(menuItem);
            }
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static CodeBuilding Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private IServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static void Initialize(Package package)
        {

            Instance = new CodeBuilding(package);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void MenuItemCallback(object sender, EventArgs e)
        {
          

            MainForm form = new MainForm();
            form.ServiceProvider = this.ServiceProvider;
            form.Show();
           // Visual Studio 自动化对象模型中的顶级对象 获取
            //var dteObject = this.ServiceProvider.GetService(typeof(EnvDTE.DTE)) as EnvDTE.DTE;
            //var project = this.GetStartupBuildProject(dteObject);
            //project.ProjectItems.AddFromDirectory(@"D:\Test");
        }
   
        /// <summary>
        /// 获取当前活动的项目
        /// </summary>
        /// <param name="dteObject"></param>
        /// <returns></returns>
        public EnvDTE.Project GetStartupBuildProject(EnvDTE.DTE dteObject)
        {
            Solution sln = dteObject.Solution;
            Array startsProjects = sln.SolutionBuild.StartupProjects as Array;
            if (startsProjects == null || startsProjects.Length < 1)
                return null;
            //获取的是项目的UniqueName
            String retProjName = startsProjects.GetValue(0) as String;
            if (retProjName == null)
                return null;

            foreach (EnvDTE.Project proj in sln.Projects)
            {
                if (proj == null)
                    continue;
                //通过项目的唯一名称来判断是否是同一个项目
                if (proj.UniqueName == retProjName)
                    return proj;
            }
            return null;
        }

    }
}
