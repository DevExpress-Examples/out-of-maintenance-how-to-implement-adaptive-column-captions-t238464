Namespace DevExpress.AutoNarrowColumnsCaptionsFeature
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Dim captionItem1 As New DevExpress.AutoNarrowColumnsCaptionsFeature.ColumnCaptionHelper.CaptionItem()
            Dim captionItem2 As New DevExpress.AutoNarrowColumnsCaptionsFeature.ColumnCaptionHelper.CaptionItem()
            Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
            Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.gridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.gridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.columnCaptionHelper1 = New DevExpress.AutoNarrowColumnsCaptionsFeature.ColumnCaptionHelper.ColumnCaptionHelper()
            DirectCast(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' gridControl1
            ' 
            Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.gridControl1.Location = New System.Drawing.Point(0, 0)
            Me.gridControl1.MainView = Me.gridView1
            Me.gridControl1.Name = "gridControl1"
            Me.gridControl1.Size = New System.Drawing.Size(632, 278)
            Me.gridControl1.TabIndex = 0
            Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
            ' 
            ' gridView1
            ' 
            Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.gridColumn1, Me.gridColumn2})
            Me.gridView1.GridControl = Me.gridControl1
            Me.gridView1.Name = "gridView1"
            ' 
            ' gridColumn1
            ' 
            Me.gridColumn1.Caption = "Full name"
            Me.gridColumn1.FieldName = "Name"
            Me.gridColumn1.Name = "gridColumn1"
            Me.gridColumn1.Visible = True
            Me.gridColumn1.VisibleIndex = 0
            ' 
            ' gridColumn2
            ' 
            Me.gridColumn2.FieldName = "Number of department"
            Me.gridColumn2.Name = "gridColumn2"
            Me.gridColumn2.Visible = True
            Me.gridColumn2.VisibleIndex = 1
            ' 
            ' columnCaptionHelper1
            ' 
            captionItem1.Captions = "Full Name;Name;Nm;"
            captionItem1.FieldName = "Name"
            captionItem2.Captions = "DN;Number of department;NoD;Dpt Number;"
            captionItem2.FieldName = "Number of department"
            Me.columnCaptionHelper1.CaptionItems = New DevExpress.AutoNarrowColumnsCaptionsFeature.ColumnCaptionHelper.CaptionItem() { captionItem1, captionItem2}
            Me.columnCaptionHelper1.Enabled = True
            Me.columnCaptionHelper1.View = Me.gridView1
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(632, 278)
            Me.Controls.Add(Me.gridControl1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            DirectCast(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private gridControl1 As XtraGrid.GridControl
        Private gridView1 As XtraGrid.Views.Grid.GridView
        Private gridColumn1 As XtraGrid.Columns.GridColumn
        Private gridColumn2 As XtraGrid.Columns.GridColumn
        Private columnCaptionHelper1 As ColumnCaptionHelper.ColumnCaptionHelper

    End Class
End Namespace

