<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128629467/14.2.7%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T238464)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [ColumnCaptionHelper.cs](./CS/DevExpress.AutoNarrowColumnsCaptionsFeature/ColumnCaptionHelper/ColumnCaptionHelper.cs) (VB: [ColumnCaptionHelper.vb](./VB/DevExpress.AutoNarrowColumnsCaptionsFeature/ColumnCaptionHelper/ColumnCaptionHelper.vb))
* [Form1.cs](./CS/DevExpress.AutoNarrowColumnsCaptionsFeature/Form1.cs) (VB: [Form1.vb](./VB/DevExpress.AutoNarrowColumnsCaptionsFeature/Form1.vb))
* [Program.cs](./CS/DevExpress.AutoNarrowColumnsCaptionsFeature/Program.cs) (VB: [Program.vb](./VB/DevExpress.AutoNarrowColumnsCaptionsFeature/Program.vb))
<!-- default file list end -->
# How to implement adaptive column captions


<p>This example demonstrates how to automatically change your column caption based on the column width. So, when an end-user resizes a column, the column caption is not truncated. </p>
<p><br />To enable this functionality in your project, execute the following steps:<br /><br />1. Drop the <strong>ColumnCaptionHelper </strong>component onto your form from the VS Toolbox.<br />2. Assign your GridView to its <strong>View</strong> property.<br />3. Set its <strong>Enabled</strong> property to <em>true. <br /></em>4<em>. </em>If you want to automatically populate items from existing GridView columns, enable the <strong>AutoFill </strong>option. <br />5. Then, create required caption items in the <strong>CaptionItems</strong> collection and specify required captions. Use the ';' char as a separator. (You can change it in the component's code if it's necessary)<br /><br />That's it. Once the column is resized, it will automatically display the most suitable caption based on its size.</p>

<br/>


