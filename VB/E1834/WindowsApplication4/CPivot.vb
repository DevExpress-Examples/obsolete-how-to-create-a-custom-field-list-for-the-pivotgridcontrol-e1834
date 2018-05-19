Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Text
Imports DevExpress.XtraPivotGrid
Imports DevExpress.XtraPivotGrid.Customization
Imports DevExpress.XtraPivotGrid.Data
Imports DevExpress.XtraEditors.Customization

Namespace MyControls
	Public Class CPivotGridControl
		Inherits PivotGridControl
		Protected Overrides Function CreateData() As DevExpress.XtraPivotGrid.Data.PivotGridViewInfoData
			Return New CPivotGridViewInfoData(Me)
		End Function
	End Class

	Public Class CPivotGridViewInfoData
		Inherits PivotGridViewInfoData
		Public Sub New(ByVal pivot As PivotGridControl)
			MyBase.New(pivot)
		End Sub

		Protected Overrides Function CreateCustomizationForm(ByVal style As CustomizationFormStyle) As CustomizationForm
			Return New CCustomizationForm(Me)
		End Function
	End Class

	Public Class CCustomizationForm
		Inherits CustomizationForm
		Public Sub New(ByVal data As PivotGridViewInfoData)
			MyBase.New(data, CustomizationFormStyle.Simple)
		End Sub

		Protected Overrides Function CreateCustomizationListBox() As CustomizationListBoxBase
			Return New CFieldCustomizationListBox(Me)
		End Function
	End Class

	Public Class CFieldCustomizationListBox
		Inherits PivotCustomizationTreeBox
		Public Sub New(ByVal form As CustomizationForm)
			MyBase.New(form)
		End Sub

		Protected Shadows ReadOnly Property CustomizationForm() As CCustomizationForm
			Get
				Return CType(MyBase.CustomizationForm, CCustomizationForm)
			End Get
		End Property
		Public Overrides Sub Populate()
			Me.BeginUpdate()
			Try
				Items.Clear()
				Dim list As New ArrayList()
				For Each f As PivotGridFieldBase In CustomizationForm.Data.Fields
					list.Add(f)
				Next f
				list.Sort(New myComparer())
				For Each f As PivotGridFieldBase In list
					Items.Add(CreateTreeNode(f))
				Next f
			Finally
				Me.EndUpdate()
			End Try
		End Sub
		Private Function CreateTreeNode(ByVal f As PivotGridFieldBase) As Object
			Return New PivotCustomizationTreeNode(CustomizationFields.FieldItems, f.Index)
		End Function
	End Class

	Public Class myComparer
		Implements IComparer
		Private comparer As IComparer = New CaseInsensitiveComparer()
		Private Function IComparer_Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
			Dim fieldx As PivotGridFieldBase = TryCast(x, PivotGridFieldBase)
			Dim fieldy As PivotGridFieldBase = TryCast(y, PivotGridFieldBase)

			If fieldx IsNot Nothing AndAlso fieldy IsNot Nothing Then
				Dim valx As String
				If String.IsNullOrEmpty(fieldx.Caption) Then
					valx = fieldx.FieldName
				Else
					valx = fieldx.Caption
				End If
				Dim valy As String
				If String.IsNullOrEmpty(fieldy.Caption) Then
					valy = fieldy.FieldName
				Else
					valy = fieldy.Caption
				End If
				Return comparer.Compare(valx, valy)
			End If
			Return (comparer.Compare(y, x))
		End Function
	End Class


End Namespace
