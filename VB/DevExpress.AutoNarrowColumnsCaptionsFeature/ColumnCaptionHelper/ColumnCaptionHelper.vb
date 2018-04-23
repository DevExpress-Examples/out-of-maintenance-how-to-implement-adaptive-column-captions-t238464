Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Columns
Imports System.Collections
Imports DevExpress.Utils
Imports DevExpress.Utils.Drawing

Namespace DevExpress.AutoNarrowColumnsCaptionsFeature.ColumnCaptionHelper

    <DesignerCategory("")> _
    Public Class ColumnCaptionHelper
        Inherits Component

        Private Const SEPARATOR_STRING As String = ";"
        Public Sub New()
            CaptionItems = New CaptionItem(){}
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Enabled = False
            MyBase.Dispose(disposing)
        End Sub

        Private _Enabled As Boolean
        Private _AutoFill As Boolean
        Private _View As GridView

        Public Property Enabled() As Boolean
            Get
                Return _Enabled
            End Get
            Set(ByVal value As Boolean)
                If _Enabled = value Then
                    Return
                End If
                _Enabled = value
                OnChanged()
            End Set
        End Property
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Property AutoFill() As Boolean
            Get
                Return _AutoFill
            End Get
            Set(ByVal value As Boolean)
                _AutoFill = value
                OnAutoFillChanged()
            End Set
        End Property
        Public Property View() As GridView
            Get
                Return _View
            End Get
            Set(ByVal value As GridView)
                _View = value
                OnChanged()
            End Set
        End Property
        <DisplayName("Caption Items"), Description("Use ';' to separate captions")> _
        Public Property CaptionItems() As CaptionItem()


        Private Sub OnChanged()
            If View Is Nothing Then
                Return
            End If
            RemoveHandler View.CustomDrawColumnHeader, AddressOf View_CustomDrawColumnHeader
            If Enabled Then
                AddHandler View.CustomDrawColumnHeader, AddressOf View_CustomDrawColumnHeader
            End If
            View.RefreshData()
        End Sub

        Private Sub View_CustomDrawColumnHeader(ByVal sender As Object, ByVal e As ColumnHeaderCustomDrawEventArgs)
            If e.Column IsNot Nothing Then
                Dim captionItem = CaptionItems.FirstOrDefault(Function(x) x.FieldName = e.Column.FieldName)
                If captionItem IsNot Nothing Then
                    Dim bestCaption As String = GetBestCaption(e.Cache, e.Column, e.Info.CaptionRect.Width, captionItem)
                    If Not String.IsNullOrEmpty(bestCaption) Then
                        e.Info.Caption = bestCaption
                    End If
                End If
            End If
        End Sub

        Private Function GetBestCaption(ByVal cache As GraphicsCache, ByVal column As GridColumn, ByVal width As Integer, ByVal item As CaptionItem) As String
            Dim captions = item.Captions.Split(New String() { SEPARATOR_STRING }, StringSplitOptions.RemoveEmptyEntries)
            Dim resultItem = captions.Select(Function(x) New With {Key .Caption = x, Key .Width = GetTextWidth(cache, column, x)}).OrderByDescending(Function(x) x.Width).FirstOrDefault(Function(x) x.Width < width)
            Return If(resultItem Is Nothing, String.Empty, resultItem.Caption)
        End Function

        Public Function GetTextWidth(ByVal cache As GraphicsCache, ByVal column As GridColumn, ByVal text As String) As Integer
            Return column.AppearanceHeader.CalcTextSizeInt(cache, text, column.VisibleWidth).Width
        End Function


        Private Sub OnAutoFillChanged()
            If (Not _AutoFill) OrElse View Is Nothing Then
                Return
            End If
            DoAutoFill()
        End Sub

        Private Sub DoAutoFill()
            Dim length As Integer = CaptionItems.Length + View.Columns.Count
            Dim captions As New List(Of CaptionItem)()
            captions.AddRange(CaptionItems)
            For i As Integer = 0 To View.Columns.Count - 1
                Dim column As GridColumn = View.Columns(i)
                captions.Add(New CaptionItem() With {.FieldName = column.FieldName, .Captions = column.GetCaption() & SEPARATOR_STRING})
            Next i
            CaptionItems = captions.ToArray()
        End Sub
    End Class

    Public Class CaptionItem
        Public Sub New()
        End Sub
        Public Property FieldName() As String



        Public Property Captions() As String

        Public Overrides Function ToString() As String
            Return If(String.IsNullOrEmpty(FieldName), "Empty item", FieldName)
        End Function
    End Class
End Namespace
