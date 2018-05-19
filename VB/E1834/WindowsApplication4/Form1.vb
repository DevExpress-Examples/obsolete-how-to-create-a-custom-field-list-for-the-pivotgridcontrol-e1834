Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports DevExpress.XtraPivotGrid

Namespace WindowsApplication4
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()

			Dim dt As New DataTable()
			dt.Columns.Add("Customer")
			dt.Columns.Add("Group")
			dt.Columns.Add("Amount", GetType(Decimal))

			dt.Rows.Add(New Object() { "A", "Group1", 500 })
			dt.Rows.Add(New Object() { "B", "Group2", 200 })
			dt.Rows.Add(New Object() { "C", "Group3", 200 })
			dt.Rows.Add(New Object() { "B", "Group1", 700 })
			dt.Rows.Add(New Object() { "A", "Group2", 0 })
			dt.Rows.Add(New Object() { "C", "Group3", 100 })
			dt.Rows.Add(New Object() { "A", "Group1", 100 })
			dt.Rows.Add(New Object() { "B", "Group2", 400 })
			dt.Rows.Add(New Object() { "C", "Group3", 200 })

			pivotGridControl1.Fields.Add("Customer", PivotArea.FilterArea).Visible = False
			pivotGridControl1.Fields.Add("Group", PivotArea.RowArea).Visible = False
			Dim f As PivotGridField = pivotGridControl1.Fields.Add("Amount", PivotArea.DataArea)
			f.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Sum

			pivotGridControl1.DataSource = dt

		End Sub

	End Class
End Namespace