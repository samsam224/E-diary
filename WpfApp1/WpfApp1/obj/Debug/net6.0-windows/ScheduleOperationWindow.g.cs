﻿#pragma checksum "..\..\..\ScheduleOperationWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BD4B6E2ACB94577FBBE2EC6BBCD4BCA48F3AC0D5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfApp1;


namespace WpfApp1 {
    
    
    /// <summary>
    /// ScheduleOperationWindow
    /// </summary>
    public partial class ScheduleOperationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\ScheduleOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid scheduleGrid;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\ScheduleOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbTitle;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\ScheduleOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbCabinet;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\ScheduleOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbClass;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\ScheduleOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbLesson;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\ScheduleOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dp2;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\ScheduleOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnInsert;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\ScheduleOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnUpdate;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\ScheduleOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnDelete;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/scheduleoperationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ScheduleOperationWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.scheduleGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 16 "..\..\..\ScheduleOperationWindow.xaml"
            this.scheduleGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.scheduleGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TbTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TbCabinet = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TbClass = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TbLesson = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.dp2 = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.BtnInsert = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\ScheduleOperationWindow.xaml"
            this.BtnInsert.Click += new System.Windows.RoutedEventHandler(this.BtnInsert_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BtnUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\ScheduleOperationWindow.xaml"
            this.BtnUpdate.Click += new System.Windows.RoutedEventHandler(this.BtnUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BtnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\ScheduleOperationWindow.xaml"
            this.BtnDelete.Click += new System.Windows.RoutedEventHandler(this.BtnDelete_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

