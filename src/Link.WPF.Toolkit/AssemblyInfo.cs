using System;
using System.Windows;
using System.Windows.Markup;

//#if NET40
//using System.Windows.Interactivity;
//#endif

//auto find style need
[assembly: ThemeInfo(ResourceDictionaryLocation.None, ResourceDictionaryLocation.SourceAssembly)]

//auto generate alias
[assembly: XmlnsPrefix("http://schemas.canself.com/wpf/xaml/toolkit", "cstk")]
//uri style xmlns namespace
[assembly: XmlnsDefinition("http://schemas.canself.com/wpf/xaml/toolkit", "Link.WPF.Toolkit")]
[assembly: XmlnsDefinition("http://schemas.canself.com/wpf/xaml/toolkit", "Link.WPF.Toolkit.Behaviors")]

//#if NET40
//[assembly: XmlnsDefinition("http://schemas.microsoft.com/xaml/behaviors", "System.Windows.Interactivity", AssemblyName = "System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35")]
//#endif