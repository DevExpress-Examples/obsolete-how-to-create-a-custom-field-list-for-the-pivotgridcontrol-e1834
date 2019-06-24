<!-- default file list -->
*Files to look at*:

* [CPivot.cs](./CS/WindowsApplication4/CPivot.cs) (VB: [CPivot.vb](./VB/WindowsApplication4/CPivot.vb))
* [Form1.cs](./CS/WindowsApplication4/Form1.cs) (VB: [Form1.vb](./VB/WindowsApplication4/Form1.vb))
* [Program.cs](./CS/WindowsApplication4/Program.cs) (VB: [Program.vb](./VB/WindowsApplication4/Program.vb))
<!-- default file list end -->
# OBSOLETE: How to create a custom Field List for the PivotGridControl
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e1834)**
<!-- run online end -->


<p>This example demonstrates how to use the feature implemented in the context of the <a href="https://www.devexpress.com/Support/Center/p/S19641">S19641</a> suggestion.</p><p>To accomplish this task, inherit from the PivotGridControl, PivotGridViewInfoData and CustomizationForm classes. Within the custom PivotGridControl class, override the CreateData method to return your own PivotGridViewInfoData. Within the custom PivotGridViewInfoData class, override the CreateCustomizationForm method.</p><p>To see how to group fields in the customization form please refer to the <a href="https://www.devexpress.com/Support/Center/p/E1835">OBSOLETE: Create a custom Field List that shows fields in tree-like structure</a> example</p><p></p>

<br/>


