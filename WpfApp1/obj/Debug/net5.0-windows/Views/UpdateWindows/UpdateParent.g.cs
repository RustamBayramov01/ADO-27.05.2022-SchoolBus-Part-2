﻿#pragma checksum "..\..\..\..\..\Views\UpdateWindows\UpdateParent.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2F30E7F4E1270127939EE339FF59247116FE2DE1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WpfApp1.Views.UpdateWindows;


namespace WpfApp1.Views.UpdateWindows {
    
    
    /// <summary>
    /// UpdateParent
    /// </summary>
    public partial class UpdateParent : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\..\..\Views\UpdateWindows\UpdateParent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstName;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\..\Views\UpdateWindows\UpdateParent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LastName;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\..\Views\UpdateWindows\UpdateParent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Phone;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\..\..\Views\UpdateWindows\UpdateParent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UserName;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\..\..\Views\UpdateWindows\UpdateParent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Password;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\..\..\..\Views\UpdateWindows\UpdateParent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SAVE;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\..\..\..\Views\UpdateWindows\UpdateParent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CLEAR;
        
        #line default
        #line hidden
        
        
        #line 185 "..\..\..\..\..\Views\UpdateWindows\UpdateParent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock KeyName;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/views/updatewindows/updateparent.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\UpdateWindows\UpdateParent.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 7 "..\..\..\..\..\Views\UpdateWindows\UpdateParent.xaml"
            ((WpfApp1.Views.UpdateWindows.UpdateParent)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FirstName = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\..\..\..\Views\UpdateWindows\UpdateParent.xaml"
            this.FirstName.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.FirstName_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LastName = ((System.Windows.Controls.TextBox)(target));
            
            #line 64 "..\..\..\..\..\Views\UpdateWindows\UpdateParent.xaml"
            this.LastName.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.LastName_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Phone = ((System.Windows.Controls.TextBox)(target));
            
            #line 87 "..\..\..\..\..\Views\UpdateWindows\UpdateParent.xaml"
            this.Phone.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Phone_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.UserName = ((System.Windows.Controls.TextBox)(target));
            
            #line 107 "..\..\..\..\..\Views\UpdateWindows\UpdateParent.xaml"
            this.UserName.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.UserName_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Password = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.SAVE = ((System.Windows.Controls.Button)(target));
            
            #line 157 "..\..\..\..\..\Views\UpdateWindows\UpdateParent.xaml"
            this.SAVE.Click += new System.Windows.RoutedEventHandler(this.SAVE_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.CLEAR = ((System.Windows.Controls.Button)(target));
            
            #line 169 "..\..\..\..\..\Views\UpdateWindows\UpdateParent.xaml"
            this.CLEAR.Click += new System.Windows.RoutedEventHandler(this.CANCEL_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.KeyName = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

