<!-- default file list -->
*Files to look at*:

* [CPivot.cs](./CS/WindowsApplication4/CPivot.cs) (VB: [CPivot.vb](./VB/WindowsApplication4/CPivot.vb))
<!-- default file list end -->
# OBSOLETE: How to create a custom Field List for the PivotGridControl
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e1834)**
<!-- run online end -->


<p>This example demonstrates how to use the feature implemented in the context of the <a href="https://www.devexpress.com/Support/Center/p/S19641">S19641</a> suggestion.</p><p>To accomplish this task, inherit from the PivotGridControl, PivotGridViewInfoData and CustomizationForm classes. Within the custom PivotGridControl class, override the CreateData method to return your own PivotGridViewInfoData. Within the custom PivotGridViewInfoData class, override the CreateCustomizationForm method.</p><p>To see how to group fields in the customization form please refer to the <a href="https://www.devexpress.com/Support/Center/p/E1835">OBSOLETE: Create a custom Field List that shows fields in tree-like structure</a> example</p><p></p>


<h3>Description</h3>

<p>Starting from version 2011 vol 1, the FieldCustomizationTreeBox class was renamed to PivotCustomizationTreeBox.<br />
Starting from version 2011 vol 1, the CustomizationFormBase.CreateCustomizationListBox method signature is changed. The return type is now CustomizationListBoxBase.<br />
Starting from version 2011 vol 1, the PivotCustomizationTreeNode constructor signature was changed. Now, the constructor takes two parameters: PivotFieldItemCollection, and the index of the specified field in the collection. The PivotFieldItemCollection instance can be obtained via the PivotCustomizationTreeBoxBase.CustomizationFields.FieldItems property, and the index can be obtained via the PivotGridFieldBase.Index property.</p>

<br/>


