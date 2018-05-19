# OBSOLETE: How to create a custom Field List for the PivotGridControl


<p>This example demonstrates how to use the feature implemented in the context of the <a href="https://www.devexpress.com/Support/Center/p/S19641">S19641</a> suggestion.</p><p>To accomplish this task, inherit from the PivotGridControl, PivotGridViewInfoData and CustomizationForm classes. Within the custom PivotGridControl class, override the CreateData method to return your own PivotGridViewInfoData. Within the custom PivotGridViewInfoData class, override the CreateCustomizationForm method.</p><p>To see how to group fields in the customization form please refer to the <a href="https://www.devexpress.com/Support/Center/p/E1835">OBSOLETE: Create a custom Field List that shows fields in tree-like structure</a> example</p><p></p>

<br/>


