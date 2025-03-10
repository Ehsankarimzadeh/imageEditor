﻿#pragma checksum "..\..\..\Images\ImagesPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D4FE851FF7B169B6642C660B4A502E4D23FD2A2136F4EB096B39B505D0C35666"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ImagesProcessing.Images;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace ImagesProcessing.Images {
    
    
    /// <summary>
    /// ImagesPage
    /// </summary>
    public partial class ImagesPage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\Images\ImagesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button loadImagesBtn;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Images\ImagesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addImageBtn;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Images\ImagesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editImageBtn;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Images\ImagesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button imageHistogramBtn;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Images\ImagesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cropImageBtn;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Images\ImagesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid imagesGrid;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Images\ImagesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imageBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ImagesProcessing;component/images/imagespage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Images\ImagesPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.loadImagesBtn = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\Images\ImagesPage.xaml"
            this.loadImagesBtn.Click += new System.Windows.RoutedEventHandler(this.loadImagesBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.addImageBtn = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\Images\ImagesPage.xaml"
            this.addImageBtn.Click += new System.Windows.RoutedEventHandler(this.addImageBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.editImageBtn = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Images\ImagesPage.xaml"
            this.editImageBtn.Click += new System.Windows.RoutedEventHandler(this.editImageBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.imageHistogramBtn = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\Images\ImagesPage.xaml"
            this.imageHistogramBtn.Click += new System.Windows.RoutedEventHandler(this.imageHistogramBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cropImageBtn = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\Images\ImagesPage.xaml"
            this.cropImageBtn.Click += new System.Windows.RoutedEventHandler(this.cropImageBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.imagesGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 71 "..\..\..\Images\ImagesPage.xaml"
            this.imagesGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.imagesGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.imageBox = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

